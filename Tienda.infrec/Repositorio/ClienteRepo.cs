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
    public class ClienteRepo : IClienteRepo
    {
        private TiendaContext context;
        public ClienteRepo(TiendaContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Cliente>> GetCliente()
        {
            var clientes = await context.Cliente.ToListAsync();
            return clientes;
        }

        public async Task<Cliente> GetCliente(int id)
        {
            var cliente = await context.Cliente.FirstOrDefaultAsync(x => x.IdCliente == id);
            return cliente;
        }

        public async Task InsetCliente(Cliente cliente)
        {
            context.Cliente.Add(cliente);
            await context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var currentCliente = await GetCliente(cliente.IdCliente);
            currentCliente.Nombre = cliente.Nombre;
            currentCliente.Apellido = cliente.Apellido;

            int filas = await context.SaveChangesAsync();
            return filas > 0;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var currentProducto = await GetCliente(id);
            context.Cliente.Remove(currentProducto);

            int filas = await context.SaveChangesAsync();
            return filas > 0;
        }
    }
}
