using ShoppingCart;

namespace ShoppingCart
{
    public partial class MainPageDesktop : ContentPage
    {
        List<Border> _tabBorders = new List<Border>();
        ShoppingCartViewModel shoppingCartViewModel;
        Border _selectedBorder;
        public MainPageDesktop(ShoppingCartViewModel viewModel)
        {
            InitializeComponent();
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
            ProfilePageDesktop profilePage;

            if (_selectedBorder == HomeBorder)
            {
                profilePage = new ProfilePageDesktop(() => NavigateBackToHome(), shoppingCartViewModel);
                selectedtab.Children.Clear();
                selectedtab.Children.Add(profilePage);
            }
            else if (_selectedBorder == AccountBorder)
            {
                profilePage = new ProfilePageDesktop(() => NavigateBackToSettings(), shoppingCartViewModel);
                selectedtab.Children.Clear();
                selectedtab.Children.Add(profilePage);
            }
            else if (_selectedBorder == SavedProductsBorder)
            {
                profilePage = new ProfilePageDesktop(() => NavigateBackToSavedProducts(), shoppingCartViewModel);
                selectedtab.Children.Clear();
                selectedtab.Children.Add(profilePage);
            }
            else if(_selectedBorder == CartBorder)
            {
                profilePage = new ProfilePageDesktop(() => NavigateBackToMyCart(), shoppingCartViewModel);
                selectedtab.Children.Clear();
                selectedtab.Children.Add(profilePage);
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
            if (_selectedBorder != null && _selectedBorder.Content is HorizontalStackLayout prevLayout)
            {
                _selectedBorder.BackgroundColor = Colors.Transparent;

                if (prevLayout.Children.Count >= 2)
                {
                    var prevIconLabel = prevLayout.Children[0] as Label;
                    var prevTextLabel = prevLayout.Children[1] as Label;

                    if (Application.Current!.RequestedTheme == AppTheme.Dark)
                    {
                        prevIconLabel!.TextColor = Color.FromArgb("#C9C6C8");
                        prevTextLabel!.TextColor = Colors.White;
                    }
                    else
                    {
                        prevIconLabel!.TextColor = Color.FromArgb("#474648"); // icon color light
                        prevTextLabel!.TextColor = Color.FromArgb("#313032"); // content text color light
                    }
                }
            }

            // Set new selection
            border.BackgroundColor = Color.FromArgb("#7633DA");

            if (border.Content is HorizontalStackLayout layout && layout.Children.Count >= 2)
            {
                var iconLabel = layout.Children[0] as Label;
                var textLabel = layout.Children[1] as Label;
                var text = textLabel?.Text;

                // Selected tab color
                iconLabel!.TextColor = Colors.White;
                textLabel!.TextColor = Colors.White;

                ContentView selectedContent = new();
                selectedContent.IsVisible = true;

                switch (text)
                {
                    case "Home":
                        selectedContent = new HomePageDesktop(shoppingCartViewModel);
                        break;
                    case "Saved Products":
                        selectedContent=new SavedItemsPageDesktop(shoppingCartViewModel);
                        break;
                    case "My Cart":
                        selectedContent = new MyCartPageDesktop(shoppingCartViewModel);
                        break;
                    case "My Account":
                        selectedContent = new SettingsPageDesktop(shoppingCartViewModel);
                        break;
                }

                _selectedBorder = border;
                selectedtab.Children.Clear();
                selectedtab.Children.Add(selectedContent);
            }
        }
    }
}
