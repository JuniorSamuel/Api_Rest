using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tienda.core.Entidades;

namespace Tienda.core.Interfaces
{
    public interface IClienteRepo
    {
        Task<IEnumerable<Cliente>> GetCliente();
        Task<Cliente> GetCliente(int id);
        Task InsetCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(int id);

    }
}
