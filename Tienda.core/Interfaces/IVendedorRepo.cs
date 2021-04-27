using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.core.Entidades;

namespace Tienda.core.Interfaces
{
    public interface IVendedorRepo
    {
        Task<IEnumerable<Vendedor>> GetVendedor();
        Task<Vendedor> GetProducto(int id);
        Task InsetVendedor(Vendedor vendedor);
        Task<bool> UpdateVendedor(Vendedor vendedor);
        Task<bool> DeleteVendedor(int id);
    }
}
