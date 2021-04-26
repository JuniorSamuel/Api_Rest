using System;
using System.Collections.Generic;

namespace Tienda.core.Entidades
{
    public partial class Producto
    {
        public Producto()
        {
            HistorialVentas = new HashSet<HistorialVentas>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double? Precio { get; set; }
        public string Descripcion { get; set; }

        public ICollection<HistorialVentas> HistorialVentas { get; set; }
    }
}
