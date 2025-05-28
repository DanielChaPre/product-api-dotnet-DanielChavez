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
    }
}
