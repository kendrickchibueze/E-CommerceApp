using Core.Interfaces;
using Core.LoggerService;
using E_CommerceApp.Errors;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Implementations;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

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

             var identityConnection = configuration.GetSection("ConnectionString")["IdentityConnection"];

            services.AddDbContext<StoreContext>(options => options.UseSqlServer(connectionString));

            services.AddDbContext<AppIdentityDbContext>(x =>
            {
                x.UseSqlServer(identityConnection);
            });



            var redisConnectionString = configuration.GetValue<string>("ConnectionString:Redis");
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                return ConnectionMultiplexer.Connect(redisConnectionString);
            });
        }




        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork<StoreContext>>();
            services.AddScoped<IProductService, ProductServices>();
            services.AddScoped<IBasketRepository, BasketRepository>();


            services.AddIdentityServices();


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


            

            /*  var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
               var identityContext = serviceProvider.GetRequiredService<AppIdentityDbContext>();



             identityContext.Database.Migrate();


             IdentityDbContextSeed.SeedUsersAsync(userManager).Wait(); 
 */




        }


      


       



    }
}

