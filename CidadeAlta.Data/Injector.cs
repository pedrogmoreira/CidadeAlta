using CidadeAlta.Data.Context;
using CidadeAlta.Data.Repositories;
using CidadeAlta.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CidadeAlta.Data
{
    public static class Injector
    {
        public static void ConfigureData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CidadeAltaContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICriminalCodeRepository, CriminalCodeRepository>();
        }
    }
}
