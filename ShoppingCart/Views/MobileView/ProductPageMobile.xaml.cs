namespace ShoppingCart;

public partial class ProductPageMobile : ContentPage
{
    public ProductPageMobile()
	{
		InitializeComponent();
    }

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
         Navigation.PopAsync();
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

    void ToggleSavedStatus(object sender, EventArgs e)
    {
        if (sender is Label tappedLabel)
        {
            if (tappedLabel.BindingContext is Product currentItem)
            {
                currentItem.IsSaved = !currentItem.IsSaved;
            }
        }
    }

    private void BuyNowButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PaymentPageMobile());
    }
}