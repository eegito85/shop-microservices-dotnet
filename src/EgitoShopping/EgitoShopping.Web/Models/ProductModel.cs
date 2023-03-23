using System.ComponentModel.DataAnnotations;

namespace EgitoShopping.Web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }

        [Display(Name = "Url")]
        public string UrlImage { get; set; }
    }
}
