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
            AddTapGesture(SavedProductsBorder);
        }

        void AddTapGesture(Border border)
        {
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) => SetSelected(border);
            border.GestureRecognizers.Add(tapGesture);
        }

        void SetSelected(Border border)
        {

            if (border.Content is HorizontalStackLayout layout && layout.Children.Count >= 2)
            {
                var textLabel = layout.Children[1] as Label;
                var text = textLabel?.Text;
                ContentView selectedContent = new();
                selectedContent.IsVisible = true;

                switch (text)
                {
                   case "Saved Products":
                        selectedContent = new SavedItemsPage();
                        break;
                }
                selectedtab.Children.Clear();
                selectedtab.Children.Add(selectedContent);
            }
        }
    }
}
