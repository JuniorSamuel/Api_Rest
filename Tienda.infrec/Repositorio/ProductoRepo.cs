using Tienda.core.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Tienda.core.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using Tienda.infrec.Data;
using Microsoft.EntityFrameworkCore;

namespace Tienda.infrastructure.Repositorio
{
    public class ProductoRepo: IProductoRepo
    {
        private TiendaContext context;
        public ProductoRepo(TiendaContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Producto>> GetProducto()
        {
            var productos = await context.Producto.ToListAsync();        
            return productos;
        }

        public async Task<Producto> GetProducto(int id)
        {
            var producto = await context.Producto.FirstOrDefaultAsync(x => x.IdProducto == id);
            return producto;
        }
    }
}
