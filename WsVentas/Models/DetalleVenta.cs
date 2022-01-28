using System;
using System.Collections.Generic;

#nullable disable

namespace WsVentas.Models
{
    public partial class DetalleVenta
    {
        public int DveId { get; set; }
        public int? DveVenId { get; set; }
        public int? DveCantidad { get; set; }
        public decimal? DvePrecioUnitario { get; set; }
        public decimal? DveImporte { get; set; }
        public int? DvePrdId { get; set; }
        public int? DveCliId { get; set; }

        public virtual Producto DvePrd { get; set; }
        public virtual Venta DveVen { get; set; }
    }
}
