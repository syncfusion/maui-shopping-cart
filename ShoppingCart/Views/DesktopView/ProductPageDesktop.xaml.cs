using static ShoppingCart.ShoppingCartViewModel;
namespace ShoppingCart;

public partial class ProductPageDesktop : ContentView
{
    private ContentView _callerPage;
    public ProductPageDesktop(ContentView callerPage)
	{
		InitializeComponent();
        _callerPage = callerPage;
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
}