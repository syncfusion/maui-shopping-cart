using Syncfusion.Maui.Rotator;
using System.Collections.ObjectModel;

namespace ShoppingCart
{
    public partial class HomePageDesktop : ContentPage
    {

        public HomePageDesktop()
        {
            InitializeComponent();
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
            rotatorView.ItemsSource = shoppingCartViewModel.DesktopRotatorItems;
            catagoriesChip.ItemsSource = shoppingCartViewModel.Catagories;
        }
    }
}
