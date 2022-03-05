using AutoMapper;
using CidadeAlta.Domain.DTO;
using CidadeAlta.Domain.Filters;
using CidadeAlta.Domain.Repositories;
using CidadeAlta.Domain.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace CidadeAlta.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CriminalCodeController : ControllerBase
    {
        private readonly ICriminalCodeRepository _criminalCodeRepository;
        private readonly IMapper _mapper;

        public CriminalCodeController(ICriminalCodeRepository criminalCodeRepository, IMapper mapper)
        {
            _criminalCodeRepository = criminalCodeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a paged list of Criminal Codes
        /// </summary>
        /// <param name="page"></param>
        /// <param name="paginationSize"></param>
        /// <param name="criminalCodesFilter"></param>
        /// <returns></returns>
        [HttpPost("GetCriminalCodes")]
        [SwaggerResponse(StatusCodes.Status200OK, "Paged List of Criminal Codes", typeof(IEnumerable<CriminalCodeViewModel>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult GetCriminalCodes(int page, int paginationSize, CriminalCodesFilter criminalCodesFilter)
        {
            var criminalCodes =_criminalCodeRepository.Get(page, paginationSize, criminalCodesFilter);

            if (criminalCodes.Count().Equals(0))
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<CriminalCodeViewModel>>(criminalCodes));
        }

        /// <summary>
        /// Inserts a Criminal Code
        /// </summary>
        /// <param name="criminalCodeViewModel"></param>
        /// <returns></returns>
        [HttpPost("InsertCriminalCode")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult InsertCriminalCode(CriminalCodeDTO criminalCodeViewModel)
        {
            var userId = GetUserId();
            if (userId != 0)
            {
                _criminalCodeRepository.Insert(criminalCodeViewModel, userId);
                return Ok();
            }

            return Unauthorized();
        }

        /// <summary>
        /// Deletes a Criminal Code
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCriminalCode/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult DeleteCriminalCode(int id)
        {
             _criminalCodeRepository.Delete(id);

            return Ok();
        }

        /// <summary>
        /// Updates a Criminal Code
        /// </summary>
        /// <param name="criminalCodeViewModel"></param>
        /// <returns></returns>
        [HttpPatch("UpdateCriminalCode")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(OkResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult UpdateCriminalCode(CriminalCodeDTO criminalCodeViewModel)
        {
            var userId = GetUserId();
            if (userId != 0)
            {
                _criminalCodeRepository.Update(criminalCodeViewModel, userId);
                return Ok();
            }           

            return Unauthorized();
        }

        /// <summary>
        /// Return a Criminal Code by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetCriminalCode/{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Criminal Code", typeof(CriminalCodeViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Type = typeof(UnauthorizedResult))]
        public IActionResult GetCriminalCode(int id)
        {
            var criminalCode = _criminalCodeRepository.Find(id, new string[] { "Status" });

            if (criminalCode == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CriminalCodeViewModel>(criminalCode));
        }

        /// <summary>
        /// Gets logged in user id
        /// </summary>
        /// <returns></returns>
        private int GetUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var claims = identity.Claims;
                var userId = claims.Where(c => c.Type == "UserId").Select(c => c.Value).FirstOrDefault();
                return int.Parse(userId);
            }

            return 0;
        }
    }
}
