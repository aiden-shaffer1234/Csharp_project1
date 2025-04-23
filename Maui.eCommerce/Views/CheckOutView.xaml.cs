using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;

public partial class CheckOutView : ContentPage
{
	public CheckOutView()
	{
		InitializeComponent();
        BindingContext = new CheckOutViewModel();
	}

    private void ConfirmClicked(object sender, EventArgs e)
    {
        (BindingContext as CheckOutViewModel)?.CheckOut();
        Shell.Current.GoToAsync("//Shop");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Shop");
    }
}