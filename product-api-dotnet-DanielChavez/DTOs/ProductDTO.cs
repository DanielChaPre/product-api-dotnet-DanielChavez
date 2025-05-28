namespace product_api_dotnet_DanielChavez.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public bool Activo { get; set; }
    }
}
