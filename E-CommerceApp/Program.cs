using Core.Entities.Identity;
using E_CommerceApp.Extensions;
using E_CommerceApp.Middleware;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace E_CommerceApp
{
    public class Program
    {
        public static  async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureSqlContext(builder.Configuration);



            builder.Services.AddSwaggerDocumentation();


            builder.Services.AddAutoMapper(Assembly.Load("Infrastructure"));



            // Add services to the container.

            builder.Services.AddControllers();

           
            builder.Services.ConfigureServices(builder.Configuration);


          


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerDocumentation();
            }

            app.UseMiddleware<ExceptionMiddleware>();


            //when user hits an endpoint that doesn't exit, we trigger this
            //middleware which calls the error controller
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseCors("CorsPolicy");


            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<StoreContext>();
            var identityContext = services.GetRequiredService<AppIdentityDbContext>();
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                 
                bool isSeeded = context.Database.GetAppliedMigrations().Any();

                if (!isSeeded)
                {
                    
                    await context.Database.MigrateAsync();
                    await identityContext.Database.MigrateAsync();
                    await StoreContextSeed.SeedAsync(context);
                    await IdentityDbContextSeed.SeedUsersAsync(userManager);
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occured during migration");
            }


            app.Run();
        }
    }
}