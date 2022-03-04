using CidadeAlta.Domain.Entities;
using CidadeAlta.Domain.Repositories;
using CidadeAlta.Domain.Services;
using CidadeAlta.Domain.ViewModel;
using CidadeAlta.Security.Helper;

namespace CidadeAlta.Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthenticationService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public string AthenticateUser(LoginViewModel loginViewModel)
        {
            var user = _userRepository.Find(loginViewModel.UserName);

            if (user != null && ValidateCredentials(loginViewModel, user))
            {
                return _jwtService.GenerateToken(user);
            }

            return null;
        }

        /// <summary>
        /// Validate a user credentials,
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        private bool ValidateCredentials(LoginViewModel loginViewModel, User user)
        {
            if (user == null)
            {
                return false;
            }

            return PasswordHelper.IsPasswordValid(loginViewModel.Password, user.Password);
        }        
    }
}
