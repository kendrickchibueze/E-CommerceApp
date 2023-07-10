using Microsoft.OpenApi.Models;

namespace E_CommerceApp.Extensions
{
    public static class SwaggerServiceExtensions
    {

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(sw =>
            {

                
                sw.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerceAPI", Version = "1.0" });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                    { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce Api v1"); });


            return app;

        }
    }
}
