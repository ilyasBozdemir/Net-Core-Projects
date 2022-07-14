using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class AppUser: IdentityUser<Guid>
    {
        public User User { get; set; }
    }

}
