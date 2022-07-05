using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    
    public class User : BaseEntity
    {
        public override Guid Id { get; set; }
        public long CitizenId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string OperationClaim { get; set; } = OperationClaims.User;
        public string RefreshToken { get; set; }
        public DateTime? RefresTokenExpireDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
