using IMS.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entities.Concrete
{
    public class InvoicePayment : IEntity
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public decimal PayingAmount { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
    }
}
