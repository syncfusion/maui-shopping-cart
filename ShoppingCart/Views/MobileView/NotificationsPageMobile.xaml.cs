namespace ShoppingCart.Views.MobileView;

public partial class NotificationsPageMobile : ContentPage
{
	public NotificationsPageMobile()
	{
		InitializeComponent();
	}

    private void BackArrowButton_Tapped(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}