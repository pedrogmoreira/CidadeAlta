using CidadeAlta.Api.AutoMapper;
using CidadeAlta.Data.Context;
using CidadeAlta.Security;
using CidadeAlta.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;
using CidadeAlta.Api.Configurations;

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

            services.AddAutoMapper(typeof(Mapper));

            services.ConfigureSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();

                using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                var context = serviceScope.ServiceProvider.GetRequiredService<CidadeAltaContext>();
                context.Database.Migrate();

                var solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
                var insertDefaltDataSqlFileLocation = Path.Combine(solutionDirectory, "CidadeAlta.Data\\SQL\\InsertDefaultData.sql");
                var insertDefaultDataSQl = File.ReadAllText(insertDefaltDataSqlFileLocation);

                context.Database.ExecuteSqlRaw(insertDefaultDataSQl);
            }
        }
    }
}
