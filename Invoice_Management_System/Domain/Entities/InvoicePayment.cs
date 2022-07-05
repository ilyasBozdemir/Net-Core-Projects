using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InvoicePayment : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public Guid UserId { get; set; }
        public decimal PayingAmount { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
    }
}
