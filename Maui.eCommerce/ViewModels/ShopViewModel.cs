using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class ShopViewModel
    {
        public List<Product?> Cart {
            get {
                return _svc.Cart;
            } 
        }

        private CartServiceProxy _svc = CartServiceProxy.Current;
    }


}
