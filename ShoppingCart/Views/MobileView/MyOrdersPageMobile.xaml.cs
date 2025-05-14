using System.Collections.ObjectModel;

namespace ShoppingCart.Views.MobileView;

public partial class MyOrdersPageMobile : ContentPage
{
    private readonly Action _navigateBack;

    ShoppingCartViewModel shoppingCartViewModel;

    public MyOrdersPageMobile(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        if (shoppingCartViewModel != null)
        {
            shoppingCartViewModel = viewModel;
            BindingContext = shoppingCartViewModel;
        }
    }

    private async void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        if (e.DataItem is Product tappedProduct)
        {
            var productPage = new ProductPageMobile(shoppingCartViewModel)
            {
                BindingContext = tappedProduct
            };

            await Application.Current.MainPage.Navigation.PushAsync(productPage);
        }
    }
}