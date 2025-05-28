using product_api_dotnet_DanielChavez.DTOs;
using product_api_dotnet_DanielChavez.Models.DB;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace product_api_dotnet_DanielChavez.Data
{
    public class ProductData
    {
        //Variable de contexto para acceder a la base de datos
        private PruebaApiContext _context;
        public ProductData()
        {
            //Inicializamos el contexto de la base de datos
            _context = new PruebaApiContext();
        }
        /// <summary>
        ///     Este metodo nos permite obtener todos los productos de la base de datos
        /// </summary>
        /// <returns>
        ///      El valor de retorno es un objeto de tipo RespuestaDTO que contiene el codigo, mensaje y los datos de los productos obtenidos.
        /// </returns>
        public RespuestaDTO GetProducts()
        {
            //Variable de respuesta
            RespuestaDTO respuesta = new RespuestaDTO();
            try
            {
                //Obtenemos los productos de la base de datos
                var products = _context.Products.ToList();
                if (products != null && products.Count > 0)
                {
                    respuesta.Codigo = "1";
                    respuesta.Mensaje = "Productos obtenidos correctamente.";
                    respuesta.Data = products;
                }
                else
                {
                    respuesta.Codigo = "0";
                    respuesta.Mensaje = "No se encontraron productos.";
                    respuesta.Data = null;
                }
            }
            catch (Exception ex)
            {
                //En caso de error, asignamos el mensaje de error
                respuesta.Data = null;
                respuesta.Codigo = "-1";
                respuesta.Mensaje = "Error al obtener los productos: " + ex.Message;
            }
            return respuesta;
        }

        /// <summary>
        ///     Este m[etodo nos permite obtener un producto por su id
        /// </summary>
        /// <param name="id"> Este parametro seria el id del producto </param>
        /// <returns> El valor de retorno es un tipo RespuestaDTO que contiene el codigo de estatus de ejecucion, el mensaje del resultado de 
        ///  la ejecucion y el data o el objeto de retorno buscado por el id.
        /// </returns>

        public RespuestaDTO GetProductById(int id)
        {
            //Variable de respuesta
            RespuestaDTO respuesta = new RespuestaDTO();
            try
            {
                //Obtenemos el producto por id
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    respuesta.Codigo = "1";
                    respuesta.Mensaje = "Producto obtenido correctamente.";
                    respuesta.Data = product;
                }
                else
                {
                    respuesta.Codigo = "0";
                    respuesta.Mensaje = "Producto no encontrado.";
                    respuesta.Data = null;
                }
            }
            catch (Exception ex)
            {
                //En caso de error, asignamos el mensaje de error
                respuesta.Data = null;
                respuesta.Codigo = "-1";
                respuesta.Mensaje = "Error al obtener el producto: " + ex.Message;
            }
            return respuesta;
        }
    }
}
