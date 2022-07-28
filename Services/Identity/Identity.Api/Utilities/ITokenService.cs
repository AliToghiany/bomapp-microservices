using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Api.Utilities
{
    public interface ITokenService
    {
        string BuildToken(long id);
    }
    public class TokenService : ITokenService
    {

        
            public string BuildToken(long id)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurUserIdentity"));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var claims = new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier,id.ToString() ),
                new Claim(ClaimTypes.Role,"Costumer")
                };
                var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                return encodedJwt;
            }
        
    }
}
