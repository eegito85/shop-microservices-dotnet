using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitoShopping.Product.Domain.Entities
{
    public class Produto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set;}
        public string Description { get; set;}
        public string CategoryName { get; set; }
        public string UrlImage { get; set; }
    }
}
