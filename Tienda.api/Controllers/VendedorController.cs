using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.core.DTOs;
using Tienda.core.Entidades;
using Tienda.core.Interfaces;
using Tienda.api.Respuestas;

namespace Tienda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {

        private readonly IVendedorRepo vendedorRepo;

        public VendedorController(IVendedorRepo vendedorRepo)
        {
            this.vendedorRepo = vendedorRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetVendedor()
        {
            var vendedores = await vendedorRepo.GetVendedor();
            var vendedoresDto = vendedores.Select(x => new VendedorDto
            {
                IdVendedor = x.IdVendedor,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                FecharContratado = x.FecharContratado
            });
            var respuesta = new ApiRespuesta<IEnumerable<VendedorDto>>(productosDto);
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendedor(int id)
        {
            var vendedor = await vendedorRepo.GetVendedor(id);
            var vendedorDto = new VendedorDto
            {
                IdVendedor = vendedor.IdVendedor,
                Nombre = vendedor.Nombre,
                Apellido = vendedor.Apellido,
                FecharContratado = vendedor.FecharContratado
            };

            var respuesta = new ApiRespuesta<VendedorDto>(productosDto);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> PostVendedor(VendedorDto vendedoresDto)
        {
            var vendedor = new Vendedor
            {
                IdVendedor = vendedoresDto.IdVendedor,
                Nombre = vendedoresDto.Nombre,
                Apellido = vendedoresDto.Apellido,
                FecharContratado = vendedoresDto.FecharContratado
            };

            await vendedorRepo.InsetProducto(vendedor);
            var respuesta = new ApiRespuesta<VendedorDto>(productosDto);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PutVendedor(int id, VendedorDto vendedoresDto)
        {
            var vendedor = new Vendedor
            {
                IdVendedor = vendedoresDto.IdVendedor,
                Nombre = vendedoresDto.Nombre,
                Apellido = vendedoresDto.Apellido,
                FecharContratado = vendedoresDto.FecharContratado
            };
            vendedor.IdProducto = id;

            var resultado = await vendedorRepo.UpdateVendedor(vendedor);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedor(int id)
        {
            var resultado = await vendedorRepo.DeleteVendedor(id);

            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }
    }
}
