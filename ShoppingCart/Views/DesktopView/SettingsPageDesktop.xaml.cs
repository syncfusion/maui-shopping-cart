using Syncfusion.Maui.Themes;

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
        if (Application.Current != null)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                var theme1 = mergedDictionaries.OfType<Syncfusion.Maui.Toolkit.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                var theme2 = mergedDictionaries.OfType<Syncfusion.Maui.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                if (theme1 != null && theme2 != null)
                {
                    if (sfSwitch.IsOn == false)
                    {
                        theme1.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialLight;
                        theme2.VisualTheme = SfVisuals.MaterialLight;
                        Application.Current.UserAppTheme = AppTheme.Light;
                    }
                    else if (sfSwitch.IsOn == true)
                    {
                        theme1.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialDark;
                        theme2.VisualTheme = SfVisuals.MaterialDark;
                        Application.Current.UserAppTheme = AppTheme.Dark;
                    }
                }
            }
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