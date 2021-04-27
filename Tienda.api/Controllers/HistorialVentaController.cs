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
    public class HistorialVentaController : ControllerBase
    {

        private readonly IHistorialVentasRepo historialVentasRepo;

        public HistorialVentaController(IHistorialVentasRepo historialVentasRepo)
        {
            this.historialVentasRepo = historialVentasRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistirialVenta()
        {
            var historialVentas = await historialVentasRepo.GetHistorialVentas();
            var historialVentasDto = historialVentas.Select(x => new HistorialVentasDto
            {
                IdHistorial = x.IdHistorial,
                IdCliente = x.IdCliente,
                IdVendedor = x.IdVendedor,
                IdProducto = x.IdProducto,
                Fecha = x.Fecha
            });
            var respuesta = new ApiRespuesta<IEnumerable<HistorialVentasDto>>(historialVentasDto);
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistirialVenta(int id)
        {
            var historialVenta = await historialVentasRepo.GetHistorialVentas(id);
            var historialVentaDto = new HistorialVentasDto
            {
                IdHistorial = historialVenta.IdHistorial,
                IdCliente = historialVenta.IdCliente,
                IdVendedor = historialVenta.IdVendedor,
                IdProducto = historialVenta.IdProducto,
                Fecha = historialVenta.Fecha
            };

            var respuesta = new ApiRespuesta<HistorialVentasDto>(historialVentaDto);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Post(HistorialVentasDto historialVentasDto)
        {
            var historialVenta = new HistorialVentas
            {
                IdHistorial = historialVentasDto.IdHistorial,
                IdCliente = historialVentasDto.IdCliente,
                IdVendedor = historialVentasDto.IdVendedor,
                IdProducto = historialVentasDto.IdProducto,
                Fecha = historialVentasDto.Fecha
            };

            await historialVentasRepo.InsetHistorialVentas(historialVenta);
            var respuesta = new ApiRespuesta<HistorialVentasDto>(historialVentasDto);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PuthistorialVenta(int id, HistorialVentasDto historialVentasDto)
        {
            var historialVenta = new HistorialVentas
            {
                IdHistorial = historialVentasDto.IdHistorial,
                IdCliente = historialVentasDto.IdCliente,
                IdVendedor = historialVentasDto.IdVendedor,
                IdProducto = historialVentasDto.IdProducto,
                Fecha = historialVentasDto.Fecha
            };
            historialVentasDto.IdHistorial = id;

            var resultado = await historialVentasRepo.UpdateHistorialVentas(historialVenta);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialVenta(int id)
        {
            var resultado = await historialVentasRepo.DeleteHistorialVentas(id);

            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }
    }
}
