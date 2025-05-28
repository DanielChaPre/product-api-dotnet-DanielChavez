using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using product_api_dotnet_DanielChavez.Data;
using product_api_dotnet_DanielChavez.DTOs;

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
        [Route("products/{id}")]
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
        /// <summary>
        ///     Este metodo nos permite comunicar con el metodo en Data para crear un nuevo producto
        /// </summary>
        /// <param name="product"> este parametro contendra la informacion para crear un nuevo producto </param>
        /// <returns> El valor de retorno es un objeto de tipo IActionResult que mostraria el estatus de la respuesta HTTP. </returns>
        [HttpPost]
        [Route("products")]
        public IActionResult CreateProduct([FromBody] ProductDTO product)
        {
            // Validamos si el modelo es válido
            if (product == null)
            {
                return BadRequest(new { Codigo = "0", Mensaje = "Producto no puede ser nulo." });
            }
            // Llamamos al método de acceso a datos para crear un nuevo producto
            var respuesta = _data.CreateProduct(product);
            if (respuesta.Codigo == "1")
            {
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, respuesta);
            }
            else
            {
                return BadRequest(respuesta);
            }
        }
    }
}
