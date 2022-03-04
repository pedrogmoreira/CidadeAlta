using CidadeAlta.Domain.ViewModel;

namespace CidadeAlta.Domain.Services
{
    public interface IAuthenticationService
    {
        string AthenticateUser(LoginViewModel loginViewModel);
    }
}
