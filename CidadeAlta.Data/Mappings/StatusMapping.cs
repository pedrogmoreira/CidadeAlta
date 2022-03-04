using CidadeAlta.Data.Helpers;
using CidadeAlta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CidadeAlta.Data.Mappings
{
    public class StatusMapping : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ConfigureKey();

            builder.Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
