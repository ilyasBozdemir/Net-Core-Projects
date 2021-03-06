using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class AppRole:IdentityRole<Guid>
    {
        public override string Name
        {   get => base.Name; 
            set => base.Name = value;
        }
        public DateTime CreatedOn 
        { 
            get; set; 
        }
    }
}
