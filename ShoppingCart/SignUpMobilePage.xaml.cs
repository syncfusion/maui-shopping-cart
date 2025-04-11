namespace ShoppingCart;

public partial class SignUpMobilePage : ContentPage
{
	public SignUpMobilePage()
	{
		InitializeComponent();
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
        Navigation.PushAsync(new MainPage());
    }

    private void SignInButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}