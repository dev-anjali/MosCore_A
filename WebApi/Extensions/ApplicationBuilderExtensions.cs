using Microsoft.AspNetCore.Builder;

namespace MosCore.WebApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "MosCore.WebApi");
                options.RoutePrefix = "swagger";
                options.DisplayRequestDuration();
            });
        }
    }
}