namespace ShoppingCart;

public partial class SettingsPageDesktop : ContentView
{
    private ShoppingCartViewModel shoppingCartViewModel;
    public SettingsPageDesktop(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        shoppingCartViewModel = viewModel;
    }

    private async void MyOrders_Tapped(object sender, TappedEventArgs e)
    {
        var notificationsView = new MyOrdersPageDesktop(shoppingCartViewModel);
        this.Content = notificationsView;
    }

    private async void Notifications_Tapped(object sender, TappedEventArgs e)
    {
        var notificationsView = new NotificationsPageDesktop(shoppingCartViewModel);
        this.Content = notificationsView;
    }

    private void SfSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
          App.Current.UserAppTheme = (bool)sfSwitch.IsOn ? AppTheme.Dark : AppTheme.Light;
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