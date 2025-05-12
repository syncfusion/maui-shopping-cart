namespace ShoppingCart;

public partial class PaymentPageMobile : ContentPage
{
	public PaymentPageMobile()
	{
		InitializeComponent();
	}
    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}