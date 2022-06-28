using IMS.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entities.DTOs
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public long CitizenId { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
