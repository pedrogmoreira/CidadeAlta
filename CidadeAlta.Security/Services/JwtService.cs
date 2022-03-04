using CidadeAlta.Domain.Entities;
using CidadeAlta.Domain.Services;
using CidadeAlta.Security.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CidadeAlta.Security.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtTokenOptions _jwtTokenOptions;
        public JwtService(IOptions<JwtTokenOptions> jwtTokenOptions)
        {
            _jwtTokenOptions = jwtTokenOptions.Value;
        }

        public virtual string GenerateToken(User user)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                _jwtTokenOptions.Issuer,
                _jwtTokenOptions.Audience,
                GetClaims(user),
                _jwtTokenOptions.NotBefore,
                _jwtTokenOptions.Expiration,
                new SigningCredentials(_jwtTokenOptions.SigningCredentials, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            yield return new Claim(ClaimTypes.Name, user.UserName);
            yield return new Claim("UserId", user.Id.ToString());
            yield return new Claim(JwtRegisteredClaimNames.Jti, _jwtTokenOptions.JtiGenerator());
            yield return new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtTokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64);
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long) Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
    }
}
