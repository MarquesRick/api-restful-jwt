using System;
using System.Net;
using System.Threading.Tasks;
using APINucleo.Domain.Entities;
using APINucleo.Domain.Interfaces.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginController()
        {

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] NucleoUsuario loginDto, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (loginDto == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await service.FindByLogin(loginDto.Email, loginDto.Senha);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }
}
