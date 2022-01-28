using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WsVentas.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string logEmail { get; set; }
        [Required]
        public string logPassword { get; set; }


    }
}
