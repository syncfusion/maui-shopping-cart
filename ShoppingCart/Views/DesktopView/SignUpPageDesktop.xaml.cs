namespace ShoppingCart;

public partial class SignUpPageDesktop : ContentPage
{
    ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
    public SignUpPageDesktop()
	{
		InitializeComponent();
        signinEmail.Text = shoppingCartViewModel.Email;
        signinPassword.Text = shoppingCartViewModel.Password;
    }

    private void SignIn_Tapped(object sender, TappedEventArgs e)
    {
        signUPLayout.IsVisible = false;
        signInLayout.IsVisible = true;
    }

    private void SignUp_Tapped(object sender, TappedEventArgs e)
    {
        signInLayout.IsVisible = false;
        signUPLayout.IsVisible = true;
    }

    private void SignUpButton_Clicked(object sender, EventArgs e)
    {
        
    }

    private void SignInButton_Clicked(object sender, EventArgs e)
    {
        
    }
}