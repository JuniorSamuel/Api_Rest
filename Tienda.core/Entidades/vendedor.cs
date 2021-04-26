using System;
using System.Collections.Generic;

namespace Tienda.core.Entidades
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            HistorialVentas = new HashSet<HistorialVentas>();
        }

        public int IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FecharContratado { get; set; }

        public ICollection<HistorialVentas> HistorialVentas { get; set; }
    }
}
