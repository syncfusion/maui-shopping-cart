using Microsoft.Maui.Controls.Shapes;
using ShoppingCart.Views.MobileView;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.Rotator;
using Syncfusion.Maui.Toolkit.TabView;
using System.Collections.ObjectModel;
using static Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.VisualElement;

namespace ShoppingCart
{
    public partial class MainPageMobile : ContentPage
    {
        decimal _totalPrice;
        decimal _price;
        ShoppingCartViewModel shoppingCartViewModel;
        private View _originalProfileContent;
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
                var productpageMobile = new ProductPageMobile(shoppingCartViewModel)
                {
                    BindingContext = tappedProduct,
                };

				Navigation.PushAsync(productpageMobile);
            }
        }        private void tabView_SelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            _price = 0;
            if(e.NewIndex == 2 && shoppingCartViewModel != null)
            {
                shoppingCartViewModel.FindSavedProducts();
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
                    foreach (var product in shoppingCartViewModel.MyCartProducts)
                    {
                        _price += (decimal)product.Price;
                    }

                    _totalPrice = (_price + 40);
                    priceLabel.Text = $"${_price}";
                    totalAmountLabel.Text = $"${_totalPrice}";
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
                    _price += (decimal)product.Price;
                    priceLabel.Text = $"${_price}";
                    _totalPrice = (_price + 40);
                    totalAmountLabel.Text = $"${_totalPrice}";
                }
            }
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
                        foreach (var item in shoppingCartViewModel.MyCartProducts)
                        {
                            _price += (decimal)item.Price;
                        }
                        this.BindingContext = shoppingCartViewModel;
                        quantityLabel.Text = "01";
                        priceLabel.Text = $"${_price}";
                        _totalPrice = (_price + 40);
                        totalAmountLabel.Text = $"${_totalPrice}";
                        if (shoppingCartViewModel.MyCartProducts.Count == 0)
                        {
                            CartDetailsLayout.IsVisible = false;
                            popup.IsOpen = true;
                        }
                    }
                    else
                    {
                        quantityLabel.Text = quantity.ToString("D2");
                        _price -= (decimal)product.Price;
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
            App.Current.UserAppTheme = (bool)sfSwitch.IsOn ? AppTheme.Dark : AppTheme.Light;
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
                Text = "\ue70d",
                FontFamily = "ShoppingCartFontIcon",
                Margin = new Thickness(15, 30,0,0),
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
                Margin = new Thickness(15, 35,0,0),
                FontSize = 14,
                VerticalTextAlignment = TextAlignment.Center
            };
        }

        private void Edit_Tapped(object sender, TappedEventArgs e)
        {
            SetupPageContent(3, new ProfilePageMobile(shoppingCartViewModel, () => NavigateBackToProfile(3)), "Profile");
        }
    }
}
