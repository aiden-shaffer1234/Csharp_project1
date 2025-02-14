using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;

namespace Library.eCommerce.Services
{
    public class CartServiceProxy
    {
        private CartServiceProxy() { }
        private static CartServiceProxy? instance;
        private static object instanceLock = new Object();

        public static CartServiceProxy Current
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CartServiceProxy();
                    }
                  
                }
                return instance;
            }
        }

        public List<Product?> Cart { get; private set; }

        public Product? AddToCart(Product? product)
        {

            if (product != null && product.Id != 0)
            {
                Cart.Add(product);
            }

            return product;
        }

        public Product? RemoveFromCart(Product? product)
        {

            if (product != null)
            {
                Cart.Remove(product);
            }

            return product;
        }

        public double checkOut()
        {

            double checkOut = 0;
            foreach (var item in Cart)
            {
                checkOut += item?.Price ?? 0;
            }
            checkOut *= 1.07;
            
            return checkOut;
        }





    }
}
