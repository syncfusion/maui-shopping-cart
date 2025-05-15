namespace ShoppingCart;

public partial class AddressPageMobile : ContentPage
{
    ShoppingCartViewModel shoppingCartViewModel;
    public AddressPageMobile(ShoppingCartViewModel ViewModel)
	{
		InitializeComponent();
        ViewModel = shoppingCartViewModel;
        this.BindingContext = ViewModel;
	}
    private void AddressBackArrow_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}