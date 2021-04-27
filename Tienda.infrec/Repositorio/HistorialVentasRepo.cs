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
        public async Task<IEnumerable<HistorialVentas>> GetHistorialVentas()
        {
            var HistorialVentas = await context.HistorialVentas.ToListAsync();
            return (IEnumerable<HistorialVentas>)HistorialVentas;
        }

        public async Task<HistorialVentas> GetHistorialVentas(int id)
        {
            var historialVentas = await context.HistorialVentas.FirstOrDefaultAsync(x => x.IdHistorial == id);
            return historialVentas;
        }

        public async Task InsetHistorialVentas(HistorialVentas historialVentas)
        {
            context.HistorialVentas.Add(historialVentas);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateHistorialVentas(HistorialVentas historialVentas)
        {
            var currentCliente = await GetHistorialVentas(historialVentas.IdHistorial);
            currentCliente.IdCliente = historialVentas.IdCliente;
            currentCliente.IdVendedor = historialVentas.IdVendedor;
            currentCliente.IdProducto = historialVentas.IdProducto;
            currentCliente.Fecha = historialVentas.Fecha;

            int filas = await context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> DeleteHistorialVentas(int id)
        {
            var currentHistorialVentas = await GetHistorialVentas(id);
            context.HistorialVentas.Remove(currentHistorialVentas);

            int filas = await context.SaveChangesAsync();
            return filas > 0;
        }

    }
}
