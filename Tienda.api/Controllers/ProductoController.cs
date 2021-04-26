using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.core.Interfaces;

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
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await productoRepo.GetProducto(id);
            return Ok(producto);
        }
    }
}
