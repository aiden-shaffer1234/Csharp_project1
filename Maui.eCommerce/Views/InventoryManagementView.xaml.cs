using Csharp_project1.Models;
using Library.eCommerce.Services;
using Maui.eCommerce.ViewModels;

namespace Maui.eCommerce.Views;


public partial class InventoryManagementView : ContentPage
{
	public InventoryManagementView()
	{
		InitializeComponent();
        BindingContext = new InventoryManagementViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProductDetails");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        var productId = (BindingContext as InventoryManagementViewModel)?.SelectedProduct?.Id;
        Shell.Current.GoToAsync($"//ProductDetails?productId={productId}");
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        Product? lastProduct = (BindingContext as InventoryManagementViewModel)?.Delete();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.RefreshProductList();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryManagementViewModel)?.RefreshProductList();
    }
}