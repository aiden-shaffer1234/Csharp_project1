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
        
        private static object instanceLock = new Object();
        private ProductServiceProxy( ) {
            Products = new List<Product?>
            {
                new Product{Id = 1, Name ="Product 1"},
                new Product{Id = 2, Name ="Product 2"},
                new Product{Id = 3, Name ="Product 3"}
            };
        }

        private int LastKey
        {
            get
            {
                if (!Products.Any())
                {
                    return 0;
                }

                return Products.Select(p => p?.Id ?? 0).Max();
            }
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
                product.Id = LastKey + 1;
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

        public Product? Delete(int id)
        {
            if (id == 0)
            {
                return null;
            }

            Product? prod = Products.FirstOrDefault(p => p.Id == id);
            Products.Remove(prod);

            return prod;
        }

        public Product? GetById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
