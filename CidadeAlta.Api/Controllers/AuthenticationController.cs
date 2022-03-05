using CidadeAlta.Domain.DTO;
using CidadeAlta.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace CidadeAlta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [SwaggerResponse(StatusCodes.Status200OK, "JWT Bearer Token", typeof(string))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult Authenticate(LoginDTO loginViewModel)
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
