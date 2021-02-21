using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace SkolPortal.Data
{
    public class AppUserClaims : UserClaimsPrincipalFactory<AppUser>
    {
        public AppUserClaims(UserManager<AppUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(AppUser user)
        {
            var roles = await UserManager.GetRolesAsync(user);
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("DisplayName", user.DisplayName));
            identity.AddClaim(new Claim(ClaimTypes.Role, roles.FirstOrDefault()));

            return identity;
        }
    }
}
