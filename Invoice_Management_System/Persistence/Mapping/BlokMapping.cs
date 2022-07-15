using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class BlokMapping : IEntityTypeConfiguration<Blok>
    {
        public void Configure(EntityTypeBuilder<Blok> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.BlokAdi).IsRequired().HasMaxLength(30);
            builder.Property(x => x.ToplamDaire).IsRequired();

            builder.ToTable("Bloklar");

        }
    }
}
