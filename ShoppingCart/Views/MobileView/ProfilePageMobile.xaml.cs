namespace ShoppingCart.Views.MobileView;

public partial class ProfilePageMobile : ContentPage
{
	public ProfilePageMobile(ShoppingCartViewModel shoppingCartViewModel)
	{
		InitializeComponent();

        if (shoppingCartViewModel != null)
        {
            BindingContext = shoppingCartViewModel;
        }
    }
}