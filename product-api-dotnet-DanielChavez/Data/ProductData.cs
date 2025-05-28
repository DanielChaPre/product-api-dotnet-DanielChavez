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

        /// <summary>
        ///     En este metodo se creara un nuevo producto en la base de datos
        /// </summary>
        /// <param name="item"> item es de tipo ProductDTO, este parametro almacena los valores para el registro de un nuevo producto </param>
        /// <returns> El valor de retorno es un tipo RespuestaDTO, el cual mostrara principalmente el codigo y mensaje de la ejecucion del metodo </returns>
        public RespuestaDTO CreateProduct(ProductDTO item)
        {
            var dato = new RespuestaDTO();
            try
            {
                //Creamos un nuevo producto con los datos del DTO
                var producto = new Product
                {
                    Id = 0,
                    Nombre = item.Nombre,
                    Activo = 1,
                    Precio = item.Precio,
                    Stock = item.Stock,
                };

                //Agregamos el producto al contexto y guardamos los cambios
                _context.Products.Add(producto);
                _context.SaveChanges();

                //Asignamos la respuesta de exito
                dato = new RespuestaDTO
                {
                    Codigo = "1",
                    Mensaje = "El producto se guardo de manera correcta",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                dato = new RespuestaDTO
                {
                    Codigo = "-1",
                    Mensaje = "Error al guardar el producto: " + ex.Message,
                    Data = null
                };
            }
            return dato;
        }

        /// <summary>
        ///     Metodo que nos permite actualizar un producto en la base de datos
        /// </summary>
        /// <param name="id"> es el parametro que utilizaremos para poder buscar e identificar el producto que se modificara </param>
        /// <param name="item"> En este parametro contendra los datos que se modificaran </param>
        /// <returns> se retornara un objeto de tipo RespuestaDTO el cual mostrara el codigo y mensaje indicando si se realizo correctamente 
        ///     la actualizacion del producto o si ocurrio un error durante el proceso.
        /// </returns>
        public RespuestaDTO UpdateProduct(int id, ProductDTO item)
        {
            var dato = new RespuestaDTO();
            try
            {
                //Buscamos el producto por id
                var productBD = (Product)GetProductById(id).Data;
                if (productBD != null)
                {
                    //Actualizamos los campos del producto
                    productBD.Activo = (item.Activo = true) ? 1 : 0;
                    productBD.Precio = item.Precio;
                    productBD.Stock = item.Stock;
                    productBD.Nombre = item.Nombre;

                    // Adjuntamos el producto al contexto para marcarlo como modificado
                    _context.Products.Attach(productBD);

                    // Especificamos qué propiedades han sido modificadas
                    _context.Entry(productBD).Property(p => p.Activo).IsModified = true;
                    _context.Entry(productBD).Property(p => p.Precio).IsModified = true;
                    _context.Entry(productBD).Property(p => p.Stock).IsModified = true;
                    _context.Entry(productBD).Property(p => p.Nombre).IsModified = true;

                    // Guardamos los cambios en la base de datos
                    _context.SaveChanges();

                    dato = new RespuestaDTO
                    {
                        Codigo = "1",
                        Mensaje = "Se modifico de manera correcta el producto",
                        Data = null
                    };
                }
                else
                {
                    dato = new RespuestaDTO
                    {
                        Codigo = "0",
                        Mensaje = "No se encontro el producto que se desea modificar",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                dato = new RespuestaDTO
                {
                    Codigo = "-1",
                    Mensaje = "Error al actualizar el producto: " + ex.Message,
                    Data = null
                };
            }
            return dato;
        }

        /// <summary>
        ///     Metodo que nos permite actualizar el estado de un producto en la base de datos
        /// </summary>
        /// <param name="id"> es el parametro que utilizaremos para poder buscar e identificar el producto que se modificara </param>
        /// <returns> se retornara un objeto de tipo RespuestaDTO el cual mostrara el codigo y mensaje indicando si se realizo correctamente 
        ///     la actualizacion del producto o si ocurrio un error durante el proceso.
        /// </returns>
        public RespuestaDTO UpdateStatusProduct(int id)
        {
            var dato = new RespuestaDTO();
            try
            {
                //Buscamos el producto por id
                var productBD = (Product)GetProductById(id).Data;
                if (productBD != null)
                {
                    // Cambiamos el estado del producto (Activo a Inactivo o viceversa)
                    if (productBD.Activo == 1)
                    {
                        productBD.Activo = 0;
                    }
                    else if (productBD.Activo == 0)
                    {
                        productBD.Activo = 1;
                    }
                    // Adjuntamos el producto al contexto para marcarlo como modificado
                    _context.Products.Attach(productBD);

                    // Especificamos qué propiedades han sido modificadas
                    _context.Entry(productBD).Property(p => p.Activo).IsModified = true;

                    // Guardamos los cambios en la base de datos
                    _context.SaveChanges();

                    dato = new RespuestaDTO
                    {
                        Codigo = "1",
                        Mensaje = "Se modifico de manera correcta el producto",
                        Data = null
                    };
                }
                else
                {
                    dato = new RespuestaDTO
                    {
                        Codigo = "0",
                        Mensaje = "No se encontro el producto que se desea modificar",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                dato = new RespuestaDTO
                {
                    Codigo = "-1",
                    Mensaje = "Error al actualizar el estado del producto: " + ex.Message,
                    Data = null
                };
            }
            return dato;
        }

        /// <summary>
        ///     El metodo nos permite eliminar un producto de la base de datos por su id
        /// </summary>
        /// <param name="id"> La variable hace referencia al id del producto  </param>
        /// <returns></returns>
        public RespuestaDTO DeleteProduct(int id)
        {
            var dato = new RespuestaDTO();
            try
            {
                //Buscamos el producto por id
                var productBD = (Product)GetProductById(id).Data;
                if (productBD != null)
                {
                    //Adjuntamos el producto al contexto para marcarlo como eliminado
                    _context.Products.Attach(productBD);
                    // Eliminamos el producto del contexto
                    _context.Products.Remove(productBD);
                    // Guardamos los cambios en la base de datos
                    _context.SaveChanges();
                    dato = new RespuestaDTO
                    {
                        Codigo = "1",
                        Mensaje = "Se elimino de manera correcta el producto",
                        Data = null
                    };
                }
                else
                {
                    dato = new RespuestaDTO
                    {
                        Codigo = "0",
                        Mensaje = "No se encontro el producto que se desea eliminar",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                dato = new RespuestaDTO
                {
                    Codigo = "-1",
                    Mensaje = "Error al eliminar el producto: " + ex.Message,
                    Data = null
                };
            }
            return dato;
        }
    }
}
