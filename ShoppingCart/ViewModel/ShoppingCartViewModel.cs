using System.Collections.ObjectModel;

namespace ShoppingCart;

public class ShoppingCartViewModel : ContentPage
{
    public string Email { get; set; } = "emmawilliam@gmail.com";
    public string Password { get; set; } = "Emma@2024";

    public ObservableCollection<SfRotatorItem> RotatorItems { get; set; }
    public ObservableCollection<SfRotatorItem> DesktopRotatorItems { get; set; }
    public ObservableCollection<String> Catagories { get; set; }

    public class SfRotatorItem
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Tagline {  get; set; }
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

        DesktopRotatorItems = new ObservableCollection<SfRotatorItem>
        {
                new SfRotatorItem { Title = "Big sale! Upto 75% off! Combo OfferBuy 2 items save 5%; Buy 3 save 7%; Buy 4+ save 10%", Subtitle = "Grab yours now! ", Tagline="Step up style - Find your perfect style", ImageSource = "shoes.png" },
                new SfRotatorItem { Title = "Style meets savings! Up to 60% off! Combo Offer ; Buy 2 bags save 5%; Buy 3 save 10%", Subtitle = "Grab Yours Now!", Tagline="Accessorize in style – carry confidence everywhere", ImageSource = "bag.png" },
                new SfRotatorItem { Title = "Elegant Looks! Up to 80% off! Combo Offer ;Buy 2 gowns save 7%; Buy 3 save 10%; Buy 4+ save 20%", Subtitle = "Grab Yours Now!",Tagline="Turn heads – find the gown that speaks your style", ImageSource = "gown.png" },
                new SfRotatorItem { Title = "Smart & Stylish! Up to 65% off! Combo Offer ; Buy 2 shirts save 5%; Buy 3 save 8%; Buy 4+ save 15%", Subtitle = "Grab Yours Now!",Tagline="Elevate your daily look – shop the chic edit", ImageSource = "shirt1.png" },
                new SfRotatorItem { Title = "Trendy Tees! Up to 70% off! Combo Offer ; Buy 2 save 5%; Buy 3 save 7%; Buy 4+ save 12%", Subtitle = "Grab Yours Now!", Tagline="Your comfort, your vibe – find the perfect tee", ImageSource = "shirt2.png" }
        };

        Catagories = new ObservableCollection<String>
        {
             "Men", "Women" , "Kids", "Accessories", "Shoes","Sports","Beauty","Electronics"
        };
    }

}