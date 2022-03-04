using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CidadeAlta.Data.Context;
using CidadeAlta.Security;
using CidadeAlta.Data;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System;

namespace CidadeAlta.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.ConfigureData(Configuration);

            services.ConfigureSecurity(Configuration);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Cidade Alta API",
                    Description = "Uma API de serviços para o Cidade Alta"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();

                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                var context = serviceScope.ServiceProvider.GetRequiredService<CidadeAltaContext>();
                context.Database.Migrate();

                var solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                var insertDefaltUserSqlFileLocation = Path.Combine(solutionDirectory, "CidadeAlta.Data\\SQL\\InsertDefaultUser.sql");
                var insertDefaultUserSQl = File.ReadAllText(insertDefaltUserSqlFileLocation);
                context.Database.ExecuteSqlRaw(insertDefaultUserSQl);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
