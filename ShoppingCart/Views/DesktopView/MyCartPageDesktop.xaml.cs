namespace ShoppingCart;

public partial class MyCartPageDesktop : ContentView
{
    decimal _totalPrice;
    decimal _price;
    decimal _discount ;
    ShoppingCartViewModel shoppingCartViewModel;

    public MyCartPageDesktop(ShoppingCartViewModel shoppingCartView)
	{
		InitializeComponent();
        shoppingCartViewModel = shoppingCartView;
        if (shoppingCartViewModel != null)
        {
            shoppingCartViewModel.FindCartProducts();
            BindingContext = shoppingCartViewModel;
        }

        foreach(var product in shoppingCartViewModel.MyCartProducts)
        {
            _price += (decimal)product.Price;
        }

        ProductCountLabel.Text =$"Price ({shoppingCartView.MyCartProducts.Count.ToString()}) Items" ;
        _discount = _price - (_price / 2);
        _totalPrice =( _price + 80 ) - _discount;
        priceLabel.Text = $"${_price}";
        discountLabel.Text =$"$ -{_discount}";
        totalAmountLabel.Text = $"${_totalPrice}";
        SavingLabel.Text = $"You'll save ${_discount} on this order";
        
        if (shoppingCartViewModel.MyCartProducts.Count == 0)
        {
            CartDetailsLayout.IsVisible = false;
            popup.IsOpen = true;
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
                _discount = _price - (_price / 2);
                _totalPrice = (_price + 80) - _discount;
                priceLabel.Text = $"${_price}";
                discountLabel.Text = $"$ -{_discount}";
                totalAmountLabel.Text = $"${_totalPrice}";
                SavingLabel.Text = $"You'll save ${_discount} on this order";
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
                    ProductCountLabel.Text = $"Price ({shoppingCartViewModel.MyCartProducts.Count.ToString()}) Items";
                    _discount = _price - (_price / 2);
                    _totalPrice = (_price + 80) - _discount;
                    priceLabel.Text = $"${_price}";
                    discountLabel.Text = $"$ -{_discount}";
                    totalAmountLabel.Text = $"${_totalPrice}";
                    SavingLabel.Text = $"You'll save ${_discount} on this order";
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
                    _discount = _price - (_price / 2);
                    _totalPrice = (_price + 80) - _discount;
                    priceLabel.Text = $"${_price}";
                    discountLabel.Text = $"$ -{_discount}";
                    totalAmountLabel.Text = $"${_totalPrice}";
                    SavingLabel.Text = $"You'll save ${_discount} on this order";
                }
            }
        }

    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        popup.IsOpen = false;
    }
}