using Microsoft.EntityFrameworkCore;
using CidadeAlta.Domain.Entities;
using CidadeAlta.Data.Mappings;

namespace CidadeAlta.Data.Context
{
    public class CidadeAltaContext : DbContext
    {
        public DbSet<CriminalCode> CiminalCodes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        public CidadeAltaContext(DbContextOptions<CidadeAltaContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMapping).Assembly);
        }
    }
}
