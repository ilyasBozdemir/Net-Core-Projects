using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mapping
{
    public class ResidentMap : IEntityTypeConfiguration<Resident>
    {
        public void Configure(EntityTypeBuilder<Resident> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasOne<AppUser>().WithOne().HasForeignKey<Resident>(x => x.UserId);
            builder.HasOne<House>().WithMany().HasForeignKey(x => x.HouseId);
        }
    }
}
