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
            items = new List<Item?>();
        }

        private static CartServiceProxy? cartInstance;
        private static ProductServiceProxy _prodSvc = ProductServiceProxy.Current; 


        public static CartServiceProxy Current
        {
            get
            {
                if (cartInstance == null)
                {
                    cartInstance = new CartServiceProxy();
                }
                  
                return cartInstance;
            }
        }

        private List<Item?> items;

        public List<Item?> Cart { 
            get 
            {
                return items;
            }
        }

        public Item? AddOrUpdate(Item item)
        {
            var existingInvItem = _prodSvc.GetById(item.Id);
            if (existingInvItem != null && existingInvItem.Quantity > 0)
            {
                existingInvItem.Quantity--;
                var existingItem = Cart.FirstOrDefault(p => p.Id == item.Id);

                if (existingItem == null)
                {
                    var newItem = new Item(item);
                    newItem.Quantity = 1;
                    Cart.Add(newItem);
                }
                else
                {
                    existingItem.Quantity++;
                }
            }

            return existingInvItem;
        }

        public Item? ReturnItem(Item? item)
        {

            if (item?.Id <= 0 || item == null)
            {
                return null;
            }
            var itemToReturn = Cart.FirstOrDefault(i => i.Id == item.Id);
            if (itemToReturn != null && itemToReturn.Quantity > 0)
            {
                itemToReturn.Quantity--;
                
                var inventoryItem = _prodSvc.Products.FirstOrDefault(i => i.Id == item.Id);
                if (inventoryItem != null)
                {
                    inventoryItem.Quantity++;
                } else
                {
                    _prodSvc.AddOrUpdate(new Item(itemToReturn));
                }
            }

            return itemToReturn;
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
