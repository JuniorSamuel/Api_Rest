using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.core.Entidades;
using Tienda.core.Interfaces;
using Tienda.infrec.Data;

namespace Tienda.infrec.Repositorio
{
    public class HistorialVentasRepo: IHistorialVentasRepo
    {
        private TiendaContext context;
        public HistorialVentasRepo(TiendaContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<HistorialVentasRepo>> GetHistorialVentas()
        {
            var HistorialVentas = await context.HistorialVentas.ToListAsync();
            return (IEnumerable<HistorialVentasRepo>)HistorialVentas;
        }

        public async Task<HistorialVentas> GetProducto(int id)
        {
            var producto = await context.Producto.FirstOrDefaultAsync((System.Linq.Expressions.Expression<Func<HistorialVentas, bool>>)(x => x.IdProducto == id));
            return producto;
        }

        public async Task InsetProducto(HistorialVentas historialVentas)
        {
            context.HistorialVentas.Add(historialVentas);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateProducto(HistorialVentas producto)
        {
            var currentCliente = await GetProducto(producto.IdProducto);
            currentCliente.Nombre = producto.Nombre;
            currentCliente.Descripcion = producto.Descripcion;
            currentCliente.Precio = producto.Precio;

            int filas = await context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var currentProducto = await GetProducto(id);
            context.Producto.Remove(currentProducto);

            int filas = await context.SaveChangesAsync();
            return filas > 0;
        }

    }
}
