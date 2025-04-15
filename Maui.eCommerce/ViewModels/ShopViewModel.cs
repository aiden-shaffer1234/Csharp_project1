using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;
using Library.eCommerce.Models;
using Library.eCommerce.Services;
using Microsoft.Maui.Controls.Handlers.Items;

namespace Maui.eCommerce.ViewModels
{
    public class ShopViewModel : INotifyPropertyChanged
    {
        private CartServiceProxy _svcCart = CartServiceProxy.Current;
        private ProductServiceProxy _svcItem = ProductServiceProxy.Current;

        public Item? SelectedInventoryItem { get; set; }
        public Item? SelectedCartItem { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Item?> Cart {
            get {
                return new ObservableCollection<Item?>(_svcCart.Cart.Where(p => p?.Quantity > 0));
            } 
        }

        public ObservableCollection<Item?> Inventory
        {
            get
            {
                return new ObservableCollection<Item?>(_svcItem.Products.Where(p => p?.Quantity > 0));
            }
        }

        public void PurchaseItem()
        {
            if (SelectedInventoryItem != null)
            {
                var shouldRefresh = SelectedInventoryItem.Quantity >= 1;
                var updatedItem = _svcCart.AddOrUpdate(SelectedInventoryItem); 
                
                if (updatedItem != null && shouldRefresh)
                {
                    NotifyPropertyChanged(nameof(Inventory));
                    NotifyPropertyChanged(nameof(Cart));
                }

            }
 
        }

        public void ReturnItem()
        {
            if (SelectedCartItem != null)
            {
                var shouldRefresh = SelectedCartItem.Quantity >= 1;
                var updatedItem = _svcCart.ReturnItem(SelectedCartItem); //issue

                if (updatedItem != null && shouldRefresh)
                {
                    NotifyPropertyChanged(nameof(Inventory));
                    NotifyPropertyChanged(nameof(Cart));
                }

            }

        }


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is null)
            {
                throw new ArgumentNullException(nameof(PropertyChanged));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public Item? Delete()
        //{
        //    var item = _svcCart.RemoveFromCart(SelectedInventoryItem ?? null);
        //    NotifyPropertyChanged("Cart");
        //    return item;
        //}
    }
}
