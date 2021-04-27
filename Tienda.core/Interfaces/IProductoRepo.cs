using System.Collections.Generic;
using System.Threading.Tasks;
using Tienda.core.Entidades;

namespace Tienda.core.Interfaces
{
    public interface IProductoRepo
    {
        Task<IEnumerable<Producto>> GetProducto();
        Task<Producto> GetProducto(int id);
        Task InsetProducto(Producto cliente);
        Task<bool> UpdateProducto(Producto producto);
        Task<bool> DeleteProducto(int id);
    }
}
