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

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if (this.BindingContext is Product product)
        {
            product.IsAddedToCart = true;
            popup.IsOpen=true;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        popup.IsOpen = false;
    }
}