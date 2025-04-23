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

    private void InlineAddClicked(object sender, EventArgs e)
    {
		(BindingContext as ShopViewModel)?.Refresh();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void CheckOutClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Checkout");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ShopViewModel)?.Refresh();
    }
}