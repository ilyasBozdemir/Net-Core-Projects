using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mapping
{
    public class InvoicePaymentMap : IEntityTypeConfiguration<InvoicePayment>
    {
        public void Configure(EntityTypeBuilder<InvoicePayment> builder)
        {
            builder.HasKey(ow => new { ow.InvoiceId, ow.UserId });
            builder.HasOne<Invoice>().WithMany().HasForeignKey(x => x.InvoiceId);
            builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
