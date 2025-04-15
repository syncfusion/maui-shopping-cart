namespace ShoppingCart
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
#if ANDROID || IOS
            return new Window(new NavigationPage(new SignUpMobilePage()));
#else
            return new Window(new NavigationPage(new SignUpPageDesktop()));
#endif
        }
    }
}