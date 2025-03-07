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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
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

        public int Selected { get;  set;}
        public Product? ProductSelected { get; set; }

        public Product? Delete()
        {
            var item = _svc.Remove(ProductSelected ?? null);
            NotifyPropertyChanged("Products");
            return item; 
        }

    }
}
