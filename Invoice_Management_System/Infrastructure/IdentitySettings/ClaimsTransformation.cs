using Domain.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IdentitySettings
{
    public class ClaimsTransformation : IClaimsTransformation
    {
        private readonly UserManager<AppUser> _userManager;

        public ClaimsTransformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;
            var user = await _userManager.FindByNameAsync(identity?.Name);
            if (user != null)
            {
                //if (!principal.HasClaim(c => c.Type == ClaimTypes.Gender))
                //{
                //    var genderClaim = new Claim(ClaimTypes.Gender, Enum.GetName(user.Gender)!);
                //    identity?.AddClaim(genderClaim);
                //}

                //if (!principal.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
                //{
                //    var birthDayClaim = new Claim(ClaimTypes.DateOfBirth, user.BirthDay.ToShortDateString());
                //    identity?.AddClaim(birthDayClaim);
                //}

                //if (!principal.HasClaim(c => c.Type == "FreeTrial"))
                //{
                //    var freeTrialClaim = new Claim("FreeTrial", user.CreatedOn.ToShortDateString());
                //    identity?.AddClaim(freeTrialClaim);
                //}
            }
            return principal;
        }
    }
}
