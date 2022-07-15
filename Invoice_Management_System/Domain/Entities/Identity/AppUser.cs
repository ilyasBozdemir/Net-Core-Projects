using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public User UserInfo { get; set; }
        public AppUser()
        {
            UserInfo = new User();
        }
    }
}
