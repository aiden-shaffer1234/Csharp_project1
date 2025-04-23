using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;
using Library.eCommerce.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class ProductDetailsViewModel
    {
        ProductServiceProxy _svc = ProductServiceProxy.Current;
        public string? Name {
            get 
            {
                return Model?.Product?.Name ?? string.Empty;
            }
            set 
            {
                if (Model != null && Model.Product.Name != value)
                {
                    Model.Product.Name = value;
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
                return Model?.Product.Price ?? -1;
            }
            set
            {
                if (Model != null && Model.Product.Price != value)
                {
                    Model.Product.Price = value ?? 0;
                }
            }
        }

        public Item? Model { get; set; }
        private Item? cachedModel { get; set; }

        public ProductDetailsViewModel() 
        { 
            Model = new Item();
            cachedModel = null;
        }

        public ProductDetailsViewModel(Item? model)
        {
            Model = model;
            if (model != null)
            {
                cachedModel = new Item(model);
            }
        }

        public void Undo()
        {
            Model = ProductServiceProxy.Current.AddOrUpdate(cachedModel);
        }

        public void AddOrUpdate()
        {
            // DP SOMETHONG TO CONDITION THE UPDATE VS ADD
            _svc.AddOrUpdate(Model);
        }
    }
}
