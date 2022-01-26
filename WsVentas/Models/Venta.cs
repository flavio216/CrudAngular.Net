using System;
using System.Collections.Generic;

#nullable disable

namespace WsVentas.Models
{
    public partial class Venta
    {
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int VenId { get; set; }
        public DateTime? VenFecha { get; set; }
        public decimal? VenTotal { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
