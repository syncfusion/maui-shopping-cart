using static ShoppingCart.ShoppingCartViewModel;
namespace ShoppingCart;

public partial class ProductPageDesktop : ContentView
{
	List<string> SizeCatagory = new List<string>() { "S","M","L","XL","2XL","3XL","4XL"};
	public ProductPageDesktop()
	{
		InitializeComponent();
        BindableLayout.SetItemsSource(SizeLayout, SizeCatagory);

    }

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
        var productpageDesktop = new HomePageDesktop(shoppingCartViewModel);
        Content = productpageDesktop;
    }
}