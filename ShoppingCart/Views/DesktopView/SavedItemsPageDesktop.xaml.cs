using System.Collections.ObjectModel;

namespace ShoppingCart;

public partial class SavedItemsPageDesktop : ContentView
{
    ShoppingCartViewModel shoppingCartViewModel;
    public SavedItemsPageDesktop(ShoppingCartViewModel shoppingCartViewModel)
	{
		InitializeComponent();
        this.shoppingCartViewModel = shoppingCartViewModel;
        if (shoppingCartViewModel != null)
        {
            shoppingCartViewModel.FindSavedProducts();
            BindingContext = shoppingCartViewModel;
        }
    }

    private void ToggleSavedStatus(object sender, TappedEventArgs e)
    {
        if (sender is Label label && label.BindingContext is Product product)
        {
            shoppingCartViewModel.SavedProducts?.Remove(product);
            product.IsSaved = false;
        }
    }

    private void ProductsList_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        if (e.DataItem is Product tappedProduct)
        {
            var savedItemsPage = new SavedItemsPageDesktop(shoppingCartViewModel);
            var productpageDesktop = new ProductPageDesktop(savedItemsPage)
            {
                BindingContext = tappedProduct
            };

            // Add ProductDetailsView to the page
            Content = productpageDesktop;
        }
    }
}
