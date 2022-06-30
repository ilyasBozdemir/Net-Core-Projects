using IMS.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entities.DTOs
{
    public class InvoiceDto : IDto
    { 
        public int Id { get; set; }
        public string InvoiceType { get; set; }
        public string House { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
