using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.api.Respuestas;
using Tienda.core.DTOs;
using Tienda.core.Entidades;
using Tienda.core.Interfaces;
using Tienda.infrec.Repositorio;

namespace Tienda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepo clienteRepo;

        public ClienteController(IClienteRepo clienteRepo)
        {
            this.clienteRepo = clienteRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            var clientes = await clienteRepo.GetCliente();
            var clienteDto = clientes.Select(x => new ClienteDto
            {
                IdCliente = x.IdCliente,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            });
            var respuesta = new ApiRespuesta<IEnumerable<ClienteDto>>(clienteDto);
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await clienteRepo.GetCliente(id);
            var productosDto = new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido
            };

            var respuesta = new ApiRespuesta<ClienteDto>(productosDto);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {             
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
            };

            await clienteRepo.InsetCliente(cliente);
            var respuesta = new ApiRespuesta<ClienteDto>(clienteDto);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente(int id, ClienteDto ClienteDto)
        {
            var cliente = new Cliente
            {
                IdCliente = ClienteDto.IdCliente,
                Nombre = ClienteDto.Nombre,
                Apellido = ClienteDto.Apellido
            };
            ClienteDto.IdCliente = id;

            var resultado = await clienteRepo.UpdateCliente(cliente);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecliente(int id)
        {
            var resultado = await clienteRepo.DeleteCliente(id);

            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }
    }
}
