using CidadeAlta.Data.Helpers;
using CidadeAlta.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CidadeAlta.Data.Mappings
{
    public class CriminalCodeMapping : IEntityTypeConfiguration<CriminalCode>
    {
        public void Configure(EntityTypeBuilder<CriminalCode> builder)
        {
            builder.ConfigureKey();

            builder.Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.Penalty)
                .IsRequired();

            builder.Property(e => e.PrisionTime)
                .IsRequired();

            builder.Property(e => e.CreateDate)
                .HasDefaultValueSql("GETDATE()")
                .IsRequired();

            builder.Property(e => e.UpdateDate)
                .IsRequired(false);

            builder.Property(e => e.StatusId)
                .IsRequired();

            builder.Property(e => e.CreateUserId)
                .IsRequired();

            builder.Property(e => e.UpdateUserId)
                .IsRequired(false);

            builder.HasOne(e => e.Status)
                .WithMany(u => u.CriminalCodes)
                .HasForeignKey(e => e.StatusId);

            builder.HasOne(e => e.CreateUser)
                .WithMany(u => u.CriminalCodesCreated)
                .HasForeignKey(e => e.CreateUserId);

            builder.HasOne(e => e.UpdateUser)
                .WithMany(u => u.CriminalCodesUpdated)
                .HasForeignKey(e => e.UpdateUserId);
        }
    }
}
