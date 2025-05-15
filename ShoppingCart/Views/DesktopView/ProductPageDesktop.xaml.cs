using Microsoft.Maui.Controls.Compatibility;
namespace ShoppingCart;

public partial class ProductPageDesktop : ContentView
{
    private ContentView _callerPage;

    ShoppingCartViewModel shoppingCartViewModel;
    public ProductPageDesktop(ContentView callerPage, ShoppingCartViewModel viewModel)
	{
		InitializeComponent();
        _callerPage = callerPage;
        this.BindingContextChanged += (s, e) =>
        {
            if (this.BindingContext is Product product)
            {
                PreviewImageTwoBorder.IsVisible = product.PreviewTwoImageUrl != null;
                PreviewImageThreeBorder.IsVisible = product.PreviewThreeImageUrl != null;
                PreviewImageFourBorder.IsVisible = product.PreviewFourImageUrl != null;
            }
        };
        shoppingCartViewModel = viewModel;
        BindingContext = viewModel;
    }

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        this.Content = _callerPage;
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if (this.BindingContext is Product product)
        {
            product.IsAddedToCart = true;
            popup.IsVisible = true;
            popup.IsOpen=true;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        popup.IsVisible = false;
        popup.IsOpen = false;
    }
    private void PreviewImageOne_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && border.BindingContext is Product product)
        {
            MainImage.Source = product.PreviewOneImageUrl;
        }
    }

    private void MainImage_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && border.BindingContext is Product product)
        {
            MainImage.Source = product.ImageUrl;
        }
    }
    private void PreviewImageTwo_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && border.BindingContext is Product product)
        {
            MainImage.Source = product.PreviewTwoImageUrl;
        }
    }
    private void PreviewImageThree_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && border.BindingContext is Product product)
        {
            MainImage.Source = product.PreviewThreeImageUrl;
        }
    }
    private void PreviewImageFour_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Border border && border.BindingContext is Product product)
        {
            MainImage.Source = product.PreviewFourImageUrl;
        }
    }
    private void PaymentBackArrow_Tapped(object sender, TappedEventArgs e)
    {
        PaymentLayout.IsVisible = false;
        ProductLayout.IsVisible = true;
    }

    private void BuyNow_Clicked(object sender, EventArgs e)
    {
        ProductLayout.IsVisible = false;
        PaymentLayout.IsVisible = true;
        if (this.BindingContext is Product product)
        {
            shoppingCartViewModel.AddToOrders(product);
            popup.IsOpen = true;
        }
    }

}
