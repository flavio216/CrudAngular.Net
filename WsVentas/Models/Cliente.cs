using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WsVentas.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }
        
        public int cliId { get; set; }
        public string CliNombre { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
