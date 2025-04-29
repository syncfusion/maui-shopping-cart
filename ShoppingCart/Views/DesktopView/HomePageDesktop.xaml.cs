using Microsoft.Maui.Controls;
using Syncfusion.Maui.Rotator;
using System.Collections.ObjectModel;
using static ShoppingCart.ShoppingCartViewModel;

namespace ShoppingCart
{
    public partial class HomePageDesktop : ContentView
    {

        ShoppingCartViewModel shoppingCartViewModel;
        public HomePageDesktop(ShoppingCartViewModel shoppingCartViewModel)
        {
            InitializeComponent();
            this.shoppingCartViewModel = shoppingCartViewModel;
            this.MinimumWidthRequest = 800;
            var selectedCategory = "Men";
            if (selectedCategory != null)
            {

                if (shoppingCartViewModel != null)
                {
                    shoppingCartViewModel.FilteredProducts = new ObservableCollection<Product>();
                    var filteredProducts = shoppingCartViewModel.Products
                        .Where(product => product.Category == selectedCategory);

                    foreach (var product in filteredProducts)
                    {
                        shoppingCartViewModel.FilteredProducts.Add(product);
                    }
                }
            }
             BindingContext = shoppingCartViewModel;
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


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                UpdateColumn(width);
            });
        }

        internal void UpdateColumn(double width)
        {
            if(width>0)
            {
                if (width > 1200)
                {
                    listView.SpanCount = 5;
                }
                else
                {
                    listView.SpanCount = 3;
                }
            }
        }


        private void catagoriesChip_SelectionChanged(object sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
        {
            var selectedCategory = e.AddedItem;
            if (selectedCategory != null)
            {
                if (shoppingCartViewModel != null)
                {
                    shoppingCartViewModel.FilteredProducts?.Clear();

                    var filteredProducts = shoppingCartViewModel.Products
                        .Where(product => product.Category == selectedCategory);

                    foreach (var product in filteredProducts)
                    {
                        shoppingCartViewModel.FilteredProducts?.Add(product);
                    }
                }
            }
            UpdateColumn(this.Width);
        }
    }
}
