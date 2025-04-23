using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.eCommerce.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{
    public class CheckOutViewModel
    {
        private CartServiceProxy _svcCart = CartServiceProxy.Current;
        public List<Item> Cart {
            get
            {
                return _svcCart.Cart;
            }
        }

        public double TotalCost
        {
            get
            {
               return _svcCart.getTotalPrice();
            }
        }

        public CheckOutViewModel() 
        {
            
        }

        //public void CalculatePrice()
        //{
        //    TotalCost = _svcCart.getTotalPrice();
        //}

        public void CheckOut()
        {
            _svcCart.checkOut();
        }
    }
}
