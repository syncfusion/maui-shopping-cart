
namespace ShoppingCart.Views.MobileView;

public partial class ProfilePageMobile : ContentPage
{
    ShoppingCartViewModel shoppingCartViewModel;
    private readonly Action _onBack;
    public ProfilePageMobile(ShoppingCartViewModel viewModel, Action onBack)
	{
		InitializeComponent();

        shoppingCartViewModel = viewModel;
        shoppingCartViewModel.TempUserName = shoppingCartViewModel.CurrentUser?.UserName;
        BindingContext = shoppingCartViewModel;
        numberentry.Text = shoppingCartViewModel.CurrentUser?.MobileNumber;
        genderComboBox.SelectedItem = shoppingCartViewModel.CurrentUser?.Gender;
        _onBack = onBack;
    }

    private void SfButton_Clicked(object sender, EventArgs e)
    {
        shoppingCartViewModel.CurrentUser!.UserName = shoppingCartViewModel.TempUserName;
        shoppingCartViewModel.CurrentUser.Email = mailInput.Text ?? string.Empty;
        shoppingCartViewModel.CurrentUser.MobileNumber = phoneNumberInput.Text ?? string.Empty;
        shoppingCartViewModel.CurrentUser.Gender = genderInput.Text ?? string.Empty;
        _onBack?.Invoke();
    }
}