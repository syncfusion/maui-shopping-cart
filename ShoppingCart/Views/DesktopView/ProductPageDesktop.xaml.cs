using Microsoft.Maui.Controls.Compatibility;
using static ShoppingCart.ShoppingCartViewModel;
namespace ShoppingCart;

public partial class ProductPageDesktop : ContentView
{
    private ContentView _callerPage;

    ShoppingCartViewModel shoppingCartViewModel;
    public ProductPageDesktop(ContentView callerPage, ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        _callerPage = callerPage;
        BindingContext = viewModel;
    }

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        this.Content = _callerPage;
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

    private void BuyNowButton_Clicked(object sender, EventArgs e)
    {
        if (this.BindingContext is Product product)
        {
            product.IsProductBuyed = true;
            popup.IsOpen = true;
        }
    }
}