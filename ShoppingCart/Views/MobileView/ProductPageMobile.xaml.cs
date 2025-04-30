namespace ShoppingCart;

public partial class ProductPageMobile : ContentPage
{
    public ProductPageMobile()
	{
		InitializeComponent();
    }

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new MainPageMobile());
    }
}