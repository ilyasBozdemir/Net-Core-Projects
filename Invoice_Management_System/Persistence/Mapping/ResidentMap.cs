using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mapping
{
    public class ResidentMap : IEntityTypeConfiguration<Resident>
    {
        public void Configure(EntityTypeBuilder<Resident> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.HasOne<User>().WithOne().HasForeignKey<Resident>(x => x.UserId);
            builder.HasOne<House>().WithMany().HasForeignKey(x => x.HouseId);
        }
    }
}
