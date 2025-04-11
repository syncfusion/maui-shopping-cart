using Syncfusion.Maui.Rotator;
using System.Collections.ObjectModel;

namespace ShoppingCart
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
            rotatorView.ItemsSource = shoppingCartViewModel.RotatorItems;
        }
    }
}
