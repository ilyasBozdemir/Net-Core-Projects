using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class AidatMapping : IEntityTypeConfiguration<Aidat>
    {
        public void Configure(EntityTypeBuilder<Aidat> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Donem).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Tutar).IsRequired();
            builder.Property(x => x.SonOdemeTarihi).IsRequired();
            builder.Property(x => x.Aciklama).HasMaxLength(250);

            builder.ToTable("Aidatlar");
        }
    }
}
