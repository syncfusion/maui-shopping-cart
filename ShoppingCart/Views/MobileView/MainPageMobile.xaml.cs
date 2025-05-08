using Syncfusion.Maui.Rotator;
using Syncfusion.Maui.Toolkit.TabView;
using System.Collections.ObjectModel;

namespace ShoppingCart
{
    public partial class MainPageMobile : ContentPage
    {

        ShoppingCartViewModel shoppingCartViewModel;
        bool isMenuSelected = false;
        public MainPageMobile()
        {
            InitializeComponent();
            shoppingCartViewModel = new ShoppingCartViewModel();
            shoppingCartViewModel.FilteredProducts = new ObservableCollection<Product>();
            shoppingCartViewModel.FindSavedProducts();
            for (int i = 0; i < 4; i++)
            {
                shoppingCartViewModel.FilteredProducts.Add(shoppingCartViewModel.Products[i]);
            }
            BindingContext = shoppingCartViewModel;
        }

        private void ViewAll_Tapped(object sender, TappedEventArgs e)
        {
            TitleLabel.IsVisible = false;
            rotatorView.IsVisible = false;
            ViewAllLabel.IsVisible = false;
            BackArrow.IsVisible = true;
            shoppingCartViewModel.FilteredProducts?.Clear();
            for (int i = 0; i < shoppingCartViewModel.Products.Count; i++)
            {
                shoppingCartViewModel.FilteredProducts?.Add(shoppingCartViewModel.Products[i]);
            }

        }


        private void Menu_Tapped(object sender, TappedEventArgs e)
        {
            isMenuSelected = !isMenuSelected;
            if (isMenuSelected)
            {
                rotatorView.IsVisible = false;
                TrendLabel.IsVisible = false;
                ViewAllLabel.IsVisible = false;
                BackArrow.IsVisible = false;
                if (Application.Current!.RequestedTheme == AppTheme.Dark)
                {
                    MenuBorder.BackgroundColor = Color.FromArgb("#D0BCFF");
                    MenuLabel.TextColor = Color.FromArgb("#381E72");
                }
                else
                {
                    MenuBorder.BackgroundColor = Color.FromArgb("#6750A4");
                    MenuLabel.TextColor = Color.FromArgb("#FFFFFF");
                }

                CatagoryScrollView.IsVisible = true;
                catagoriesChip.SelectedItem = "Men";
                var selectedCategory = "Men";
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
            }
            else
            {
                if (Application.Current!.RequestedTheme == AppTheme.Dark)
                {
                    MenuBorder.BackgroundColor = Color.FromArgb("#2A2831");
                    MenuLabel.TextColor = Color.FromArgb("#CAC4D0");
                }
                else
                {
                    MenuBorder.BackgroundColor = Color.FromArgb("#F3EDF7");
                    MenuLabel.TextColor = Color.FromArgb("#49454F");
                }
                CatagoryScrollView.IsVisible = false;
                rotatorView.IsVisible = true;
                TrendLabel.IsVisible = true;
                ViewAllLabel.IsVisible = true;
                shoppingCartViewModel.FilteredProducts?.Clear();
                for (int i = 0; i < 4; i++)
                {
                    shoppingCartViewModel.FilteredProducts?.Add(shoppingCartViewModel.Products[i]);
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

        }

        private void BackArrow_Tapped(object sender, TappedEventArgs e)
        {
            BackArrow.IsVisible = false;
            rotatorView.IsVisible = true;
            TrendLabel.IsVisible = true;
            ViewAllLabel.IsVisible = true;
            shoppingCartViewModel.FilteredProducts?.Clear();
            for (int i = 0; i < 4; i++)
            {
                shoppingCartViewModel.FilteredProducts?.Add(shoppingCartViewModel.Products[i]);
            }
        }

        void ToggleSavedStatus(object sender, EventArgs e)
        {
            if (sender is Label tappedLabel)
            {
                if (tappedLabel.BindingContext is Product currentItem)
                {
                    currentItem.IsSaved = !currentItem.IsSaved;
                    shoppingCartViewModel.FindSavedProducts();
                }
            }
        }

        private void RemoveProductFromSavedItems(object sender, TappedEventArgs e)
        {
            if (sender is Label label && label.BindingContext is Product product)
            {
                shoppingCartViewModel.SavedProducts?.Remove(product);
                product.IsSaved = false;
            }
        }

        private void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
        {
            if (e.DataItem is Product tappedProduct)
            {
                var productpageMobile = new ProductPageMobile
                {
                    BindingContext = tappedProduct
                };

                Navigation.PushAsync(productpageMobile);
            }
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e) 
        {
            var searchText = e.NewTextValue?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(searchText)) {
                searchitem.IsVisible = false;
                recentsearch.IsVisible = true;
                return;
            }

            
            var filtered = shoppingCartViewModel.Catagories
                .Where(c => c.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (filtered.Any()) {
               
                shoppingCartViewModel.FilteredCategories.Clear();
                foreach (var item in filtered)
                    shoppingCartViewModel.FilteredCategories.Add(item);

                searchitem.IsVisible = true;
                recentsearch.IsVisible = false;
            }
            else {
                
                searchitem.IsVisible = false;
                recentsearch.IsVisible = false;
            }

        }
    }
}
