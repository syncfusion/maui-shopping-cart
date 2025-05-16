using ShoppingCart;
using System.Collections.ObjectModel;

namespace ShoppingCart
{
    public partial class MainPageDesktop : ContentPage
    {
        List<Border> _tabBorders = new List<Border>();
        ShoppingCartViewModel shoppingCartViewModel;
        Border _selectedBorder;
        private bool _isProfilePageVisible = false;
        private ProfilePageDesktop _profilePage;
        private View _previousPageContent;
        ContentView selectedContent = new();
        public MainPageDesktop(ShoppingCartViewModel viewModel)
        {            InitializeComponent();
            shoppingCartViewModel = viewModel;
            BindingContext = shoppingCartViewModel;
            _selectedBorder = HomeBorder;
            SetSelected(HomeBorder);

            //Add Tap Gestures
            AddTapGesture(HomeBorder);
            AddTapGesture(SavedProductsBorder);
            AddTapGesture(CartBorder);
            AddTapGesture(AccountBorder);

            // Add Tab Borders to list
            _tabBorders.Add(HomeBorder);
            _tabBorders.Add(SavedProductsBorder);
            _tabBorders.Add(CartBorder);
            _tabBorders.Add(AccountBorder);
        }
         void AddTapGesture(Border border)
        {
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) => SetSelected(border);
            border.GestureRecognizers.Add(tapGesture);
        }

         private void OnAvatarViewTapped(object sender, EventArgs e)
        {
            if (_isProfilePageVisible)
            {
                ContentView selectedContent = _selectedBorder switch
                {
                    var b when b == HomeBorder => new HomePageDesktop(shoppingCartViewModel),
                    var b when b == AccountBorder => new SettingsPageDesktop(shoppingCartViewModel),
                    var b when b == CartBorder => new MyCartPageDesktop(shoppingCartViewModel),
                    var b when b == SavedProductsBorder => new SavedItemsPageDesktop(shoppingCartViewModel),
                    _ => new HomePageDesktop(shoppingCartViewModel)
                };

                selectedtab.Children.Clear();
                selectedtab.Children.Add(selectedContent);

                _isProfilePageVisible = false;
                _profilePage = null;
            }
            else
            {
                Action backAction = _selectedBorder == HomeBorder ? () => NavigateBackToHome() :
                                    _selectedBorder == AccountBorder ? () => NavigateBackToSettings() :
                                    _selectedBorder == CartBorder ? () => NavigateBackToMyCart() :
                                    () => NavigateBackToSavedProducts();

                _profilePage = new ProfilePageDesktop(backAction, shoppingCartViewModel);
                selectedtab.Children.Clear();
                selectedtab.Children.Add(_profilePage);

                _isProfilePageVisible = true;
            }
        }

        private void NavigateBackToHome()
        {
            var homePage = new HomePageDesktop(shoppingCartViewModel);
            selectedtab.Children.Clear();
            selectedtab.Children.Add(homePage);
        }

        private void NavigateBackToSettings()
        {
            var settingsPage = new SettingsPageDesktop(shoppingCartViewModel);
            selectedtab.Children.Clear();
            selectedtab.Children.Add(settingsPage);
        }

        private void NavigateBackToMyCart()
        {
            var settingsPage = new MyCartPageDesktop(shoppingCartViewModel);
            selectedtab.Children.Clear();
            selectedtab.Children.Add(settingsPage);
        }

        private void NavigateBackToSavedProducts()
        {
            var settingsPage = new SavedItemsPageDesktop(shoppingCartViewModel);
            selectedtab.Children.Clear();
            selectedtab.Children.Add(settingsPage);
        }

