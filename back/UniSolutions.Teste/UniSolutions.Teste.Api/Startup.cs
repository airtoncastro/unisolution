using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UniSolutions.Teste.Api;
using UniSolutions.Teste.Data.AutoMapper;
using UniSolutions.Teste.DependencyInjection;
using AutoMapper;
using MediatR;

namespace UniSolutions.Teste
{
    public class Startup
    {
        public readonly string ApiTitle = "UniSolutions.Teste";
        public readonly string[] ApiVersions = new string[] { "v1" };
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var assembliesToScan = DependencyContext.Default.GetAssemblies();
            var mapConfiguration = AutoMapperConfiguration.GetMapperConfiguration();
            services.AddAutoMapper(mapConfiguration, assembliesToScan);
            services.AddMediatR(assembliesToScan);
            
            services.AddSwaggerGen(ApiTitle, ApiVersions);

            var commandConnectionString = Configuration.GetConnectionString("CommandConnectionString");
            var queryConnectionString = Configuration.GetConnectionString("QueryConnectionString");

            services.AddUniSolutionContext(commandConnectionString, queryConnectionString);
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniSoliton Teste V1");
            });
        }
    }
}
