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

        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubstringName()
        {
            if (Name.Length < 24) return Name;
            return $"{Name.Substring(0, 21)} ...";
        }

        public string SubstringDescription()
        {
            if (Description.Length < 355) return Description;
            return $"{Description.Substring(0, 352)} ...";
        }
    }
}
