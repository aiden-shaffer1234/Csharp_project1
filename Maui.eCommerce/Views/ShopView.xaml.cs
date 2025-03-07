using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class ShopView : ContentPage
{
	public ShopView()
	{
		InitializeComponent();
		BindingContext = new ShopViewModel();
	}
}