using CidadeAlta.Data.Helpers;
using CidadeAlta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CidadeAlta.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ConfigureKey();

            builder.Property(e => e.UserName)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
