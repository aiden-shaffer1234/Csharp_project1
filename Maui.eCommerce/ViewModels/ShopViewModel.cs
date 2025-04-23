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

        public ItemViewModel? SelectedInventoryItem { get; set; }
        public ItemViewModel? SelectedCartItem { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<ItemViewModel?> Cart {
            get {
                return new ObservableCollection<ItemViewModel?>(_svcCart.Cart.Where(p => p?.Quantity > 0).Select(m => new ItemViewModel(m)));
            } 
        }

        public ObservableCollection<ItemViewModel?> Inventory
        {
            get
            {
                return new ObservableCollection<ItemViewModel?>(_svcItem.Products.Where(p => p?.Quantity > 0).Select(m => new ItemViewModel(m)));
            }
        }

        public void PurchaseItem()
        {
            if (SelectedInventoryItem != null)
            {
                var shouldRefresh = SelectedInventoryItem.Model.Quantity >= 1;
                var updatedItem = _svcCart.AddOrUpdate(SelectedInventoryItem.Model); 
                
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
                var shouldRefresh = SelectedCartItem.Model.Quantity >= 1;
                var updatedItem = _svcCart.ReturnItem(SelectedCartItem.Model); //issue

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

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Inventory));
            NotifyPropertyChanged(nameof(Cart));
        }
        //public Item? Delete()
        //{
        //    var item = _svcCart.RemoveFromCart(SelectedInventoryItem ?? null);
        //    NotifyPropertyChanged("Cart");
        //    return item;
        //}
    }
}
