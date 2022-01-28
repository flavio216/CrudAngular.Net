using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WsVentas.Models;
using WsVentas.Models.Request;
using WsVentas.Models.Response;

namespace WsVentas.Services
{
    public interface ILoginService
    {
        LoginResponse Auth(AuthRequest model);
    }
}
