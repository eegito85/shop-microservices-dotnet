namespace EgitoShopping.Product.Application.DTOs
{
    public class ProdutoDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string UrlImage { get; set; }
    }
}
