namespace ShoppingCart;

public partial class SettingsPageDesktop : ContentView
{
    public SettingsPageDesktop()
	{
		InitializeComponent();
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        var notificationsView = new MyOrdersPageDesktop();
        if (this.Parent is Grid parentGrid && parentGrid.FindByName<Grid>("selectedtab") is Grid selectedTab)
        {
            selectedTab.Children.Clear();
            selectedTab.Children.Add(notificationsView);
        }
    }

    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        var notificationsView = new NotificationsPageDesktop();
        if (this.Parent is Grid parentGrid && parentGrid.FindByName<Grid>("selectedtab") is Grid selectedTab)
        {
            selectedTab.Children.Clear();
            selectedTab.Children.Add(notificationsView);
        }
    }

    private void SfSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
    {
          App.Current.UserAppTheme = (bool)sfSwitch.IsOn ? AppTheme.Light : AppTheme.Dark;
    }
    }