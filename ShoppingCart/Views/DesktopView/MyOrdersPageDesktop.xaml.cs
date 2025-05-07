namespace ShoppingCart;

public partial class MyOrdersPageDesktop : ContentView
{
    private ShoppingCartViewModel shoppingCartViewModel;
    public MyOrdersPageDesktop(ShoppingCartViewModel viewModel)
    {
        InitializeComponent();
        shoppingCartViewModel = viewModel;
        if (shoppingCartViewModel != null)
        {
            shoppingCartViewModel.AddToOrders();
            BindingContext = shoppingCartViewModel;
        }
    }

    private void BackArrow_Tapped(object sender, EventArgs e)
    {
        var settingsView = new SettingsPageDesktop(shoppingCartViewModel);
        this.Content = settingsView;
    }

    private void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        if (e.DataItem is Product tappedProduct)
        {
            var myOrdersPage = new MyOrdersPageDesktop(shoppingCartViewModel);
            var productpageDesktop = new ProductPageDesktop(myOrdersPage, shoppingCartViewModel)
            {
                BindingContext = tappedProduct
            };
            Content = productpageDesktop;
        }
    }
}