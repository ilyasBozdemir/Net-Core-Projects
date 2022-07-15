using Domain.Common;
using Domain.Entities.Identity;
using Domain.Enums;
namespace Domain.Entities
{
    public class User : BaseEntity
    {      
        public long? CitizenId { get; set; }
        public string RoleName { get; set; } = Enum.GetName(UserRoles.Uye);
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictures { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }
        public TwoFactorType TwoFactorType { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
