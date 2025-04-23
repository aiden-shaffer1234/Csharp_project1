using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.DTO;

namespace Csharp_project1.Models
{
    public class Product
    {
        public string? Name { get; set; }

        //maybe private setters
        public int Id { get; set; }
        public double Price {  get; set; } 

        public string? Display 
        {  
            get
            {
                return $"{Id}.\t{Name}";
            }
        }
        public Product()
        {
            Name = string.Empty;
            Price = 0;
        }

        public Product(Product copy)
        {
            Id = copy.Id;
            Name = copy.Name;
            Price = copy.Price;
        }

        public Product(ProductDTO copy)
        {
            Id = copy.Id;
            Name = copy.Name;
            Price = copy.Price;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }

    }
}
