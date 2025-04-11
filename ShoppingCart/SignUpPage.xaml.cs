namespace ShoppingCart;

public partial class SignUpPage : ContentPage
{
#if ANDROID || IOS
	SignUpMobilePage signUpMobilePage;
#endif
    public SignUpPage()
	{
		InitializeComponent();
#if ANDROID || IOS
        Navigation.PushAsync(new SignUpMobilePage());
#endif
    }
}