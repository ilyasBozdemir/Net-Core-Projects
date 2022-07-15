using Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Utilities.Security.Jwt
{
    public class TokenHandler : ITokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        public Token CreateAccessToken(AppUser user)
        {
            Token tokenModel = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(60);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: tokenModel.Expiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: credentials
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;

        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        private IEnumerable<Claim> SetClaims(AppUser appUser)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, appUser.Email));
            claims.Add(new Claim(ClaimTypes.Name, $"{appUser.UserInfo.FullName}"));
            claims.Add(new Claim(ClaimTypes.Role, appUser.UserInfo.RoleName));

            return claims;
        }
    }
}
