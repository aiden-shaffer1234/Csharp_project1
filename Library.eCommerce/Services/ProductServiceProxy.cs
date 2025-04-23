using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;
using Library.eCommerce.DTO;
using Library.eCommerce.Models;
using Library.eCommerce.Utilities;
using Newtonsoft.Json;

namespace Library.eCommerce.Services
{
    public class ProductServiceProxy
    {
        //private CartServiceProxy _cartSvc = CartServiceProxy.Current; // Reference

        private static object instanceLock = new Object();
        private ProductServiceProxy() {
            //var productPayload = new WebRequestHandler().Get("/Inventory").Result;
            //Products = JsonConvert.DeserializeObject<List<Item>>(productPayload) ?? new List<Item>();
            Products = new List<Item?>
        {
            new Item{ Product = new ProductDTO{Id = 1, Name ="Product 1", Price = 10}, Id = 1, Quantity = 10},
            new Item{ Product = new ProductDTO{Id = 2, Name ="Product 2", Price = 20}, Id = 2, Quantity = 20},
            new Item{ Product = new ProductDTO{Id = 3, Name ="Product 3", Price = 30}, Id = 3, Quantity = 30}
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

        public Item AddOrUpdate(Item newItem)
        {
            if (newItem.Id == 0)
            {
                newItem.Id = LastKey + 1;
                newItem.Product.Id = newItem.Id;
                Products.Add(newItem);
            } else //watch out
            {
                var oldItem = GetById(newItem.Id);
                if (oldItem != null)
                {
                    var index = Products.IndexOf(oldItem);
                    Products.Remove(oldItem);
                    Products.Insert(index, newItem);
                }
            }

            return newItem;
        }


        //public Item? PurchaseItem(Item item)
        //{
        //    if(item?.Id <= 0 || item == null)
        //    {
        //        return null;
        //    }
        //    var itemToPurchase = GetById(item.Id);
        //    if (itemToPurchase != null && itemToPurchase.Quantity > 0)
        //    {
        //        itemToPurchase.Quantity--;

        //    }

        //    return itemToPurchase;
        //}

        // my delete before i looked at the repo
        //public Item? Remove(Item? product)
        //{
        //    if (product != null)
        //    {
        //        Products.Remove(product);
        //    }

        //    return product;
        //}

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
