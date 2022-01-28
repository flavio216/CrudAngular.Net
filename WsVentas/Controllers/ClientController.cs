using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WsVentas.Models;
namespace WsVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetClients()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PalacioSAContext db = new PalacioSAContext())
                {

                    var lst = db.Clientes.OrderByDescending(d => d.CliId).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }

        [HttpPost]
        public IActionResult AgregarCliente(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PalacioSAContext db = new PalacioSAContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.cliNombre = oModel.cliNombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult EditarCliente(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PalacioSAContext db = new PalacioSAContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.cliId);
                    oCliente.cliNombre = oModel.cliNombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpDelete]
        public IActionResult EliminarCliente(int cliId)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PalacioSAContext db = new PalacioSAContext())
                {
                    Cliente oCliente = db.Clientes.Find(cliId);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {

                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
