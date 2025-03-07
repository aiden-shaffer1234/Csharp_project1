using Csharp_project1.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{ 
    public class InventoryManagementViewModel
    {
        public List<Product?> Products { 
            get
            {
                return ProductServiceProxy.Current.Products;
            } 
        }

    }
}
