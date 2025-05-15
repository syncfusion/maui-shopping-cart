namespace ShoppingCart;

public partial class PaymentPageMobile : ContentPage
{
	public PaymentPageMobile(bool isvisible)
	{
		InitializeComponent();
        BackArrow.IsVisible = isvisible;
        if (isvisible)
        {
            paymentgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });
            paymentgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            paymentgrid.RowSpacing = 15;
        }
        else
        { 
            paymentgrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            paymentgrid.RowSpacing = 0;
        }
    }
    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}