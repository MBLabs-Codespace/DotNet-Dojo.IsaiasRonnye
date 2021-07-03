using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dojo
{
    public static class JwtHelper
    {
        public static string GerarJwt(IdentityUser user)
        {
            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaim(new Claim("userid", user.UserName.ToString()));
            identityClaims.AddClaim(new Claim("email", user.Email.ToString()));

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtkey = Encoding.ASCII.GetBytes("QzpcUHJvamV0b1xEZWxpdmVyeVBheVxHaXRIdWJcY29uZWN0YXByaW1lQVBJXG1hc3Rlclx3ZWJhcHBDb25lY3RhUHJpbWUuQVBJXGFwaVxBdXRoQ29uZWN0YVByaW1lXEF1dGhlbnRpY2F0b3I");
            var CreatioDate = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = "MBLabs",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtkey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.WriteToken(tokenHandler.CreateJwtSecurityToken(tokenDescriptor));

            return token;
        }
    }
}