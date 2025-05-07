namespace ShoppingCart.Views.MobileView;

public partial class MyOrdersPageMobile : ContentPage
{
    private readonly Action _navigateBack;

    public MyOrdersPageMobile()
	{
		InitializeComponent();
	}

    private void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        if (e.DataItem is Product tappedProduct)
        {
            //var myOrdersPage = new MyOrdersPageDesktop(shoppingCartViewModel);
            //var productpageDesktop = new ProductPageDesktop(myOrdersPage, shoppingCartViewModel)
            //{
            //    BindingContext = tappedProduct
            //};
            //Content = productpageDesktop;
        }
    }

}