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

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Item?> Cart {
            get {
                return new ObservableCollection<Item?>(_svcCart.Cart);
            } 
        }

        public ObservableCollection<Item?> Inventory
        {
            get
            {
                return new ObservableCollection<Item?>(_svcItem.Products);
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
