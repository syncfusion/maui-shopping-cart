namespace ShoppingCart;

public partial class AddressPageDesktop : ContentView
{
    private ShoppingCartViewModel shoppingCartViewModel;
    public AddressPageDesktop(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
		this.shoppingCartViewModel = viewModel;
        var user = new UserProfile();
        this.BindingContext = user;
    }

    private void AddressBackArrow_Tapped(object sender, TappedEventArgs e)
    {
        var settingsView = new SettingsPageDesktop(shoppingCartViewModel);
        this.Content = settingsView;
    }
}