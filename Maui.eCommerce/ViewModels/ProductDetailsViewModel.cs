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
        public string? Name {
            get 
            {
                return Model?.Name ?? string.Empty;
            }
            set 
            {
                if (Model != null && Model.Name != value)
                {
                    Model.Name = value;
                }
            } 
        }
        public int? Quantity {
            get
            {
                return Model?.Quantity ?? -1;
            }
            set
            {
                if (Model != null && Model.Quantity != value)
                {
                    Model.Quantity = value;
                }
            }
        }
        public double? Price {
            get
            {
                return Model?.Price ?? -1;
            }
            set
            {
                if (Model != null && Model.Price != value)
                {
                    Model.Price = value;
                }
            }
        }

        public Product? Model { get; set; }

        public ProductDetailsViewModel() 
        { 
            Model = new Product();
        }

        public ProductDetailsViewModel(Product? model)
        {
            Model = model;
        }

        public void AddOrUpdate()
        {
            // DP SOMETHONG TO CONDITION THE UPDATE VS ADD
            _svc.AddOrUpdateProduct(Model);
        }
    }
}
