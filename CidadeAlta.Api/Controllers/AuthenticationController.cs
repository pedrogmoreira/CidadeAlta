using CidadeAlta.Domain.Services;
using CidadeAlta.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CidadeAlta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(LoginViewModel loginViewModel)
        {
            var jwtToken = _authenticationService.AthenticateUser(loginViewModel);
            if (jwtToken == null)
            {
                return Unauthorized();
            }

            return Ok(jwtToken);
        }
    }
}