        void SetSelected(Border border)
        {            // Reset previous selection
            if (_selectedBorder != null && _selectedBorder.Content is HorizontalStackLayout prevLayout) {
                _selectedBorder.BackgroundColor = Colors.Transparent;

                if (prevLayout.Children.Count >= 2) {
                    var prevIconLabel = prevLayout.Children[0] as Label;
                    var prevTextLabel = prevLayout.Children[1] as Label;

                    if (Application.Current!.RequestedTheme == AppTheme.Dark) {
                        prevIconLabel!.TextColor = Color.FromArgb("#C9C6C8");
                        prevTextLabel!.TextColor = Colors.White;
                    }
                    else {
                        prevIconLabel!.TextColor = Color.FromArgb("#474648"); // icon color light
                        prevTextLabel!.TextColor = Color.FromArgb("#313032"); // content text color light
                    }
                }
            }

            // Set new selection
            border.BackgroundColor = Color.FromArgb("#7633DA");

            if (border.Content is HorizontalStackLayout layout && layout.Children.Count >= 2) {
                var iconLabel = layout.Children[0] as Label;
                var textLabel = layout.Children[1] as Label;
                var text = textLabel?.Text;

                // Selected tab color
                iconLabel!.TextColor = Colors.White;
                textLabel!.TextColor = Colors.White;


                selectedContent.IsVisible = true;

                switch (text) {
                    case "Home":
                        selectedContent = new HomePageDesktop(shoppingCartViewModel);
                        _isProfilePageVisible = false;
                        break;
                    case "Saved Products":
                        selectedContent = new SavedItemsPageDesktop(shoppingCartViewModel);
                        _isProfilePageVisible = false;
                        break;
                    case "My Cart":
                        selectedContent = new MyCartPageDesktop(shoppingCartViewModel);
                        _isProfilePageVisible = false;
                        break;
                    case "My Account":
                        selectedContent = new SettingsPageDesktop(shoppingCartViewModel);
                        _isProfilePageVisible = false;
                        break;
                }

                _selectedBorder = border;
                selectedtab.Children.Clear();
                selectedtab.Children.Add(selectedContent);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e) 
         {
            if (sender is VisualElement element && element.BindingContext is Product tappedProduct) {

                var HomePageContent = new HomePageDesktop(shoppingCartViewModel);
                var productpageDesktop = new ProductPageDesktop(HomePageContent) {
                    BindingContext = tappedProduct
                };
                selectedContent = productpageDesktop;
                selectedContent.IsVisible = true;
                selectedtab.Children.Clear();
                selectedtab.Children.Add(selectedContent);
                //this.searchListGrid.IsVisible = false;
            }
        }


        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
      {
             var text = e.NewTextValue?.Trim();

            if (!string.IsNullOrWhiteSpace(text) && text.Length > 1) {
                // Filter logic
                var results = shoppingCartViewModel.Products
                    .Where(p => p.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                // Update FilteredProducts collection
                shoppingCartViewModel.FilteredProducts.Clear();
                foreach (var item in results) {
                    shoppingCartViewModel.FilteredProducts.Add(item);
                }

                // Show filtered results grid
                searchListGrid.IsVisible = true;
                filteredResultsView.IsVisible = true;

                // Hide recent search grid
                searchlistGrid2.IsVisible = false;
            }
            else {
                // Hide filtered results
                searchListGrid.IsVisible = false;
                filteredResultsView.IsVisible = false;

                // Show recent searches only if there is any
                if (shoppingCartViewModel.RecentSearchedProducts.Any()) {
                    searchlistGrid2.IsVisible = true;
                }
                else {
                    searchlistGrid2.IsVisible = false;
                }
            }
        }

        private void OnClearAllTapped(object sender, EventArgs e) 
        {
            shoppingCartViewModel.RecentSearchedProducts.Clear();
           // recentsearch.IsVisible = true;
           // searchitem.IsVisible = false;
            filteredResultsView.IsVisible = false;
        }

        private void filteredResultsView_ItemTapped(object sender, ItemTappedEventArgs e) 
         {
            if (e.Item is Product tappedProduct) {
                var productpageMobile = new ProductPageMobile() {
                    BindingContext = tappedProduct
                };

                Navigation.PushAsync(productpageMobile);


                if (!shoppingCartViewModel.RecentSearchedProducts.Any(p => p.Name == tappedProduct.Name)) {
                    shoppingCartViewModel.RecentSearchedProducts.Insert(0, tappedProduct);
                }
                filteredResultsView.IsVisible = false;
                searchlistGrid2.IsVisible = true;
                //recentsearch.IsVisible = false;
                entry.Text = string.Empty;
                entry.Unfocus();
            }
        }
    }
}
