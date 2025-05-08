using System.Collections.ObjectModel;

namespace ShoppingCart.Views.MobileView;

public partial class MyOrdersPageMobile : ContentPage
{
    private readonly Action _navigateBack;

    public MyOrdersPageMobile(ShoppingCartViewModel shoppingCartViewModel)
	{
		InitializeComponent();
        if (shoppingCartViewModel != null)
        {
            shoppingCartViewModel.AddToOrders();
            BindingContext = shoppingCartViewModel;
        }
    }

    private void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        if (e.DataItem is Product tappedProduct)
        {
            var productpageMobile = new ProductPageMobile
            {
                BindingContext = tappedProduct
            };

            Navigation.PushAsync(productpageMobile);
        }
    }

}