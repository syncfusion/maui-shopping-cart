namespace ShoppingCart;

public partial class SearchpageDesktop : ContentView
{
    ShoppingCartViewModel shoppingCartViewModel;
    Action _action;
	public SearchpageDesktop(ShoppingCartViewModel viewModel,string productname,Action action)
	{
		InitializeComponent();
        this.MinimumWidthRequest = 600;
        shoppingCartViewModel = viewModel;
        BindingContext = shoppingCartViewModel;
        productnamelabel.Text = productname;
        _action = action;
	}

    private void BackArrow_Tapped(object sender, TappedEventArgs e)
    {
        _action.Invoke();
    }

    private void SfListView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
    {
        if (e.DataItem is Product tappedProduct)
        {
            var SearchPageContent = new SearchpageDesktop(shoppingCartViewModel,productnamelabel.Text,_action);
            var productpageDesktop = new ProductPageDesktop(SearchPageContent, shoppingCartViewModel)
            {
                BindingContext = tappedProduct
            };

            // Add ProductDetailsView to the page
            Content = productpageDesktop;
        }
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

}