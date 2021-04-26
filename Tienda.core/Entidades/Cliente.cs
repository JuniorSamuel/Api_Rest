using System;
using System.Collections.Generic;

namespace Tienda.core.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            HistorialVentas = new HashSet<HistorialVentas>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public ICollection<HistorialVentas> HistorialVentas { get; set; }
    }
}
