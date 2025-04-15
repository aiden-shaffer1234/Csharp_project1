using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Csharp_project1.Models;
using Library.eCommerce.DTO;


namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int? Quantity {  get; set; }

        public ICommand? AddCommand { get; set; }

        public Item( )
        {
            Id = 0;
            Product = new ProductDTO();
            Quantity = 0;
            AddCommand = null;
        }

        private void DoAdd ()
        {

        }
        public Item(Item copy)
        {
            Id = copy.Id;
            Product = new ProductDTO(copy.Product);
            Quantity = copy.Id;
            //AddCommand = new Command(DoAdd);
        }


        //public override string ToString()
        //{
        //    return $"{Product} \t Quantity:{Quantity}";
        //}

        public string? Display
        {
            get
            {
                return $"{Product?.Display ?? string.Empty} \t Quantity:{Quantity}";
            }
        }
    }
}
