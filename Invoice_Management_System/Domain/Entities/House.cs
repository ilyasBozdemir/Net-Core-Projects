using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class House : BaseEntity
    {
        public override Guid Id { get; set; }
        public Guid ApartmentId { get; set; }
        public string Block { get; set; }
        public bool Status { get; set; }
        public Guid ApartmentTypeId { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
    }
}
