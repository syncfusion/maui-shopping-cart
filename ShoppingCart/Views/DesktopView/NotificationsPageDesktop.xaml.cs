namespace ShoppingCart;

public partial class NotificationsPageDesktop : ContentView
{
    private ShoppingCartViewModel shoppingCartViewModel;
    public NotificationsPageDesktop(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        shoppingCartViewModel = viewModel;
	}

    private void BackArrow_Tapped(object sender, EventArgs e)
    {
        var settingsView = new SettingsPageDesktop(shoppingCartViewModel);
        this.Content = settingsView;
    }
}