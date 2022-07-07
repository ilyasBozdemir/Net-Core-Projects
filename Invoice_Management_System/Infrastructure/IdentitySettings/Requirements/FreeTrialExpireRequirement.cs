using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IdentitySettings.Requirements
{
    public class FreeTrialExpireRequirement : IAuthorizationRequirement { }
    public class FreeTrialExpireHandler : AuthorizationHandler<FreeTrialExpireRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FreeTrialExpireRequirement requirement)
        {
            var freeTrialClaim = context.User.FindFirst(f => f.Type == "FreeTrial");
            if (freeTrialClaim != null)
            {
                var freeTrialExpires = Convert.ToDateTime(freeTrialClaim.Value).AddDays(30);
                if (DateTime.Now < freeTrialExpires)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }

            return Task.CompletedTask;
        }
    }

}
