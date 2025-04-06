using Csharp_project1.Models;
using Library.eCommerce.Services;
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

[QueryProperty(nameof(ProductId), "productId")]
public partial class ProductDetailsView : ContentPage
{
    public int ProductId { get; set; }
	public ProductDetailsView()
	{
		InitializeComponent();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ProductDetailsViewModel)?.AddOrUpdate();
        //var name = (BindingContext as ProductDetailsViewModel)?.Name;
        //var quant = (BindingContext as ProductDetailsViewModel)?.Quantity;
        //var price = (BindingContext as ProductDetailsViewModel)?.Price;
        //ProductServiceProxy.Current.AddOrUpdateProduct(new Product
        //{
        //    Name = name,
        //    Quantity = quant,
        //    Price = price
        //});
        Shell.Current.GoToAsync("//InventoryManagement");
    }


    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//InventoryManagement");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (ProductId == 0)
        {
            BindingContext = new ProductDetailsViewModel();
        } else
        {
            BindingContext = new ProductDetailsViewModel(ProductServiceProxy.Current.GetById(ProductId));
        }
    }
}