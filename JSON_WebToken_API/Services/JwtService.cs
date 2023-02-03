using JSON_WebToken_API.Models;
using JSON_WebToken_API.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JSON_WebToken_API.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _jwtOptions;
        public JwtService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public string GetJwtToken(User user)
        {
            var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //token id'si
                };

            var encodedKey = Encoding.UTF8.GetBytes(_jwtOptions.Secret); //JWT de bulunan Secret parametresini encode ettik.

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(encodedKey), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _jwtOptions.Issuer, audience: _jwtOptions.Audience, claims: claims, expires: DateTime.Now.Add(_jwtOptions.ExpiredTime), signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
