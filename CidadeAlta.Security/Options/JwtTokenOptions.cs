using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CidadeAlta.Security.Options
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationInSeconds { get; set; }
        public string Secret { get; set; }
        public DateTime NotBefore => DateTime.UtcNow;
        public DateTime IssuedAt => DateTime.UtcNow;
        public TimeSpan ValidFor => TimeSpan.FromSeconds(ExpirationInSeconds);
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public Func<string> JtiGenerator => () => Guid.NewGuid().ToString();
        public SymmetricSecurityKey SigningCredentials => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
    }
}
