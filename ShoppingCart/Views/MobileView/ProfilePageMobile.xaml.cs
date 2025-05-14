
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
    }

    private void SfButton_Clicked(object sender, EventArgs e)
    {
        shoppingCartViewModel.CurrentUser.UserName = shoppingCartViewModel.TempUserName;
        shoppingCartViewModel.CurrentUser.Email = mailInput.Text;
        shoppingCartViewModel.CurrentUser.MobileNumber = phoneNumberInput.Text;
        shoppingCartViewModel.CurrentUser.Gender = genderInput.Text;
    }
}