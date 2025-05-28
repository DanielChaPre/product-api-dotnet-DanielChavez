using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using product_api_dotnet_DanielChavez.Data;

namespace product_api_dotnet_DanielChavez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Variable de acceso a datos (Capa de datos)
        private ProductData _data;
        public ProductController()
        {
            // Inicializamos la clase de acceso a datos
            _data = new ProductData();
        }

        /// <summary>
        ///     Este metodo nos permite obtener todos los productos de la base de datos
        /// </summary>
        /// <returns>
        ///     El valor de retorno es un objeto de tipo IActionResult que mostraria el estatus de la respuesta HTTP.
        /// </returns>
        [HttpGet]
        [Route("products")]
        public IActionResult GetProducts()
        {
            // Llamamos al método de acceso a datos para obtener los productos
            var respuesta = _data.GetProducts();
            if (respuesta.Codigo == "1")
            {
                return Ok(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }


        /// <summary>
        ///     Este metodo nos permite obtener un producto por su id
        /// </summary>
        /// <param name="id"> Este parametro contiene el id del producto a buscar, este valor es ingresado por el usuario </param>
        /// <returns>
        ///     El valor de retorno es un objeto de tipo IActionResult que mostraria el estatus de la respuesta HTTP.
        /// </returns>
        [HttpGet]
        [Route("product/{id}")]
        public IActionResult GetProduct(int id)
        {
            // Llamamos al método de acceso a datos para obtener un producto por su ID
            var respuesta = _data.GetProductById(id);
            if (respuesta.Codigo == "1")
            {
                return Ok(respuesta);
            }
            else if (respuesta.Codigo == "0")
            {
                return NotFound(respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }
    }
}
