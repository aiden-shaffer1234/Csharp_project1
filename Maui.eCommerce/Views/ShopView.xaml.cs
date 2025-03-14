using Csharp_project1.Models;
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class ShopView : ContentPage
{
	public ShopView()
	{
		InitializeComponent();
		BindingContext = new ShopViewModel();
	}

    private void RemoveClicked(object sender, EventArgs e)
    {
		Product? lastProduct = (BindingContext as ShopViewModel)?.Delete();
    }
}