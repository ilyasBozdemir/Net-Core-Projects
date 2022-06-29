using IMS.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entities.Concrete
{
    public class InvoiceType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
