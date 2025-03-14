using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class ProductDetailsView : ContentPage
{
	public ProductDetailsView()
	{
		InitializeComponent();
		BindingContext = new ProductDetailsViewModel();

    }

    private void GoBackClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//InventoryManagement");
    }
}