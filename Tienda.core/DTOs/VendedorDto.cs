using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.core.DTOs
{
    public class VendedorDto
    {
        public int IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FecharContratado { get; set; }
    }
}
