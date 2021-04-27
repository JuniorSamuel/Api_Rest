using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.core.Entidades;

namespace Tienda.core.Interfaces
{
    public interface IHistorialVentasRepo
    {
        Task<IEnumerable<IHistorialVentasRepo>> GetHistorialVentas();
        Task<IHistorialVentasRepo> GetHistorialVentas(int id);
        Task InsetHistorialVentas(HistorialVentas historialVentas);
        Task<bool> UpdateHistorialVentas(HistorialVentas historialVentas);
        Task<bool> DeleteHistorialVentas(int id);
    }
}
