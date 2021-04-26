using System;
using System.Collections.Generic;

namespace Tienda.core.Entidades
{
    public partial class HistorialVentas
    {
        public int IdHistorial { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdProducto { get; set; }
        public DateTime? Fecha { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Producto IdProductoNavigation { get; set; }
        public Vendedor IdVendedorNavigation { get; set; }
    }
}
