namespace ShoppingCart;

public partial class ProfilePageDesktop : ContentView
{
    ShoppingCartViewModel shoppingCartViewModel;
    private readonly Action _navigateBack;
    public ProfilePageDesktop(Action navigateBack, ShoppingCartViewModel viewModel)
    {
        InitializeComponent();
        shoppingCartViewModel = viewModel;
        shoppingCartViewModel.TempUserName = shoppingCartViewModel.CurrentUser?.UserName;
        BindingContext = shoppingCartViewModel;
        numberentry.Text = shoppingCartViewModel.CurrentUser?.MobileNumber ;
        genderComboBox.SelectedItem = shoppingCartViewModel.CurrentUser?.Gender ;
        _navigateBack = navigateBack;
    }

    private void BackArrow_Tapped(object sender, EventArgs e)
    {
        _navigateBack?.Invoke(); 
    }

    private void SfButton_Clicked(object sender, EventArgs e)
    {
        shoppingCartViewModel.CurrentUser!.UserName = shoppingCartViewModel.TempUserName;
        shoppingCartViewModel.CurrentUser.Email = mailInput.Text ?? string.Empty;
        shoppingCartViewModel.CurrentUser.MobileNumber = phoneNumberInput.Text ?? string.Empty;
        shoppingCartViewModel.CurrentUser.Gender = genderInput.Text ?? string.Empty;
        _navigateBack?.Invoke();
    }
}