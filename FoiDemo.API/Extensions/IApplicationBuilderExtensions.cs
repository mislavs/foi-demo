using Microsoft.AspNetCore.Builder;

namespace FoiDemo.API.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FOI API");
            });
        }
    }
}
