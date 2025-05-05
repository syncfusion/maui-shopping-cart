namespace ShoppingCart;

public partial class MyOrdersPageDesktop : ContentView
{
	public MyOrdersPageDesktop()
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