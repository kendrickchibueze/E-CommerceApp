using Core.Interfaces;
using Core.LoggerService;
using E_CommerceApp.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;

namespace E_CommerceApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
              builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
          });


        public static void ConfigureIISIntegration(this IServiceCollection services) =>
          services.Configure<IISOptions>(options =>
          {

          });


        public static void ConfigureLoggerService(this IServiceCollection services) =>
         services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString")["DefaultConn"];
            services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString));
        }

      

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                       .Where(e => e.Value.Errors.Count > 0)
                                       .SelectMany(x => x.Value.Errors)
                                       .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });





        }
    }
}
