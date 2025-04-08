using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;
using Library.eCommerce.Models;

namespace Library.eCommerce.Services
{
    public class CartServiceProxy
    {
        private CartServiceProxy() {
            items = new List<Item?>
            {
                new Item{ Product = new Product{Id = 1, Name ="Product 1"}, Id = 1, Quantity = 10},
                new Item{ Product = new Product{Id = 2, Name ="Product 2"}, Id = 2, Quantity = 20},
                new Item{ Product = new Product{Id = 3, Name ="Product 3"}, Id = 3, Quantity = 30}
            };
        }

        private static CartServiceProxy? instance;
        private static ProductServiceProxy? _prodSvc; // left off
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

        private List<Item?> items;

        public List<Item?> Cart { 
            get 
            {
                return items;
            }
        }

        public Item? AddToCart(Item? item)
        {

            if (item != null && item.Id != 0)
            {
                var clonedProduct = new Item
                {
                    Id = item.Id,
                    Product = item.Product,
                    Quantity = item.Quantity
                };
                Cart.Add(clonedProduct);
            }

            return item;
        }

        public Item? RemoveFromCart(Item? product)
        {

            if (product != null)
            {
                var selectedProd = Cart.FirstOrDefault(p => p.Id == product.Id);
                Cart.Remove(selectedProd);
            }

            return product;
        }

        public double checkOut()
        {
            double checkOut = 0;
            var inventory = ProductServiceProxy.Current.Products;
            foreach (var item in Cart)
            {

            }
            Cart.Clear();
            checkOut *= 1.07;
            
            return checkOut;
        }
    }
}
