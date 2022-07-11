using Domain.Enums;
using Microsoft.AspNetCore.Identity;


namespace Domain.Entities.Identity
{
    public class AppUser: IdentityUser<Guid>
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
     

        public long? CitizenId //vatandaşlık id
        {
            get;
            set;
        }
        
        public string FirstName
        {
            get; 
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string FullName 
        {
            get => $"{FirstName} {LastName}";
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
    }

}
