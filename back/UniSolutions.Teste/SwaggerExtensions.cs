using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace UniSolutions.Teste.Api
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerGen(this IServiceCollection services, string apiTitle, params string[] apiVersions)
        {
            services.AddSwaggerGen(e =>
            {
                foreach (var version in apiVersions)
                {
                    e.SwaggerDoc(version, new OpenApiInfo { Title = apiTitle, Version = version });
                }
            });
            services.ConfigureSwaggerGen(options => options.CustomSchemaIds(e => e.FullName));
        }

        public static void UseSwaggerUI(this IApplicationBuilder app, string apiTitle, params string[] apiVersions)
        {
            app.UseSwagger();
            app.UseSwaggerUI(e =>
            {
                foreach (var version in apiVersions)
                {
                    e.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{apiTitle} {version}");
                }
            });
        }
    }
}
