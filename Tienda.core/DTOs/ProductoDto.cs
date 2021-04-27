using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.core.DTOs
{
    public class ProductoDto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double? Precio { get; set; }
        public string Descripcion { get; set; }
    }
}
