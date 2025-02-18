using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_project1.Models
{
    public class Product
    {
        public string? Name { get; set; }

        //maybe private setters
        public int Id { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public double? Price {  get; set; } 

        public string? Display 
        {  
            get
            {
                return $"{Id}. {Name}\t\tPrice: {Price}\t\tQuantity = {Quantity}";
            }
        }
        public Product()
        {
            Name = string.Empty;
            Price = 0;
            Description = string.Empty;
            Quantity = 0;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }

    }
}
