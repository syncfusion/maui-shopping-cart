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

        private void ViewAll_Tapped(object sender, TappedEventArgs e)
        {
            TitleLabel.IsVisible = false;
            rotatorView.IsVisible = false;
            ViewAllLabel.IsVisible = false;
            ProductScrollviewGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        }

    }
}
