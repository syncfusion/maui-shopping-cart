using Microsoft.Maui.Controls;
using Syncfusion.Maui.ListView;
using Syncfusion.Maui.Rotator;
using System.Collections.ObjectModel;
using static ShoppingCart.ShoppingCartViewModel;

namespace ShoppingCart
{
    public partial class HomePageDesktop : ContentView
    {
        string selectedCategory = "Men";
        ShoppingCartViewModel shoppingCartViewModel;
        public HomePageDesktop(ShoppingCartViewModel shoppingCartViewModel)
        {
            InitializeComponent();
            this.shoppingCartViewModel = shoppingCartViewModel;
            this.MinimumWidthRequest = 600;
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

            UpdateColumn(width);
        }

        internal void UpdateColumn(double width)
        {
            if (width > 0)
            {
                if (width > 900)
                {
                    listView.SpanCount = 5;
                }
                else if (width > 700 && width < 900)
                {
                    listView.SpanCount = 4;
                }
                else
                {
                    listView.SpanCount = 3;
                }
            }
        }


        private void catagoriesChip_SelectionChanged(object sender, Syncfusion.Maui.Core.Chips.SelectionChangedEventArgs e)
        {
            selectedCategory = e.AddedItem?.ToString() ?? string.Empty;
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

        private void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
        {
            if (e.DataItem is Product tappedProduct)
            {
                var selected = this.selectedCategory;
                var HomePageContent = new HomePageDesktop(shoppingCartViewModel);
                HomePageContent.catagoriesChip.SelectedItem = selected;
                var productpageDesktop = new ProductPageDesktop(HomePageContent, shoppingCartViewModel)
                {
                    BindingContext = tappedProduct
                };

                // Add ProductDetailsView to the page
                Content = productpageDesktop;
            }
        }

    }
}
