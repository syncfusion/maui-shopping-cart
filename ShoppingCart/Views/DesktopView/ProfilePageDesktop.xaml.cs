namespace ShoppingCart;

public partial class ProfilePageDesktop : ContentView
{
    private readonly Action _navigateBack;
    public ProfilePageDesktop(Action navigateBack)
    {
        InitializeComponent();
        _navigateBack = navigateBack;
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        _navigateBack?.Invoke(); 
    }
}