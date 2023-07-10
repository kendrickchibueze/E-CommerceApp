using E_CommerceApp.Extensions;
using E_CommerceApp.Middleware;
using Microsoft.AspNetCore.HttpOverrides;
using System.Reflection;


namespace E_CommerceApp
{
    public class Program
    {
        public static void Main(string[] args)
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

            app.Run();
        }
    }
}