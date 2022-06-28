using IMS.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entities.DTOs
{
    public class HouseDto : IDto
    {
        public int Id { get; set; }
        public string ApartmentName { get; set; }
        public int Floor { get; set; }
        public int DoorNumber { get; set; }
        public string FlatType { get; set; }
    }
}
