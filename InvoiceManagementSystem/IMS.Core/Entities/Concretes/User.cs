using IMS.Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities.Concretes
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public long CitizenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string OperationClaim { get; set; } = OperationClaims.User;
        public string RefreshToken { get; set; }
        public DateTime? RefresTokenExpireDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
