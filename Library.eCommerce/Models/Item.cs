using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Csharp_project1.Models;

namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int? Quantity {  get; set; }

        public Item( )
        {
            Id = 0;
            Product = new Product();
            Quantity = 0;
        }

        public override string ToString()
        {
            return Display ?? string.Empty;
        }

        public string? Display
        {
            get
            {
                return Product?.Display ?? string.Empty;
            }
        }
    }
}
