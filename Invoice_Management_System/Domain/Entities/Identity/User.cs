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
     

        public long CitizenId //vatandaşlık id
        {
            get;
            set;
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
        public string PasswordSalt 
        { 
            get; 
            set; 
        }
       
        public bool IsActive
        {
            get; 
            set; 
        } = true;
       
        public string OperationClaim { get; set; } 
            = OperationClaims.User;
    }

}
