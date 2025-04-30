using static ShoppingCart.ShoppingCartViewModel;
namespace ShoppingCart;

public partial class ProductPageDesktop : ContentView
{
	public ProductPageDesktop()
	{
		InitializeComponent();
    }

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
        var productpageDesktop = new HomePageDesktop(shoppingCartViewModel);
        Content = productpageDesktop;
    }
}