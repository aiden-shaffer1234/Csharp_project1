using System.ComponentModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using Csharp_project1.Models;
using Library.eCommerce.Services;

namespace Maui.eCommerce.ViewModels
{ 
    public class InventoryManagementViewModel : INotifyPropertyChanged
    {

        private ProductServiceProxy _svc = ProductServiceProxy.Current; // Reference

        public event PropertyChangedEventHandler? PropertyChanged;
        public int Selected { get; set; }
        public Product? SelectedProduct { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged is null)
            {
                throw new ArgumentNullException(nameof(PropertyChanged));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Product?> Products
        {
            get
            {
                return _svc.Products;
            }
        }

        public Product? Delete()
        {
            var item = _svc.Remove(SelectedProduct ?? null);
            NotifyPropertyChanged("Products");
            return item; 
        }

    }
}
