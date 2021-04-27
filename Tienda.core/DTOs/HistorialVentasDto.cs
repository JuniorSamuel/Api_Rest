using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.core.DTOs
{
    public class HistorialVentasDto
    {
        public int IdHistorial { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdProducto { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
