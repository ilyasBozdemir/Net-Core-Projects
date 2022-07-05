using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice: BaseEntity
    {
        public override Guid Id { get; set; }
        public Guid InvoiceTypeId { get; set; }
        public Guid HouseId { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; } = true;
        public DateTime InvoiceDate { get; set; }
    }
}
