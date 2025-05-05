namespace ShoppingCart;

public partial class NotificationsPageDesktop : ContentView
{
	public NotificationsPageDesktop()
	{
		InitializeComponent();
	}

    private void SfButton_Clicked(object sender, EventArgs e)
    {
        var settingsView = new SettingsPageDesktop();
        if (this.Parent is Grid parentGrid && parentGrid.FindByName<Grid>("selectedtab") is Grid selectedTab)
        {
            selectedTab.Children.Clear();
            selectedTab.Children.Add(settingsView);
        }
    }
}