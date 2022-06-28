using IMS.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entities.DTOs
{
    public class ResidentDto : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string House { get; set; }
        public bool IsHirer { get; set; }
        public bool IsOwner { get; set; }
        public string CarPlate { get; set; }
    }
}
