using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class DaireMapping : IEntityTypeConfiguration<Daire>
    {
        public void Configure(EntityTypeBuilder<Daire> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.DaireNo).IsRequired();
            builder.Property(x => x.Blokid).IsRequired();
            builder.Property(x => x.BosMu).IsRequired();


            builder.HasOne<Blok>()
                   .WithMany(x => x.Daireler)
                   .HasForeignKey(x => x.Blokid);


            builder.ToTable("Daireler");
        }
    }
