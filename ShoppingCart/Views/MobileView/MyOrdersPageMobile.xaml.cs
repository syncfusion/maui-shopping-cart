using System.Collections.ObjectModel;

namespace ShoppingCart.Views.MobileView;

public partial class MyOrdersPageMobile : ContentPage
{

    ShoppingCartViewModel shoppingCartViewModel;

    public MyOrdersPageMobile(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        shoppingCartViewModel = viewModel;
        BindingContext = shoppingCartViewModel;
    }

    private async void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        if (e.DataItem is Product tappedProduct)
        {
            var productPage = new ProductPageMobile(shoppingCartViewModel)
            {
                BindingContext = tappedProduct
            };

            await Application.Current!.Windows[0].Page!.Navigation.PushAsync(productPage);
        }
    }

    private void BackArrowButton_Tapped(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}