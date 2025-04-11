using System.Collections.ObjectModel;

namespace ShoppingCart;

public class ShoppingCartViewModel : ContentPage
{
    public string Email { get; set; } = "emmawilliam@gmail.com";
    public string Password { get; set; } = "Emma@2024";

    public ObservableCollection<SfRotatorItem> RotatorItems { get; set; }

    public class SfRotatorItem
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? ImageSource { get; set; }
    }


    public ShoppingCartViewModel()
    {
        RotatorItems = new ObservableCollection<SfRotatorItem>
            {
                new SfRotatorItem { Title = "Big Sale! Up to 75% Off! Grab Yours Now!", Subtitle = "Step up style - Find your perfect style", ImageSource = "shoes.png" },
                new SfRotatorItem { Title = "Carry Elegance Everywhere You Go!", Subtitle = "Stylish bags for every occasion", ImageSource = "bag.png" },
                new SfRotatorItem { Title = "Glorious Gowns! Step Into Grace!", Subtitle = "Find the perfect gown for your next event", ImageSource = "gown.png" },
                new SfRotatorItem { Title = "Sharp & Savvy Shirts! Embrace Style!", Subtitle = "Discover our collection of tailored shirts", ImageSource = "shirt1.png" },
                new SfRotatorItem { Title = "Terrific T-Shirts! Relax with Comfort and Chill!", Subtitle = "Comfortable and casual t-shirts for everyone", ImageSource = "shirt2.png" }
            };
    }

}