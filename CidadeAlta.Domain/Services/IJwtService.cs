using CidadeAlta.Domain.Entities;

namespace CidadeAlta.Domain.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
