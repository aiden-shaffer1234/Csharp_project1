using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;

namespace Library.eCommerce.Services
{
    public class ProductServiceProxy
    {
        private int lastKey;
        private static object instanceLock = new Object();
        private ProductServiceProxy( ) {
            Products = new List<Product?>();
            lastKey = 1;
        }
        private static ProductServiceProxy? instance;
        public static ProductServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductServiceProxy();
                    }
                }

                return instance;
            }
        }
        public List<Product?> Products { get; private set; } // => is the same as products with only a get 

        public Product AddOrUpdateProduct(Product product)
        {
            if (product.Id == 0)
            {
                product.Id = lastKey++;
                Products.Add( product );
            }

            return product;
        }
        public Product? Remove(Product? product)
        {
            if (product != null)
            {
                Products.Remove(product);
            }

            return product;
        }
    }
}
