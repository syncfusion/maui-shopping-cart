namespace ShoppingCart;

public partial class SignUpPageDesktop : ContentPage
{
    ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
    public SignUpPageDesktop()
	{
		InitializeComponent();
        signinEmail.Text = shoppingCartViewModel.CurrentUser.Email;
        signinPassword.Text = shoppingCartViewModel.CurrentUser.Password;
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
        shoppingCartViewModel.CurrentUser.UserName = nameInput.Text;
        shoppingCartViewModel.CurrentUser.Email = emailInput.Text;
        shoppingCartViewModel.CurrentUser.Password = passwordInput.Text;
        Navigation.PushAsync(new MainPageDesktop(shoppingCartViewModel));
    }

    private void SignInButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPageDesktop(shoppingCartViewModel));
    }
}