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
        private CartServiceProxy() {
            Cart = new List<Product?>();
        }
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

        public Product? AddToCart(Product? product, int quantity)
        {

            if (product != null && product.Id != 0)
            {
                var clonedProduct = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = quantity
                };
                Cart.Add(clonedProduct);
            }

            return product;
        }

        public Product? RemoveFromCart(Product? product)
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
                if (item != null)
                {
                    var inventoryItem = inventory.FirstOrDefault(p => p?.Id == item.Id);
                    if (inventoryItem != null && item.Quantity <= inventoryItem.Quantity)
                    {
                        inventoryItem.Quantity -= item.Quantity;
                        checkOut += item.Price ?? 0;
                    }
                }
            }
            Cart.Clear();
            checkOut *= 1.07;
            
            return checkOut;
        }
    }
}
