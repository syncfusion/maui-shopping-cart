using Syncfusion.Maui.Rotator;
using System.Collections.ObjectModel;

namespace ShoppingCart
{
    public partial class MainPageMobile : ContentPage
    {

        public MainPageMobile()
        {
            InitializeComponent();
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
            rotatorView.ItemsSource = shoppingCartViewModel.RotatorItems;
        }
    }
}
