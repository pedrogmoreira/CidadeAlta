using CidadeAlta.Domain.DTO;

namespace CidadeAlta.Domain.Services
{
    public interface IAuthenticationService
    {
        string AthenticateUser(LoginDTO loginViewModel);
    }
}
