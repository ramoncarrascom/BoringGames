using BoringGames.API.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BoringGames
{
    public class Startup
    {
        private const string CORS_ALLOW_ONLY_LOCALHOST = "CorsOnlyLocalhost";

        /// <summary>
        /// Services and DI configuration
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CORS_ALLOW_ONLY_LOCALHOST, builder =>
                {
                    builder.WithOrigins("http://localhost:8100")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddControllers();

            new ServicesIocInstaller(services).Install();
            new RepositoriesIocInstaller(services).Install();
            new MiscIocInstaller(services).Install();
        }

        /// <summary>
        /// Request pipeline configuration
        /// </summary>
        /// <param name="app">App data</param>
        /// <param name="env">Environment data</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Boring Games V1");
                });
            }

            app.UseCors(CORS_ALLOW_ONLY_LOCALHOST);
            app.UseRouting();            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("BoringGames 0.1");
                });

                endpoints.MapControllers();
            });

        }
    }
}
