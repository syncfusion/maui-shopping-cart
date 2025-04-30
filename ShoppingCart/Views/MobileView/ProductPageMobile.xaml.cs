namespace ShoppingCart;

public partial class ProductPageMobile : ContentPage
{
    List<string> SizeCatagory = new List<string>() { "S", "M", "L", "XL", "2XL", "3XL", "4XL" };
    public ProductPageMobile()
	{
		InitializeComponent();
        BindableLayout.SetItemsSource(SizeLayout, SizeCatagory);
    }

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new MainPageMobile());
    }
}