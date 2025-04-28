using System.Collections.ObjectModel;

namespace ShoppingCart;

public partial class SavedItemsPageDesktop : ContentView
{
    ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
    public SavedItemsPageDesktop(ShoppingCartViewModel shoppingCartViewModel)
	{
		InitializeComponent();
        this.shoppingCartViewModel = shoppingCartViewModel;
        if (shoppingCartViewModel != null)
        {
            shoppingCartViewModel.SavedProducts = new ObservableCollection<Product>(
        shoppingCartViewModel.Products.Where(product => product.IsSaved));

            BindingContext =shoppingCartViewModel;
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

    }
}
