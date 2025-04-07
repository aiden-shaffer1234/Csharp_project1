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
        private CartServiceProxy _svc = CartServiceProxy.Current;
        public Item? SelectedProduct { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Item?> Cart {
            get {
                return new ObservableCollection<Item?>(_svc.Cart);
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

        public Item? Delete()
        {
            var item = _svc.RemoveFromCart(SelectedProduct ?? null);
            NotifyPropertyChanged("Cart");
            return item;
        }

    }
}
