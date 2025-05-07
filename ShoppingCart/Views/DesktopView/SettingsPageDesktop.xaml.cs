namespace ShoppingCart;

public partial class SettingsPageDesktop : ContentView
{
    private ShoppingCartViewModel shoppingCartViewModel;
    public SettingsPageDesktop(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        shoppingCartViewModel = viewModel;
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        var notificationsView = new MyOrdersPageDesktop(shoppingCartViewModel);
        this.Content = notificationsView;
    }

    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        var notificationsView = new NotificationsPageDesktop(shoppingCartViewModel);
        this.Content = notificationsView;
    }

    private void SfSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
          App.Current.UserAppTheme = (bool)sfSwitch.IsOn ? AppTheme.Dark : AppTheme.Light;
    }
    }