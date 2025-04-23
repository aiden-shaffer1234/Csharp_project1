using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Csharp_project1.Models;
using Library.eCommerce.DTO;
using Library.eCommerce.Services;


namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int? Quantity {  get; set; }

        public Item( )
        {
            Id = 0;
            Product = new ProductDTO();
            Quantity = 0;
        }

        //private void DoAdd ()
        //{
        //    CartServiceProxy.Current.AddOrUpdate(this);
        //}
        public Item(Item copy)
        {
            Id = copy.Id;
            Product = new ProductDTO(copy.Product);
            Quantity = copy.Id;
        }


        public string? Display
        {
            get
            {
                return $"{Product?.Display ?? string.Empty} \t Quantity:{Quantity}\t Price:{Product?.Price}";
            }
        }


        public override string ToString()
        {
            return $"{Product} \t Quantity:{Quantity}";
        }


    }
}
