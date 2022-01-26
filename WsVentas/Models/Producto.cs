using System;
using System.Collections.Generic;

#nullable disable

namespace WsVentas.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int PrdId { get; set; }
        public string PrdNombre { get; set; }
        public decimal? PrdPrecioUnitario { get; set; }
        public decimal? PrdCosto { get; set; }

        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}
