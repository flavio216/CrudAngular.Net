using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WsVentas.Models;
using WsVentas.Models.Request;
using WsVentas.Services;

namespace WsVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;  // Injectamos
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();

            var userresponse = _loginService.Auth(model);

            if (userresponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = " Usuario o contraseña incorrecta";
                return BadRequest(); // Manda un error de navegador error 400
            }

            respuesta.Exito = 1;
            respuesta.Data = userresponse;
            return Ok(respuesta);
        }
    }
}
