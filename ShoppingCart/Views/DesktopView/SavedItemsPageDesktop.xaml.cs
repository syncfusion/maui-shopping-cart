using System.Collections.ObjectModel;

namespace ShoppingCart;

public partial class SavedItemsPageDesktop : ContentView
{
    ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
    public SavedItemsPageDesktop()
	{
		InitializeComponent();
        if (shoppingCartViewModel != null)
        {
            shoppingCartViewModel.SavedProducts = new ObservableCollection<Product>(
        shoppingCartViewModel.Products.Where(product => product.IsSaved));

            BindingContext =shoppingCartViewModel;
        }
    }
}
