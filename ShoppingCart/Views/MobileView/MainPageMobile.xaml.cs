﻿using Microsoft.Maui.Controls.Shapes;
using ShoppingCart.Views.MobileView;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.Themes;
using Syncfusion.Maui.Toolkit.TabView;
using System.Collections.ObjectModel;

namespace ShoppingCart
{
    public partial class MainPageMobile : ContentPage
    {
        decimal? _totalPrice;
        decimal? _price;
        ShoppingCartViewModel shoppingCartViewModel;
        private View? _originalProfileContent;
        bool isMenuSelected = false;
        public MainPageMobile()
        {
            InitializeComponent();
            shoppingCartViewModel = new ShoppingCartViewModel();
            shoppingCartViewModel.FilteredProducts = new ObservableCollection<Product>();
            shoppingCartViewModel.FindSavedProducts();
            shoppingCartViewModel.FindCartProducts();
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
                        .Where(product => product.Category == selectedCategory.ToString());

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
                var productpageMobile = new ProductPageMobile(shoppingCartViewModel)
                {
                    BindingContext = tappedProduct,
                };

				Navigation.PushAsync(productpageMobile);
            }
        }    

        private void tabView_SelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            _price = 0;
            if(e.NewIndex == 2 && shoppingCartViewModel != null)
            {
                shoppingCartViewModel.FindSavedProducts();
            }
            if (e.NewIndex == 3 && shoppingCartViewModel != null)
            {
                if (Application.Current!.RequestedTheme == AppTheme.Dark)
                {
                    sfSwitch.IsOn = true;
                }
                else
                {
                    sfSwitch.IsOn = false;
                }
            }
            if (e.NewIndex == 4 && shoppingCartViewModel!=null)
            {
                shoppingCartViewModel.FindCartProducts();
                if (shoppingCartViewModel.MyCartProducts?.Count == 0)
                {
                    CartDetailsLayout.IsVisible = false;
                    popup.IsVisible = true;
                    popup.IsOpen = true;
                }
                else
                {
                    if(shoppingCartViewModel.MyCartProducts !=null)
                    {
                        foreach (var product in shoppingCartViewModel.MyCartProducts)
                        {
                            _price += product.Price;
                        }

                        _totalPrice = (_price + 40);
                        priceLabel.Text = $"${_price}";
                        totalAmountLabel.Text = $"${_totalPrice}";
                    }
                }
               
            }
        }

        private void IncrementQuantity_Tapped(object sender, TappedEventArgs e)
        {
            if (sender is Element element && element.Parent is HorizontalStackLayout stackLayout
                && element.BindingContext is Product product)
            {
                var quantityLabel = stackLayout.Children.OfType<Label>().FirstOrDefault(l => l.Text.All(char.IsDigit));
                if (quantityLabel != null && int.TryParse(quantityLabel.Text, out int quantity))
                {
                    quantity++;
                    quantityLabel.Text = quantity.ToString("D2");
                    _price += product.Price;
                    priceLabel.Text = $"${_price}";
                    _totalPrice = (_price + 40);
                    totalAmountLabel.Text = $"${_totalPrice}";
                }
            }
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e) 
        {

            var searchText = e.NewTextValue?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(searchText)) 
            {
                filteredResultsView.IsVisible = false;

               
                if (shoppingCartViewModel.RecentSearchedProducts.Any()) 
                {
                    searchitem.IsVisible = true;
                    recentsearch.IsVisible = false;
                }
                else
                {
                    searchitem.IsVisible = false;
                    recentsearch.IsVisible = true;
                }

                return;
            }

            var filtered = shoppingCartViewModel.Products
                .Where(p => p.Name !=null && p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            shoppingCartViewModel.FilteredProducts!.Clear();
            foreach (var item in filtered)
                shoppingCartViewModel.FilteredProducts.Add(item);

            filteredResultsView.IsVisible = filtered.Any();
            searchitem.IsVisible = false;
            recentsearch.IsVisible = false;
        }

   
        private void OnClearAllTapped(object sender, EventArgs e) 
        {
            shoppingCartViewModel.RecentSearchedProducts.Clear();
            recentsearch.IsVisible = true;
            searchitem.IsVisible = false;
            filteredResultsView.IsVisible = false;
        }

        private void OnEntryFocused(object sender, FocusEventArgs e) 
        {
            recentsearch.IsVisible = false;
            filteredResultsView.IsVisible = false;
            searchitem.IsVisible = false;
        }


        private void DecrementQuantity_Tapped(object sender, TappedEventArgs e)
        {
            if (sender is Element element && element.Parent is HorizontalStackLayout stackLayout
                && element.BindingContext is Product product)
            {
                var quantityLabel = stackLayout.Children.OfType<Label>().FirstOrDefault(l => l.Text.All(char.IsDigit));
                if (quantityLabel != null && int.TryParse(quantityLabel.Text, out int quantity) && quantity > 0)
                {
                    quantity--;
                    if (quantity == 0)
                    {
                        product.IsAddedToCart = false;
                        shoppingCartViewModel.FindCartProducts();
                        _price = 0;
                        if(shoppingCartViewModel.MyCartProducts !=null)
                        {
                            foreach (var item in shoppingCartViewModel.MyCartProducts)
                            {
                                _price += item.Price;
                            }
                        }
                        this.BindingContext = shoppingCartViewModel;
                        quantityLabel.Text = "01";
                        priceLabel.Text = $"${_price}";
                        _totalPrice = (_price + 40);
                        totalAmountLabel.Text = $"${_totalPrice}";
                        if (shoppingCartViewModel.MyCartProducts?.Count == 0)
                        {
                            CartDetailsLayout.IsVisible = false;
                            popup.IsOpen = true;
                        }
                    }
                    else
                    {
                        quantityLabel.Text = quantity.ToString("D2");
                        _price -= product.Price;
                        priceLabel.Text = $"${_price}";
                        _totalPrice = (_price + 40);
                        totalAmountLabel.Text = $"${_totalPrice}";
                    }
                }
            }

        }


        private void Notifications_Tapped(object sender, EventArgs e)
        {
            SetupPageContent(3, new NotificationsPageMobile(), "Notification");
        }

        private void MyOrders_Tapped(object sender, EventArgs e)
        {
            SetupPageContent(3, new MyOrdersPageMobile(shoppingCartViewModel), "My Orders");
        }

        private void NavigateBackToProfile(int tabIndex)
        {
            if (_originalProfileContent != null)
            {
                tabView.Items[tabIndex].Content = _originalProfileContent;
            }
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            popup.IsVisible = false;
            popup.IsOpen = false;
        }

        private void BackArrowButton_Tapped(object sender, TappedEventArgs e)
        {
            tabView.SelectedIndex = 0;
        }

        private void BuyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaymentPageMobile(true));
        }
        private void SfSwitch_StateChanged(object sender, Syncfusion.Maui.Buttons.SwitchStateChangedEventArgs e)
        {
            if (Application.Current != null)
            {
                ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                if (mergedDictionaries != null)
                {
                    var theme1 = mergedDictionaries.OfType<Syncfusion.Maui.Toolkit.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                    var theme2 = mergedDictionaries.OfType<Syncfusion.Maui.Themes.SyncfusionThemeResourceDictionary>().FirstOrDefault();
                    if (theme1 != null && theme2 != null)
                    {
                        if (sfSwitch.IsOn == false)
                        {
                            theme1.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialLight;
                            theme2.VisualTheme = SfVisuals.MaterialLight;
                            Application.Current.UserAppTheme = AppTheme.Light;
                        }
                        else if (sfSwitch.IsOn == true)
                        {
                            theme1.VisualTheme = Syncfusion.Maui.Toolkit.Themes.SfVisuals.MaterialDark;
                            theme2.VisualTheme = SfVisuals.MaterialDark;
                            Application.Current.UserAppTheme = AppTheme.Dark;
                        }
                    }
                }
            }
            if (Application.Current!.RequestedTheme == AppTheme.Dark)
            {
                Application.Current.Resources["SfListViewItemRippleBackground"] = Color.FromArgb("#1C1B1F");

            }
            else
            {
                Application.Current.Resources["SfListViewItemRippleBackground"] = Color.FromArgb("#FFFBFE");
            }
        }
        private void Payment_Tapped(object sender, TappedEventArgs e)
        {
            SetupPageContent(3, new PaymentPageMobile(false), "Payments");
        }
        private void Address_Tapped(object sender, TappedEventArgs e)
        {
            SetupPageContent(3, new AddressPageMobile(shoppingCartViewModel), "Addresses");
        }

        private void SetupPageContent(int profileTabIndex, ContentPage page, string title)
        {
            _originalProfileContent = tabView.Items[profileTabIndex].Content;
            var navigateBackCommand = new Command(() => NavigateBackToProfile(profileTabIndex));

            var backButtonLabel = CreateBackButton(navigateBackCommand);

            var titleLabel = CreateTitleLabel(title);

            // Optional: Wrap the back button with an EffectView or Border if needed
            var effectView = new SfEffectsView
            {
                Content = backButtonLabel
            };

            var border = new Border
            {
                Content = effectView,
                StrokeThickness = 0,
                StrokeShape = new RoundRectangle { CornerRadius = 8 }
            };

            var headerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,Spacing=5,
                Children =
                    {
                        border,  
                        titleLabel
                    }
            };

            var layout = new StackLayout
            {
                Margin = new Thickness(5, 30, 0, 0),
                Children =
                    {
                        headerLayout,
                        page.Content
                    }
            };

            tabView.Items[profileTabIndex].Content = layout;
        }

        private Label CreateBackButton(Command navigateBackCommand)
        {
            var backButtonLabel = new Label
            {
                Text = "\ue70e",
                FontFamily = "MauiSampleFontIcon",
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 20,
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Command = navigateBackCommand;
            backButtonLabel.GestureRecognizers.Add(tapGestureRecognizer);

            return backButtonLabel;
        }

        private Label CreateTitleLabel(string title)
        {
            return new Label
            {
                Text = title,
                FontSize = 14,
                VerticalTextAlignment = TextAlignment.Center
            };
        }

        private void Edit_Tapped(object sender, TappedEventArgs e)
        {
            SetupPageContent(3, new ProfilePageMobile(shoppingCartViewModel, () => NavigateBackToProfile(3)), "Profile");
        }

        private void filteredResultsView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Product tappedProduct) {
                var productpageMobile = new ProductPageMobile (shoppingCartViewModel) {
                    BindingContext = tappedProduct
                };

                Navigation.PushAsync(productpageMobile);


                if (!shoppingCartViewModel.RecentSearchedProducts.Any(p => p.Name == tappedProduct.Name)) {
                    shoppingCartViewModel.RecentSearchedProducts.Insert(0, tappedProduct);
                }

                filteredResultsView.IsVisible = false;
                searchitem.IsVisible = true;
                recentsearch.IsVisible = false;
                entry.Text = string.Empty;
                entry.Unfocus();
            }


        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) 
        {
            if (e.Item is Product tappedProduct) {
                var productpageMobile = new ProductPageMobile (shoppingCartViewModel) {
                    BindingContext = tappedProduct
                };

                Navigation.PushAsync(productpageMobile);
            }
        }

        private void entry_Focused(object sender, FocusEventArgs e) 
        {
            tabView.SelectedIndex = 1;
        }
    }

}
    

 