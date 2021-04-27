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
            var historialVentas = await historialVentasRepo.GetHistirialVenta();
            var historialVentasDto = historialVentas.Select(x => new HistorialVentasDto
            {
                IdHistorialVenta = x.IdHistorialVenta,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Precio = x.Precio
            });
            var respuesta = new ApiRespuesta<IEnumerable<HistorialVentasDto>>(historialVentasDto);
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistirialVenta(int id)
        {
            var historialVenta = await historialVentasRepo.GetHistirialVenta(id);
            var historialVentaDto = new HistorialVentasDto
            {
                IdProducto = historialVenta.IdHistorialVenta,
                Nombre = historialVenta.Nombre,
                Descripcion = historialVenta.Descripcion,
                Precio = historialVenta.Precio
            };

            var respuesta = new ApiRespuesta<HistorialVentasDto>(historialVentaDto);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Post(HistorialVentasDto historialVentasDto)
        {
            var historialVenta = new HistorialVentas
            {
                Nombre = historialVentasDto.Nombre,
                Precio = historialVentasDto.Precio,
                Descripcion = historialVentasDto.Descripcion
            };

            await historialVentasRepo.InsetHiistorialVenta(historialVenta);
            var respuesta = new ApiRespuesta<HistorialVentasDto>(historialVentasDto);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PuthistorialVenta(int id, HistorialVentasDto historialVentaDto)
        {
            var historialVenta = new HistorialVentas
            {
                IdHistorialVenta = HistorialVentaDto.IdHistorialVenta,
                Nombre = HistorialVentaDto.Nombre,
                Precio = HistorialVentaDto.Precio,
                Descripcion = HistorialVentaDto.Descripcion
            };
            HistorialVenta.IdHistorialVenta = id;

            var resultado = await historialVentasRepo.UpdateHistorialVenta(historialVenta);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialVenta(int id)
        {
            var resultado = await historialVentasRepo.DeleteHistorialVenta(id);

            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }
    }
}
