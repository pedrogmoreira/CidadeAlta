using CidadeAlta.Domain.DTO;
using CidadeAlta.Domain.Entities;
using CidadeAlta.Domain.Repositories;
using CidadeAlta.Domain.Services;
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

        /// <summary>
        /// Authenticates a User
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        public string AthenticateUser(LoginDTO loginViewModel)
        {
            var user = _userRepository.Find(loginViewModel.UserName);

            if (user != null && ValidateCredentials(loginViewModel, user))
            {
                return _jwtService.GenerateToken(user);
            }

            return null;
        }

        /// <summary>
        /// Validates a user credentials
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool ValidateCredentials(LoginDTO loginViewModel, User user)
        {
            if (user == null)
            {
                return false;
            }

            return PasswordHelper.IsPasswordValid(loginViewModel.Password, user.Password);
        }        
    }
}
