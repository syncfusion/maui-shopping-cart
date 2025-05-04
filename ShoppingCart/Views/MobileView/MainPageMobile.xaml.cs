using Syncfusion.Maui.Rotator;
using Syncfusion.Maui.Toolkit.TabView;
using System.Collections.ObjectModel;

namespace ShoppingCart
{
    public partial class MainPageMobile : ContentPage
    {
        decimal _totalPrice;
        decimal _price;
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

        private void tabView_SelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            _price = 0;
            if (e.NewIndex == 4)
            {
                shoppingCartViewModel.FindCartProducts();
                if (shoppingCartViewModel.MyCartProducts?.Count == 0)
                {
                    CartDetailsLayout.IsVisible = false;
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
        private void Button_Clicked(object sender, EventArgs e)
        {
            popup.IsOpen = false;
        }

    }
}
