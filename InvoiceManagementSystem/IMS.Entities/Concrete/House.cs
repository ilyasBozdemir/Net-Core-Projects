using IMS.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entities.Concrete
{
    public class House : IEntity
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public string Block { get; set; }
        public bool Status { get; set; }
        public int FlatTypeId { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }

    }
}
