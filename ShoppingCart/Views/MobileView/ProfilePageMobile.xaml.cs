
namespace ShoppingCart.Views.MobileView;

public partial class ProfilePageMobile : ContentPage
{
    ShoppingCartViewModel shoppingCartViewModel;
    public ProfilePageMobile(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();

            shoppingCartViewModel = viewModel;
            shoppingCartViewModel.TempUserName = shoppingCartViewModel.CurrentUser.UserName;
            BindingContext = shoppingCartViewModel;
        numberentry.Text = shoppingCartViewModel.CurrentUser.MobileNumber;
        genderComboBox.SelectedItem = shoppingCartViewModel.CurrentUser.Gender;
    }

    private void SfButton_Clicked(object sender, EventArgs e)
    {
        shoppingCartViewModel.CurrentUser.UserName = shoppingCartViewModel.TempUserName;
        shoppingCartViewModel.CurrentUser.Email = mailInput.Text;
        shoppingCartViewModel.CurrentUser.MobileNumber = phoneNumberInput.Text;
        shoppingCartViewModel.CurrentUser.Gender = genderInput.Text;
    }
}