using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;
using Library.eCommerce.Models;

namespace Library.eCommerce.Services
{
    public class ProductServiceProxy
    {
        
        private static object instanceLock = new Object();
        private ProductServiceProxy( ) {
            Products = new List<Item?>
            {
                new Item{ Product = new Product{Id = 1, Name ="Product 1"}, Id = 1, Quantity = 10},
                new Item{ Product = new Product{Id = 2, Name ="Product 2"}, Id = 2, Quantity = 20},
                new Item{ Product = new Product{Id = 3, Name ="Product 3"}, Id = 3, Quantity = 30}
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
        public List<Item?> Products { get; private set; } // => is the same as products with only a get 

        public Item AddOrUpdateProduct(Item newItem)
        {
            if (newItem.Id == 0)
            {
                newItem.Id = LastKey + 1;
                newItem.Product.Id = newItem.Id;
                Products.Add(newItem);
            } else //watch out
            {
                var oldItem = GetById(newItem.Id);
                var index = Products.IndexOf(oldItem);
                Products.Remove(oldItem);
                Products.Insert(index, newItem);
            }

            return newItem;
        }

        // my delete before i looked at the repo
        public Item? Remove(Item? product)
        {
            if (product != null)
            {
                Products.Remove(product);
            }

            return product;
        }

        public Item? Delete(int id)
        {
            if (id == 0)
            {
                return null;
            }

            Item? prod = Products.FirstOrDefault(p => p.Id == id);
            Products.Remove(prod);

            return prod;
        }

        public Item? GetById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
