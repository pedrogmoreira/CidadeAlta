using CidadeAlta.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CidadeAlta.Data.Helpers
{
    public static class MappingHelper
    {
        public static void ConfigureKey<T>(this EntityTypeBuilder<T> entity) where T : BaseEntity
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
