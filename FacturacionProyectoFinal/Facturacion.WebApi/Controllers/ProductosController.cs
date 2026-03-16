using Facturacion.Application.Interfaces.Productos;
using Microsoft.AspNetCore.Http;
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

        // GET api/producto
        [HttpGet]
        public async Task<IActionResult> ObtenerProductos()
        {
            var productos = await _productoService.ObtenerProductosAsync();
            return Ok(productos);
        }
    }
}
