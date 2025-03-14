using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class ProductDetailsViewModel
    {
        ProductServiceProxy _svc = ProductServiceProxy.Current;
        public string? Name {  get; set; }
        public int? Quantity {  get; set; }
        public int? Price { get; set; }


        public Product? Add()
        {
            Product product = new Product
            {
                Name = this.Name,
                Quantity = this.Quantity,
                Price = this.Price,
            };
            _svc.AddOrUpdateProduct(product);
            return product;
        }
    }
}
