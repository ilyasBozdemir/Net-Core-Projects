using Domain.Enums;
using Microsoft.AspNetCore.Identity;


namespace Domain.Entities.Identity
{
    public class User: IdentityUser<Guid>
    {
        public TwoFactorType TwoFactorType
        {
            get; set;
        }
        public DateTime BirthDay
        {
            get; set;
        }
        public Gender Gender
        {
            get; set;
        }
        public DateTime CreatedOn { get; set; }
        public override Guid Id 
        { 
            get => base.Id;
            set => base.Id = value;
        }

        public long CitizenId //vatandaşlık id
        {
            get;
            set;
        }

        public override string UserName 
        {
            get => base.UserName;
            set => base.UserName = value;
        }
        public override string Email 
        { 
            get => base.Email;
            set => base.Email = value;
        }
        public override bool EmailConfirmed 
        { 
            get => base.EmailConfirmed; 
            set => base.EmailConfirmed = value;
        }
        public string Name
        {
            get; 
            set;
        }
        public string Surname
        {
            get;
            set;
        }
        public string FullName 
        {
            get => $"{Name} {Surname}";
        }
        public override string PhoneNumber 
        { 
            get => base.PhoneNumber;
            set => base.PhoneNumber = value;
        }
        public override bool PhoneNumberConfirmed
        {
            get => base.PhoneNumberConfirmed;
            set => base.PhoneNumberConfirmed = value; 
        }
        public string PasswordSalt 
        { 
            get; 
            set; 
        }
        public override string PasswordHash 
        {
            get => base.PasswordHash;
            set => base.PasswordHash = value;
        }
        public bool IsActive
        {
            get; 
            set; 
        } = true;
        public override bool TwoFactorEnabled 
        { 
            get => base.TwoFactorEnabled;
            set => base.TwoFactorEnabled = value;
        }
        public override bool LockoutEnabled 
        { 
            get => base.LockoutEnabled; 
            set => base.LockoutEnabled = value;
        }
        public override int AccessFailedCount 
        { 
            get => base.AccessFailedCount; 
            set => base.AccessFailedCount = value;
        }
        public string OperationClaim { get; set; } 
            = OperationClaims.User;
    }

}
