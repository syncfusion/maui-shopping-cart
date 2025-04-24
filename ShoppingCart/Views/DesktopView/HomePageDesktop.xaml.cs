using Syncfusion.Maui.Rotator;
using System.Collections.ObjectModel;
using static ShoppingCart.ShoppingCartViewModel;

namespace ShoppingCart
{
    public partial class HomePageDesktop : ContentView
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Product>? ColumnOneCollection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product>? ColumnTwoCollection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product>? ColumnThreeCollection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Product>? ColumnFourCollection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Product>? ColumnFiveCollection { get; set; }


        ShoppingCartViewModel shoppingCartViewModel = new ShoppingCartViewModel();
        public HomePageDesktop()
        {
            InitializeComponent();
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
             BindingContext = shoppingCartViewModel;
        }


        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                UpdateColumn(width);
            });
        }

        internal void UpdateColumn(double width)
        {
            if (width > 900)
            {
                this.ProductGrid.ColumnDefinitions.Clear();
                this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                ArrangeControlInFiveColumn();
            }
            if (width > 700 && width <= 900)
            {
                if(this.ProductGrid!=null)
                {
                    this.ProductGrid.ColumnDefinitions.Clear();
                    this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    ArrangeControlInThreeColumn();
                }
            }
            else if(width < 700)
            {
                if (this.ProductGrid != null)
                {
                    this.ProductGrid.ColumnDefinitions.Clear();
                    this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    this.ProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    ArrangeControlInTwoColumn();
                }
            }
        }

        private void ArrangeControlInTwoColumn()
        {
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
            ColumnThreeBorder.IsVisible = false;
            ColumnFourBorder.IsVisible = false;
            ColumnFiveBorder.IsVisible = false;
            BindableLayout.SetItemsSource(this.ColumnThreeBorder, null);
            BindableLayout.SetItemsSource(this.ColumnFourBorder, null);
            BindableLayout.SetItemsSource(this.ColumnFiveBorder, null);
            BindableLayout.SetItemsSource(this.ColumnOneBorder, ColumnOneCollection);
            BindableLayout.SetItemsSource(this.ColumnTwoBorder, ColumnTwoCollection);
        }

        private void ArrangeControlInThreeColumn()
        {
            ColumnOneCollection = new List<Product>();
            ColumnTwoCollection = new List<Product>();
            ColumnThreeCollection = new List<Product>();
            for (int i = 0; i < shoppingCartViewModel.FilteredProducts?.Count; i++)
            {
                if (i % 3 == 0)
                {
                    ColumnOneCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
                else if (i % 3 == 1)
                {
                    ColumnTwoCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
                else
                {
                    ColumnThreeCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
            }
            ColumnThreeBorder.IsVisible = true;
            ColumnFourBorder.IsVisible = false;
            ColumnFiveBorder.IsVisible = false;
            BindableLayout.SetItemsSource(this.ColumnFourBorder, null);
            BindableLayout.SetItemsSource(this.ColumnFiveBorder, null);
            BindableLayout.SetItemsSource(this.ColumnOneBorder, ColumnOneCollection);
            BindableLayout.SetItemsSource(this.ColumnTwoBorder, ColumnTwoCollection);
            BindableLayout.SetItemsSource(this.ColumnThreeBorder, ColumnThreeCollection);
        }
        private void ArrangeControlInFiveColumn()
        {
            ColumnOneCollection = new List<Product>();
            ColumnTwoCollection = new List<Product>();
            ColumnThreeCollection = new List<Product>();
            ColumnFourCollection = new List<Product>();
            ColumnFiveCollection = new List<Product>();
            for (int i = 0; i < shoppingCartViewModel.FilteredProducts?.Count; i++)
            {
                if (i % 5 == 0)
                {
                    ColumnOneCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
                else if (i % 5 == 1)
                {
                    ColumnTwoCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
                else if (i % 5 == 2)
                {
                    ColumnThreeCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
                else if (i % 5 == 3)
                {
                    ColumnFourCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
                else
                {
                    ColumnFiveCollection.Add(shoppingCartViewModel.FilteredProducts[i]);
                }
            }
            ColumnThreeBorder.IsVisible = true;
            ColumnFourBorder.IsVisible = true;
            ColumnFiveBorder.IsVisible = true;
            BindableLayout.SetItemsSource(this.ColumnOneBorder, null);
            BindableLayout.SetItemsSource(this.ColumnTwoBorder, null);
            BindableLayout.SetItemsSource(this.ColumnThreeBorder, null);
            BindableLayout.SetItemsSource(this.ColumnFourBorder, null);
            BindableLayout.SetItemsSource(this.ColumnFiveBorder, null);

            BindableLayout.SetItemsSource(this.ColumnOneBorder, ColumnOneCollection);
            BindableLayout.SetItemsSource(this.ColumnTwoBorder, ColumnTwoCollection);
            BindableLayout.SetItemsSource(this.ColumnThreeBorder, ColumnThreeCollection);
            BindableLayout.SetItemsSource(this.ColumnFourBorder, ColumnThreeCollection);
            BindableLayout.SetItemsSource(this.ColumnFiveBorder, ColumnThreeCollection);

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
            UpdateColumn(this.Width);
        }
    }
}
