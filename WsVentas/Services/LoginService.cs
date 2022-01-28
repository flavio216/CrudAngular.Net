using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WsVentas.Models;
using WsVentas.Models.Common;
using WsVentas.Models.Request;
using WsVentas.Models.Response;
using WsVentas.Tools;

namespace WsVentas.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppSettings _appSettings;

        public LoginService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        LoginResponse loginResponse = new LoginResponse();
        public LoginResponse Auth(AuthRequest model)
        {
            using (var db = new PalacioSAContext())
            {
                string spassword = Encrypt.GetHA256(model.logPassword);

                var usuario = db.Logins.Where(d => d.LogEmail == model.logEmail &&
                                                   d.LogPassword == spassword).FirstOrDefault();
                if (usuario == null) return null;

                loginResponse.Email = usuario.LogEmail;
                loginResponse.Token = GenerarToken(usuario);
            }

            return loginResponse;
        }
        private string GenerarToken(Login usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.LogId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, usuario.LogEmail.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); 
            return tokenHandler.WriteToken(token);
        }
    }

   
}
