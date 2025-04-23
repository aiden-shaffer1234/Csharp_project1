using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using Csharp_project1.Models;
using Library.eCommerce.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{ 
    public class InventoryManagementViewModel : INotifyPropertyChanged
    {

        private ProductServiceProxy _itemSvc = ProductServiceProxy.Current; // Reference


        public event PropertyChangedEventHandler? PropertyChanged;
        public string? Query {  get; set; }
        public int Selected { get; set; }
        public Item? SelectedProduct { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is null)
            {
                throw new ArgumentNullException(nameof(PropertyChanged));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshProductList()
        {
            NotifyPropertyChanged(nameof(Products));
        }

        public ObservableCollection<Item?> Products
        {
            get
            {
                var filteredList = _itemSvc.Products.Where(p => p?.Product?.Name?.ToLower().Contains(Query?.ToLower() ?? string.Empty) ?? false);
                return new ObservableCollection<Item?>(filteredList);
            }
        }

        public Item? Delete()
        {
            var item = _itemSvc.Delete(SelectedProduct?.Id ?? 0);
            NotifyPropertyChanged(nameof(Products));
            return item; 
        }
    }
}
