using Csharp_project1.Models;
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class ProductDetailsView : ContentPage
{
	public ProductDetailsView()
	{
		InitializeComponent();
		BindingContext = new ProductDetailsViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        Product? addedProduct = (BindingContext as ProductDetailsViewModel)?.Add();
    }
    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//InventoryManagement");
    }


}