
namespace ShoppingCart.Views.MobileView;

public partial class ProfilePageMobile : ContentPage
{
    ShoppingCartViewModel shoppingCartViewModel;
    public ProfilePageMobile(ShoppingCartViewModel viewModel)
	{
		InitializeComponent();

        if (shoppingCartViewModel != null)
        {
            shoppingCartViewModel = viewModel;
            BindingContext = shoppingCartViewModel;
        }
    }

    private void SfButton_Clicked(object sender, EventArgs e)
    {
        shoppingCartViewModel.CurrentUser.UserName = nameInput.Text;
        shoppingCartViewModel.CurrentUser.Email = mailInput.Text;
        shoppingCartViewModel.CurrentUser.MobileNumber = phoneNumberInput.Text;
        shoppingCartViewModel.CurrentUser.Gender = genderInput.Text;
    }
}