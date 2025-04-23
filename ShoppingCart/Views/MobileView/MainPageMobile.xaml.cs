using Syncfusion.Maui.Rotator;
using System.Collections.ObjectModel;

namespace ShoppingCart
{
    public partial class MainPageMobile : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Product>? ColumnOneCollection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product>? ColumnTwoCollection { get; set; }

        public List<Product>? HomePageCollection { get; set; }

        ShoppingCartViewModel shoppingCartViewModel;

        public MainPageMobile()
        {
            InitializeComponent();
            shoppingCartViewModel = new ShoppingCartViewModel();
            BindingContext = shoppingCartViewModel;
            ArrangeControlInColumn();
        }

        private void ViewAll_Tapped(object sender, TappedEventArgs e)
        {
            TitleLabel.IsVisible = false;
            rotatorView.IsVisible = false;
            ViewAllLabel.IsVisible = false;
            ColumnOneCollection = new List<Product>();
            ColumnTwoCollection = new List<Product>();
            for (int i = 0; i < shoppingCartViewModel.Products.Count; i++)
            {
                if (i % 2 == 0)
                {
                    ColumnOneCollection.Add(shoppingCartViewModel.Products[i]);
                }
                else
                {
                    ColumnTwoCollection.Add(shoppingCartViewModel.Products[i]);
                }
            }

            BindableLayout.SetItemsSource(this.ColumnOneBorder, ColumnOneCollection);
            BindableLayout.SetItemsSource(this.ColumnTwoBorder, ColumnTwoCollection);
        }


        private void ArrangeControlInColumn()
        {
            ColumnOneCollection = new List<Product>();
            ColumnTwoCollection = new List<Product>();
            HomePageCollection = new List<Product>();
            for (int i=0;i<4;i++)
            {
                HomePageCollection.Add(shoppingCartViewModel.Products[i]);
            }

            for (int i = 0; i < HomePageCollection.Count; i++)
            {
                if (i % 2 == 0)
                {
                    ColumnOneCollection.Add(HomePageCollection[i]);
                }
                else
                {
                    ColumnTwoCollection.Add(HomePageCollection[i]);
                }
            }

            BindableLayout.SetItemsSource(this.ColumnOneBorder, ColumnOneCollection);
            BindableLayout.SetItemsSource(this.ColumnTwoBorder, ColumnTwoCollection);
        }

        private void Menu_Tapped(object sender, TappedEventArgs e)
        {
            rotatorView.IsVisible = false;
            TrendLabel.IsVisible=false;
            ViewAllLabel.IsVisible=false;
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

            ColumnOneCollection = new List<Product>();
            ColumnTwoCollection = new List<Product>();
            for (int i = 0; i < shoppingCartViewModel.FilteredProducts?.Count; i++)
            {
                if (i % 2 == 0)
                {
                    ColumnOneCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
                else
                {
                    ColumnTwoCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
            }

            BindableLayout.SetItemsSource(this.ColumnOneBorder, ColumnOneCollection);
            BindableLayout.SetItemsSource(this.ColumnTwoBorder, ColumnTwoCollection);
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
                        shoppingCartViewModel.FilteredProducts.Add(product);
                    }
                }
            }

            ColumnOneCollection = new List<Product>();
            ColumnTwoCollection = new List<Product>();
            for (int i = 0; i < shoppingCartViewModel.FilteredProducts.Count; i++)
            {
                if (i % 2 == 0)
                {
                    ColumnOneCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
                else
                {
                    ColumnTwoCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
            }

            BindableLayout.SetItemsSource(this.ColumnOneBorder, ColumnOneCollection);
            BindableLayout.SetItemsSource(this.ColumnTwoBorder, ColumnTwoCollection);
        }
    }
}
