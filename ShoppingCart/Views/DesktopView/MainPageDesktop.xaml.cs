using ShoppingCart;
using System.Collections.ObjectModel;
using Syncfusion.Maui.Core.Internals;
using Syncfusion.Maui.Core;
using PointerEventArgs = Syncfusion.Maui.Core.Internals.PointerEventArgs;

namespace ShoppingCart
{
    public partial class MainPageDesktop : ContentPage
    {
        List<Border> _tabBorders = new List<Border>();
        ShoppingCartViewModel shoppingCartViewModel;
        Border _selectedBorder;
        private bool _isProfilePageVisible = false;
        private ProfilePageDesktop? _profilePage;
        ContentView selectedContent = new();
        string? _productName;
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

            Application.Current!.RequestedThemeChanged += (s, e) =>
            {
                SetSelected(_selectedBorder);
                UpdateColorsForTheme();
            };
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
        {
            // Reset previous selection
            if (_selectedBorder != null && _selectedBorder.Content is SfEffectsViewAdv effectsView && effectsView.Content is HorizontalStackLayout prevLayout) {
                _selectedBorder.BackgroundColor = Colors.Transparent;

                if (prevLayout.Children.Count >= 2) {
                    var prevIconLabel = prevLayout.Children[0] as Label;
                    var prevTextLabel = prevLayout.Children[1] as Label;

                    if (Application.Current!.RequestedTheme == AppTheme.Dark) {
                        prevIconLabel!.TextColor = Color.FromArgb("#CAC4D0");
                        prevTextLabel!.TextColor = Color.FromArgb("#E6E1E5");
                        
                    }
                    else {
                        prevIconLabel!.TextColor = Color.FromArgb("#49454F"); // icon color light
                        prevTextLabel!.TextColor = Color.FromArgb("#1C1B1F"); // content text color light
                        
                    }
                }
            }

            // Set new selection
            border.BackgroundColor = (Application.Current!.RequestedTheme == AppTheme.Light) ? Color.FromArgb("#EADDFF") : Color.FromArgb("#4A4458");

            if (border.Content is SfEffectsViewAdv effectsViewAdv && effectsViewAdv.Content is HorizontalStackLayout layout && layout.Children.Count >= 2) {
                var iconLabel = layout.Children[0] as Label;
                var textLabel = layout.Children[1] as Label;
                var text = textLabel?.Text;

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

        void UpdateColorsForTheme()
        {
            foreach (var border in _tabBorders)
            {
                if (border == _selectedBorder)
                {
                    border.BackgroundColor = (Application.Current!.RequestedTheme == AppTheme.Light) ? Color.FromArgb("#EADDFF") : Color.FromArgb("#4A4458");
                    if (border.Content is SfEffectsViewAdv effectsViewAdvSelected && effectsViewAdvSelected.Content is HorizontalStackLayout layoutSelected && layoutSelected.Children.Count >= 2)
                    {
                        var iconLabel = layoutSelected.Children[0] as Label;
                        var textLabel = layoutSelected.Children[1] as Label;

                        iconLabel!.TextColor = (Application.Current!.RequestedTheme == AppTheme.Light) ? Color.FromArgb("#49454F") : Color.FromArgb("#CAC4D0");
                        textLabel!.TextColor = (Application.Current!.RequestedTheme == AppTheme.Light) ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#E6E1E5");
                    }
                    continue;
                }

                border.BackgroundColor = (Application.Current!.RequestedTheme == AppTheme.Light) ? Color.FromArgb("#00000000") : Color.FromArgb("#00000000");

                if (border.Content is SfEffectsViewAdv effectsViewAdv && effectsViewAdv.Content is HorizontalStackLayout layout && layout.Children.Count >= 2)
                {
                    var iconLabel = layout.Children[0] as Label;
                    var textLabel = layout.Children[1] as Label;

                    iconLabel!.TextColor = (Application.Current!.RequestedTheme == AppTheme.Light) ? Color.FromArgb("#49454F") : Color.FromArgb("#CAC4D0");
                    textLabel!.TextColor = (Application.Current!.RequestedTheme == AppTheme.Light) ? Color.FromArgb("#1C1B1F") : Color.FromArgb("#E6E1E5");
                }
            }
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = e.NewTextValue?.Trim();

            if (!string.IsNullOrWhiteSpace(text) && text.Length > 1) 
            {
                _productName = text;
                var results = shoppingCartViewModel.Products
                    .Where(p => p?.Name != null && p.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                shoppingCartViewModel.FilteredProducts?.Clear();

                foreach (var item in results) 
                {
                    shoppingCartViewModel.FilteredProducts?.Add(item);
                }

                filteredResultsView.ItemsSource = shoppingCartViewModel.FilteredProducts;
                var productpageDesktop = new SearchpageDesktop(shoppingCartViewModel,_productName,() => NavigateBackToHome());
                selectedContent = productpageDesktop;
                selectedContent.IsVisible = true;
                selectedtab.Children.Clear();
                selectedtab.Children.Add(selectedContent);

                // Only show if there are any matching results
                if (results.Any())
                {
                    searchListGrid.IsVisible = true;
                    filteredResultsView.IsVisible = true;
                }
                else 
                {
                    searchListGrid.IsVisible = false;
                    filteredResultsView.IsVisible = false;
                }

                searchlistGrid2.IsVisible = false;
                recentsearch.IsVisible = false;
            }
            else 
            {
                searchListGrid.IsVisible = false;
                filteredResultsView.IsVisible = false;
                searchlistGrid2.IsVisible = false;
                recentsearch.IsVisible = false;
            }
        }

        private void OnClearAllTapped(object sender, EventArgs e) 
        {
            shoppingCartViewModel.RecentSearchedProducts.Clear();
            recentsearch.IsVisible = false;
            searchlistGrid2.IsVisible = false;
        }

        private void filteredResultsView_ItemTapped(object sender, ItemTappedEventArgs e) 
         {
            if (e.Item is Product tappedProduct) 
            {
                _productName = tappedProduct.Name != null ? tappedProduct.Name.ToString() : string.Empty;
                shoppingCartViewModel.FilteredProducts?.Clear();

                shoppingCartViewModel.FilteredProducts?.Add(tappedProduct);

                if (!shoppingCartViewModel.RecentSearchedProducts.Any(p => p.Name == tappedProduct.Name))
                {
                    shoppingCartViewModel.RecentSearchedProducts.Insert(0, tappedProduct);
                }

                entry.Text = string.Empty;
                entry.Unfocus();
            }
        }

        private void entry_Focused(object sender, FocusEventArgs e)
        {
            filteredResultsView.IsVisible = false;
            searchListGrid.IsVisible = false;

            if (shoppingCartViewModel.RecentSearchedProducts.Any())
            {
                searchlistGrid2.IsVisible = true;
                recentsearch.IsVisible = true;
            }
        }

        private void recentsearch_ItemTapped(object sender, ItemTappedEventArgs e) 
        {
            
            if (e.Item is Product tappedProduct && shoppingCartViewModel != null) 
            {
                _productName = tappedProduct.Name != null ? tappedProduct.Name.ToString() : string.Empty;
                shoppingCartViewModel.FilteredProducts?.Clear();
                shoppingCartViewModel.FilteredProducts?.Add(tappedProduct);
                var searchpageDesktop = new SearchpageDesktop(shoppingCartViewModel, _productName, () => NavigateBackToHome());
                searchlistGrid2.IsVisible = false;
                searchlistGrid2.IsVisible = false;
                selectedContent = searchpageDesktop;
                selectedContent.IsVisible = true;
                selectedtab.Children.Clear();
                selectedtab.Children.Add(selectedContent);
                entry.Text = string.Empty;
                entry.Unfocus();
            }
        }

        private void entry_Unfocused(object sender, FocusEventArgs e)
        {
            searchListGrid.IsVisible = false;
            entry.Text = string.Empty;
        }

        private void entry_Completed(object sender, EventArgs e)
        {
            searchListGrid.IsVisible = false;
            entry.Text = string.Empty;
        }
    }


    internal class SfEffectsViewAdv : SfEffectsView, ITouchListener, IGestureListener
    {
        public new void OnTouch(PointerEventArgs e)
        {
            if (e.Action == PointerActions.Entered)
            {
                this.ApplyEffects(SfEffects.Highlight, RippleStartPosition.Default, new System.Drawing.Point((int)e.TouchPoint.X, (int)e.TouchPoint.Y), false);
            }
            else if (e.Action == PointerActions.Released || e.Action == PointerActions.Cancelled || e.Action == PointerActions.Exited)
            {
                this.Reset();
            }
            else if (e.Action == PointerActions.Pressed)
            {
                this.ApplyEffects(SfEffects.Ripple, RippleStartPosition.Default, new System.Drawing.Point((int)e.TouchPoint.X, (int)e.TouchPoint.Y), false);
            }
        }
    }
}
