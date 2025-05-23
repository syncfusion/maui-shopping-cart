namespace ShoppingCart;

public partial class SettingsPageDesktop : ContentView
{
    private ShoppingCartViewModel shoppingCartViewModel;
    public SettingsPageDesktop(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        shoppingCartViewModel = viewModel;
        if (Application.Current!.RequestedTheme == AppTheme.Dark)
        {
            sfSwitch.IsOn = true;
        }
        else
        {
            sfSwitch.IsOn = false;
        }
    }

    private void MyOrders_Tapped(object sender, TappedEventArgs e)
    {
        var notificationsView = new MyOrdersPageDesktop(shoppingCartViewModel);
        this.Content = notificationsView;
    }

    private void Notifications_Tapped(object sender, TappedEventArgs e)
    {
        var notificationsView = new NotificationsPageDesktop(shoppingCartViewModel);
        this.Content = notificationsView;
    }

    private void SfSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
        if (App.Current != null)
        {
            App.Current.UserAppTheme = (sfSwitch.IsOn ?? false) ? AppTheme.Dark : AppTheme.Light;
        }
        if (Application.Current!.RequestedTheme == AppTheme.Dark)
        {
            Application.Current.Resources["SfListViewItemRippleBackground"] = Color.FromArgb("#1C1B1F");

        }
        else
        {
            Application.Current.Resources["SfListViewItemRippleBackground"] = Color.FromArgb("#FFFBFE");
        }
    }

    private void PaymentMethod_Tapped(object sender, TappedEventArgs e)
    {
        var PaymentView = new PaymentPageDesktop(shoppingCartViewModel);
        this.Content = PaymentView;
    }

    private void Address_Tapped(object sender, TappedEventArgs e)
    {
        var AddressView = new AddressPageDesktop(shoppingCartViewModel);
        this.Content = AddressView;
    }
}