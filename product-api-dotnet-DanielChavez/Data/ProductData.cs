using product_api_dotnet_DanielChavez.Models.DB;

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


    }
}
