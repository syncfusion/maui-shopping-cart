namespace ShoppingCart;

public partial class ProductPageMobile : ContentPage
{
    ShoppingCartViewModel shoppingCartViewModel;
    public ProductPageMobile(ShoppingCartViewModel viewModel)
    {
        InitializeComponent();
        shoppingCartViewModel = viewModel;
        BindingContext = shoppingCartViewModel;
    }

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
         Navigation.PopAsync();
    }

    private void AddButton_Clicked(object sender, EventArgs e)
    {
        if (this.BindingContext is Product product)
        {
            product.IsAddedToCart = true;
            popup.IsVisible= true;
            popup.IsOpen = true;
        }
    }

    private void BuyNow_clicked(object sender, EventArgs e)
    {
        if (this.BindingContext is Product product)
        {
            shoppingCartViewModel.AddToOrders(product);
            Navigation.PushAsync(new PaymentPageMobile(true));
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        popup.IsVisible = false;
        popup.IsOpen = false;
    }

    void ToggleSavedStatus(object sender, EventArgs e)
    {
        if (sender is Label tappedLabel)
        {
            if (tappedLabel.BindingContext is Product currentItem)
            {
                currentItem.IsSaved = !currentItem.IsSaved;
            }
        }
    }

   
}