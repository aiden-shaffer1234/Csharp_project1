using Csharp_project1.Models;
using Library.eCommerce.Models;
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class ShopView : ContentPage
{
	public ShopView()
	{
		InitializeComponent();
		BindingContext = new ShopViewModel();
	}

	private void RemoveFromCartClicked(object sender, EventArgs e)
	{
		(BindingContext as ShopViewModel)?.ReturnItem();
	}

    private void AddToCartClicked(object sender, EventArgs e)
    {
		(BindingContext as ShopViewModel)?.PurchaseItem();
    }
}