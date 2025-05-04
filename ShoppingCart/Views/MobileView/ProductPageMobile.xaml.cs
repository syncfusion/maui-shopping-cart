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

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if (this.BindingContext is Product product)
        {
            product.IsAddedToCart = true;
            popup.IsOpen = true;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        popup.IsOpen = false;
    }
}