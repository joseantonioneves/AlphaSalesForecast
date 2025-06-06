using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Tokens
{
    public class JwtService
    {
        private readonly string _secureKey = "07FFD1FF89484E29898B6BCBABBB4CCD"; //chave aleatória segura
        public string Generate(long id)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, id.ToString())
            };
            var jwt = new JwtSecurityToken(
                issuer: "AppName",
                audience: "AppName",
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}