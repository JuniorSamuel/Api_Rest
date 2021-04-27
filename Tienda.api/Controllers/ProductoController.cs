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

namespace servicioTienda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepo productoRepo;

        public ProductoController(IProductoRepo productoRepo)
        {
            this.productoRepo = productoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducto()
        {
            var productos = await productoRepo.GetProducto();
            var productosDto = productos.Select(x => new ProductoDto
            {
                IdProducto = x.IdProducto,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion,
                Precio = x.Precio
            });
            var respuesta = new ApiRespuesta<IEnumerable<ProductoDto>>(productosDto);
            return Ok(respuesta);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await productoRepo.GetProducto(id);
            var productosDto = new ProductoDto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio
            };

            var respuesta = new ApiRespuesta<ProductoDto>(productosDto);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoDto productosDto)
        {
            var producto = new Producto
            {
                Nombre = productosDto.Nombre,
                Precio = productosDto.Precio,
                Descripcion = productosDto.Descripcion
            };

            await productoRepo.InsetProducto(producto);
            var respuesta = new ApiRespuesta<ProductoDto>(productosDto);
            return Ok(respuesta);
        }

        [HttpPut]
        public async Task<IActionResult> PutProducto(int id, ProductoDto productoDto)
        {
            var producto = new Producto
            {
                IdProducto = productoDto.IdProducto,
                Nombre = productoDto.Nombre,
                Precio = productoDto.Precio,
                Descripcion = productoDto.Descripcion
            };
            producto.IdProducto = id;

            var resultado = await productoRepo.UpdateProducto(producto);
            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var resultado = await productoRepo.DeleteProducto(id);

            var respuesta = new ApiRespuesta<bool>(resultado);
            return Ok(respuesta);
        }        
    }
}
