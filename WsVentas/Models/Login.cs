using System;
using System.Collections.Generic;

#nullable disable

namespace WsVentas.Models
{
    public partial class Login
    {
        public int? LogId { get; set; }
        public string LogEmail { get; set; }
        public string LogPassword { get; set; }
        public string LogNombre { get; set; }
    }
}
