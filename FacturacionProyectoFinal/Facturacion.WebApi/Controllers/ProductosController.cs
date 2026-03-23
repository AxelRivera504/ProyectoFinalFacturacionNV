using Facturacion.Application.DTOs.Productos;
using Facturacion.Application.Interfaces.Productos;
using Microsoft.AspNetCore.Mvc;

namespace Facturacion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerProductos()
        {
            var productos = await _productoService.ObtenerProductosAsync();
            return Ok(productos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerProductoPorId(int id)
        {
            var productos = await _productoService.ObtenerProductoPorIdAsync(id);
            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] CrearProductoRequestDto crearProductoRequestDto)
        {
            var productos = await _productoService.AgregarAsync(crearProductoRequestDto);
            return Ok(productos);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> ActualizarProducto(int id, [FromBody] EditarProductoRequestDto editarProductoRequestDto)
        {
            var productos = await _productoService.ActualizarAsync(id, editarProductoRequestDto);
            return Ok(productos);
        }
    }
}
