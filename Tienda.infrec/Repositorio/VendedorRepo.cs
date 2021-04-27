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
    public class VendedorRepo : IVendedorRepo
    {
        private TiendaContext context;
        public VendedorRepo(TiendaContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Vendedor>> GetVendedor()
        {
            var vendedor = await context.Vendedor.ToListAsync();
            return vendedor;
        }
        public async Task<Vendedor> GetVendedor(int id)
        {
            var vendedor = await context.Vendedor.FirstOrDefaultAsync(x => x.IdVendedor == id);
            return vendedor;
        }

        public  async Task InsetVendedor(Vendedor vendedor)
        {
            context.Vendedor.Add(vendedor);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateVendedor(Vendedor vendedor)
        {
            var currentCliente = await GetVendedor(vendedor.IdVendedor);
            currentCliente.Nombre = vendedor.Nombre;
            currentCliente.Apellido = vendedor.Apellido;
            currentCliente.FecharContratado = vendedor.FecharContratado;

            int filas = await context.SaveChangesAsync();
            return filas > 0;
        }
        public async Task<bool> DeleteVendedor(int id)
        {
            var currentVendedor = await GetVendedor(id);
            context.Vendedor.Remove(currentVendedor);

            int filas = await context.SaveChangesAsync();
            return filas > 0;
        }
    }
}
