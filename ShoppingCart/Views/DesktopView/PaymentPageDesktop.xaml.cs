namespace ShoppingCart;

public partial class PaymentPageDesktop : ContentView
{
    private ShoppingCartViewModel shoppingCartViewModel;
    public PaymentPageDesktop(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        this.shoppingCartViewModel = viewModel;
	}
    private void PaymentBackArrow_Tapped(object sender, TappedEventArgs e)
    {
        var settingsView = new SettingsPageDesktop(shoppingCartViewModel);
        this.Content = settingsView;
    }
}