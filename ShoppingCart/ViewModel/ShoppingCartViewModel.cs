using System.Collections.ObjectModel;

namespace ShoppingCart;

public class ShoppingCartViewModel : ContentPage
{
    public UserProfile CurrentUser { get; set; }

    public ObservableCollection<SfRotatorItem> RotatorItems { get; set; }
    public ObservableCollection<SfRotatorItem> DesktopRotatorItems { get; set; }
    public ObservableCollection<String> Catagories { get; set; }
    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<Product>? FilteredProducts { get; set; }
    public ObservableCollection<Product>? SavedProducts { get; set; } = new ObservableCollection<Product>();
    public ObservableCollection<Product>? MyCartProducts { get; set; } = new ObservableCollection<Product>();

    public ObservableCollection<Product> OrderedProducts { get; set; } = new ObservableCollection<Product> { };
    public ObservableCollection<string> GenderOptions { get; set; }

    private string _tempUserName;
    public string TempUserName
    {
        get => _tempUserName;
        set
        {
            _tempUserName = value;
            OnPropertyChanged();
        }
    }

    public class SfRotatorItem
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Tagline {  get; set; }
        public string? ImageSource { get; set; }
    }

    public ShoppingCartViewModel()
    {
        GetUserProfileDetails();

        GenderOptions = new ObservableCollection<string> { "Male", "Female", "Non-binary", "Other" };

        RotatorItems = new ObservableCollection<SfRotatorItem>
            {
                new SfRotatorItem { Title = "Big Sale! Up to 75% Off! Grab Yours Now!", Subtitle = "Step up style - Find your perfect style", ImageSource = "redcanvas1.png" },
                new SfRotatorItem { Title = "Carry Elegance Everywhere You Go!", Subtitle = "Stylish bags for every occasion", ImageSource = "maroonhandbag1.png" },
                new SfRotatorItem { Title = "Glorious Gowns! Step Into Grace!", Subtitle = "Find the perfect gown for your next event", ImageSource = "peachdress.png" },
                new SfRotatorItem { Title = "Sharp & Savvy Shirts! Embrace Style!", Subtitle = "Discover our collection of tailored shirts", ImageSource = "whitetshirt1.png" },
                new SfRotatorItem { Title = "Terrific T-Shirts! Relax with Comfort and Chill!", Subtitle = "Comfortable and casual t-shirts for everyone", ImageSource = "chevronpullover1.png" }
            };

        DesktopRotatorItems = new ObservableCollection<SfRotatorItem>
        {
                new SfRotatorItem { Title = "Big sale! Upto 75% off! Combo OfferBuy 2 items save 5%; Buy 3 save 7%; Buy 4+ save 10%", Subtitle = "Grab yours now! ", Tagline="Step up style - Find your perfect style", ImageSource = "redcanvas1.png" },
                new SfRotatorItem { Title = "Style meets savings! Up to 60% off! Combo Offer ; Buy 2 bags save 5%; Buy 3 save 10%", Subtitle = "Grab Yours Now!", Tagline="Accessorize in style ! carry confidence everywhere", ImageSource = "maroonhandbag1.png" },
                new SfRotatorItem { Title = "Elegant Looks! Up to 80% off! Combo Offer ;Buy 2 gowns save 7%; Buy 3 save 10%; Buy 4+ save 20%", Subtitle = "Grab Yours Now!",Tagline="Turn heads ! find the gown that speaks your style", ImageSource = "peachdress.png" },
                new SfRotatorItem { Title = "Smart & Stylish! Up to 65% off! Combo Offer ; Buy 2 shirts save 5%; Buy 3 save 8%; Buy 4+ save 15%", Subtitle = "Grab Yours Now!",Tagline="Elevate your daily look ! shop the chic edit", ImageSource = "whitetshirt1.png" },
                new SfRotatorItem { Title = "Trendy Tees! Up to 70% off! Combo Offer ; Buy 2 save 5%; Buy 3 save 7%; Buy 4+ save 12%", Subtitle = "Grab Yours Now!", Tagline="Your comfort, your vibe ! find the perfect tee", ImageSource = "chevronpullover1.png" }
        };

        Catagories = new ObservableCollection<String>
        {
             "Men", "Women" , "Kids", "Accessories", "Shoes","Sports","Beauty","Electronics"
        };

        Products = new ObservableCollection<Product>
        {
            // Men Category
           new Product { Name = "Men's White Graphic T-Shirt", ImageUrl = "whitetshirt1.png", PreviewOneImageUrl = "whitetshirt2.png", PreviewTwoImageUrl = "whitetshirt3.png", Description = "White graphic tee with bold design.", Price = 22.00m, Category = "Men", Rating = 4.4, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "T-Shirt", "Graphic", "Casual" }, IsAddedToCart = false },
           new Product { Name = "Men's Black Hoodie", ImageUrl = "blackhoodie1.png", PreviewOneImageUrl = "blackhoodie2.png", PreviewTwoImageUrl = "blackhoodie3.png", PreviewThreeImageUrl = "blackhoodie4.png", Description = "Classic black hoodie for cool days.", Price = 45.00m, Category = "Men", Rating = 4.6, IsSaved = true, PurchasedCount = 65, Tags = new List<string> { "Hoodie", "Black", "Warm" }, IsAddedToCart = false },
           new Product { Name = "Men's Black Sweater", ImageUrl = "blacksweater1.png", PreviewOneImageUrl = "blacksweater2.png", Description = "Warm black sweater with a unique pattern.", Price = 40.00m, Category = "Men", Rating = 4.5, IsSaved = true, PurchasedCount = 55, Tags = new List<string> { "Sweater", "Black", "Casual" }, IsAddedToCart = false },
           new Product { Name = "Men's Blue Cardigan", ImageUrl = "bluecardigan1.png", PreviewOneImageUrl = "bluecardigan2.png", Description = "Elegant blue cardigan for stylish layering.", Price = 38.00m, Category = "Men", Rating = 4.3, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Cardigan", "Blue", "Layering" }, IsAddedToCart = false },
           new Product { Name = "Men's Chevron Pullover", ImageUrl = "chevronpullover1.png", PreviewOneImageUrl = "chevronpullover2.png", Description = "Chevron patterned pullover for a bold look.", Price = 42.00m, Category = "Men", Rating = 4.7, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "Pullover", "Patterned", "Bold" }, IsAddedToCart = false },
           new Product { Name = "Men's Yellow Hoodie", ImageUrl = "yellowhoodie1.png", PreviewOneImageUrl = "yellowhoodie2.png", Description = "Bright yellow hoodie to brighten your day.", Price = 41.00m, Category = "Men", Rating = 4.6, IsSaved = false, PurchasedCount = 50, Tags = new List<string> { "Hoodie", "Yellow", "Casual" }, IsAddedToCart = false },
           new Product { Name = "Men's Striped Rugby Shirt", ImageUrl = "stripedrugby.png", PreviewOneImageUrl = "stripedrugby1.png", PreviewTwoImageUrl = "stripedrugby3.png", PreviewThreeImageUrl = "stripedrugby4.png", Description = "Classic striped rugby shirt for a sporty look.", Price = 36.00m, Category = "Men", Rating = 4.8, IsSaved = true, PurchasedCount = 75, Tags = new List<string> { "Rugby Shirt", "Striped", "Sporty" }, IsAddedToCart = false },

            // Women Category
           new Product { Name = "Women's Yellow Hoodie", ImageUrl = "womenyellowhoodie.png", PreviewOneImageUrl = "womenyellowhoodie1.png", PreviewTwoImageUrl = "womenyellowhoodie2.png",PreviewThreeImageUrl="womenyellowhoodie3.png", Description = "Vibrant yellow hoodie, cozy and warm.", Price = 40.00m, Category = "Women", Rating = 4.6, IsSaved = false, PurchasedCount = 50, Tags = new List<string> { "Hoodie", "Yellow", "Warm" }, IsAddedToCart = false },
           new Product { Name = "Women's Mint Hoodie", ImageUrl = "minthoodie.png", PreviewOneImageUrl = "minthoodie2.png", Description = "Fresh minty green hoodie for comfort.", Price = 39.00m, Category = "Women", Rating = 4.5, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Hoodie", "Mint", "Comfort" }, IsAddedToCart = false },
           new Product { Name = "Women's Red Varsity Jacket", ImageUrl = "redvarsity.png", PreviewOneImageUrl = "redvarsity1.png", PreviewTwoImageUrl = "redvarsity2.png", Description = "Classic red varsity jacket with white sleeves.", Price = 60.00m, Category = "Women", Rating = 4.8, IsSaved = false, PurchasedCount = 70, Tags = new List<string> { "Jacket", "Varsity", "Red" }, IsAddedToCart = false },
           new Product { Name = "Women's Pink Graphic Tee", ImageUrl = "pinkgraphic.png", PreviewOneImageUrl = "pinkgraphic1.png",PreviewTwoImageUrl="pinkgraphic2.png",PreviewThreeImageUrl="pinkgraphic3.png", Description = "Funky pink graphic t-shirt for casual days.", Price = 25.00m, Category = "Women", Rating = 4.4, IsSaved = false, PurchasedCount = 38, Tags = new List<string> { "T-Shirt", "Pink", "Graphic" }, IsAddedToCart = true },
           new Product { Name = "Women's Peach Dress", ImageUrl = "peachdress.png", PreviewOneImageUrl = "peachdress2.png", PreviewTwoImageUrl = "peachdress3.png", Description = "Elegant peach dress with a flared design.", Price = 48.00m, Category = "Women", Rating = 4.7, IsSaved = false, PurchasedCount = 55, Tags = new List<string> { "Dress", "Peach", "Elegant" }, IsAddedToCart = false },
           new Product { Name = "Women's Green Dress", ImageUrl = "greendress.png", PreviewOneImageUrl = "greendress1.png", PreviewTwoImageUrl = "greendress2.png",PreviewThreeImageUrl="greendress3.png", Description = "Chic green dress perfect for outings.", Price = 50.00m, Category = "Women", Rating = 4.8, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "Dress", "Green", "Chic" }, IsAddedToCart = false },
           new Product { Name = "Women's Blue Patterned Dress", ImageUrl = "bluepattern.png", PreviewOneImageUrl = "bluepattern2.png", PreviewTwoImageUrl = "bluepattern3.png", Description = "Stylish blue patterned dress for all occasions.", Price = 55.00m, Category = "Women", Rating = 4.9, IsSaved = true, PurchasedCount = 65, Tags = new List<string> { "Dress", "Blue", "Patterned" }, IsAddedToCart = false },
           new Product { Name = "Women's Yellow and Black Jacket", ImageUrl = "yellowblackjacket.png", PreviewOneImageUrl = "yellowblackjacket2.png",PreviewTwoImageUrl="yellowblackjacket3.png", Description = "Trendy yellow and black jacket for a bold look.", Price = 58.00m, Category = "Women", Rating = 4.7, IsSaved = true, PurchasedCount = 58, Tags = new List<string> { "Jacket", "Yellow", "Black" }, IsAddedToCart = false },
            // Kids Category
           new Product { Name = "Kid's Green Jacket", ImageUrl = "greenjacket.png", PreviewOneImageUrl = "greenjacket2.png", Description = "Warm green jacket for kids' outdoor adventures.", Price = 30.00m, Category = "Kids", Rating = 4.5, IsSaved = false, PurchasedCount = 25, Tags = new List<string> { "Jacket", "Green", "Outdoor" }, IsAddedToCart = false },
           new Product { Name = "Kid's Yellow Pattern T-Shirt", ImageUrl = "yellowpatternshirt.png", PreviewOneImageUrl = "yellowpatternshirt2.png", PreviewTwoImageUrl = "yellowpatternshirt3.png",PreviewThreeImageUrl="yellowpatternshirt4.png" ,Description = "Bright t-shirt with fun yellow patterns.", Price = 12.00m, Category = "Kids", Rating = 4.4, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "T-Shirt", "Yellow", "Pattern" }, IsAddedToCart = false },
           new Product { Name = "Kid's Green Romper", ImageUrl = "greenromper.png", PreviewOneImageUrl = "greenromper2.png",PreviewTwoImageUrl = "greenromper3.png",PreviewThreeImageUrl = "greenromper4.png", Description = "Comfortable green romper for playtime.", Price = 25.00m, Category = "Kids", Rating = 4.6, IsSaved = true, PurchasedCount = 35, Tags = new List<string> { "Romper", "Green" }, IsAddedToCart = false },
           new Product { Name = "Kid's Floral Dress", ImageUrl = "floraldress.png", PreviewOneImageUrl = "floraldress2.png", Description = "Adorable dress with a cute floral pattern.", Price = 22.00m, Category = "Kids", Rating = 4.5, IsSaved = false, PurchasedCount = 32, Tags = new List<string> { "Dress", "Floral", "Cute" }, IsAddedToCart = false },
           new Product { Name = "Kid's Blue Patterned Pants", ImageUrl = "bluepants.png", PreviewOneImageUrl = "bluepants1.png", Description = "Stylish blue patterned pants for kids.", Price = 18.00m, Category = "Kids", Rating = 4.5, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "Pants", "Blue", "Patterned" }, IsAddedToCart = false },
           new Product { Name = "Kid's Beige Backpack", ImageUrl = "beigebackpack.png", PreviewOneImageUrl = "beigebackpack2.png", PreviewTwoImageUrl = "beigebackpack3.png", Description = "Durable beige backpack for school.", Price = 20.00m, Category = "Kids", Rating = 4.7, IsSaved = true, PurchasedCount = 50, Tags = new List<string> { "Backpack", "Beige", "School" }, IsAddedToCart = false },
           new Product { Name = "Kid's Lime Backpack", ImageUrl = "limebackpack.png", PreviewOneImageUrl = "limebackpack2.png",PreviewTwoImageUrl = "limebackpack3.png", Description = "Bright lime backpack for stylish storage.", Price = 22.00m, Category = "Kids", Rating = 4.8, IsSaved = true, PurchasedCount = 55, Tags = new List<string> { "Backpack", "Lime", "Stylish" }, IsAddedToCart = false },

            // Accessories Category
            new Product { Name = "Green Cosmetic Bag", ImageUrl = "greenbag.png", PreviewOneImageUrl = "greenbag1.png", PreviewTwoImageUrl = "greenbag2.png",PreviewThreeImageUrl = "greenbag3.png", Description = "Compact green cosmetic bag.", Price = 15.00m, Category = "Accessories", Rating = 4.5, IsSaved = false, PurchasedCount = 30, Tags = new List<string> { "Cosmetic Bag", "Green", "Travel" }, IsAddedToCart = false },
            new Product { Name = "Maroon Handbag", ImageUrl = "maroonhandbag.png", PreviewOneImageUrl = "maroonhandbag1.png", PreviewTwoImageUrl = "maroonhandbag2.png", PreviewThreeImageUrl = "maroonhandbag3.png", Description = "Elegant maroon handbag for daily use.", Price = 45.00m, Category = "Accessories", Rating = 4.7, IsSaved = true, PurchasedCount = 50, Tags = new List<string> { "Handbag", "Maroon" }, IsAddedToCart = false },
            new Product { Name = "Blue and Yellow Cap", ImageUrl = "blueyellowcap.png", PreviewOneImageUrl = "blueyellowcap1.png", PreviewTwoImageUrl = "blueyellowcap2.png", PreviewThreeImageUrl = "blueyellowcap3.png", Description = "Sporty cap in blue and yellow.", Price = 20.00m, Category = "Accessories", Rating = 4.6, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "Cap", "Blue", "Yellow" }, IsAddedToCart = false },
            new Product { Name = "Beige Cap", ImageUrl = "beigecap.png", PreviewOneImageUrl = "beigecap1.png", PreviewTwoImageUrl = "beigecap2.png", PreviewThreeImageUrl = "beigecap3.png", Description = "Classic beige cap for casual wear.", Price = 18.00m, Category = "Accessories", Rating = 4.5, IsSaved = false, PurchasedCount = 35, Tags = new List<string> { "Cap", "Beige" }, IsAddedToCart = false },
            new Product { Name = "Black Keychain", ImageUrl = "blackkeychain.png", PreviewOneImageUrl = "blackkeychain1.png", PreviewTwoImageUrl = "blackkeychain2.png", PreviewThreeImageUrl = "blackkeychain3.png", Description = "Sleek black keychain.", Price = 10.00m, Category = "Accessories", Rating = 4.8, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "Keychain", "Black" }, IsAddedToCart = false },
            new Product { Name = "Blue Round Keychain", ImageUrl = "blueroundkeychain.png", PreviewOneImageUrl = "blueroundkeychain1.png", PreviewTwoImageUrl = "blueroundkeychain2.png", Description = "Round blue keychain with logo.", Price = 12.00m, Category = "Accessories", Rating = 4.6, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Keychain", "Blue" }, IsAddedToCart = false },
            new Product { Name = "Patterned Tie", ImageUrl = "patternedtie.png", PreviewOneImageUrl = "patternedtie1.png", PreviewTwoImageUrl = "patternedtie2.png", PreviewThreeImageUrl = "patternedtie3.png", Description = "Stylish tie with a unique pattern.", Price = 28.00m, Category = "Accessories", Rating = 4.9, IsSaved = true, PurchasedCount = 40, Tags = new List<string> { "Tie", "Patterned" }, IsAddedToCart = false },            

            // Shoes Category
           new Product { Name = "Blue Slides", ImageUrl = "blueslides.png", PreviewOneImageUrl = "blueslides1.png",PreviewTwoImageUrl="blueslides2.png", Description = "Comfortable blue slides, perfect for casual wear.", Price = 20.00m, Category = "Shoes", Rating = 4.5, IsSaved = false, PurchasedCount = 30, Tags = new List<string> { "Slides", "Blue", "Casual" }, IsAddedToCart = false },
           new Product { Name = "Purple Sneakers", ImageUrl = "purplesneakers.png", PreviewOneImageUrl = "purplesneakers1.png", PreviewTwoImageUrl = "purplesneakers2.png", Description = "Stylish purple sneakers with a modern design.", Price = 45.00m, Category = "Shoes", Rating = 4.7, IsSaved = true, PurchasedCount = 50, Tags = new List<string> { "Sneakers", "Purple", "Modern" }, IsAddedToCart = false },
           new Product { Name = "Green Sports Shoes", ImageUrl = "greensportsshoes.png", PreviewOneImageUrl = "greensportsshoes1.png", PreviewTwoImageUrl = "greensportsshoes2.png", PreviewThreeImageUrl = "greensportsshoes3.png", Description = "Lightweight green shoes for sports.", Price = 60.00m, Category = "Shoes", Rating = 4.6, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "Sports Shoes", "Green", "Lightweight" }, IsAddedToCart = true },
           new Product { Name = "Floral High Heels", ImageUrl = "floralheels.png", PreviewOneImageUrl = "floralheels1.png",PreviewTwoImageUrl="floralheels2.png", PreviewThreeImageUrl="floralheels3.png",PreviewFourImageUrl="floralheels4.png",  Description = "Elegant high heels with a floral pattern.", Price = 80.00m, Category = "Shoes", Rating = 4.8, IsSaved = true, PurchasedCount = 70, Tags = new List<string> { "High Heels", "Floral", "Elegant" }, IsAddedToCart = false },
           new Product { Name = "Comic Print Sneakers", ImageUrl = "comicprint.png", PreviewOneImageUrl = "comicprint1.png", PreviewTwoImageUrl = "comicprint2.png", PreviewThreeImageUrl = "comicprint3.png", Description = "Unique sneakers with a vibrant comic print.", Price = 50.00m, Category = "Shoes", Rating = 4.7, IsSaved = false, PurchasedCount = 55, Tags = new List<string> { "Sneakers", "Comic", "Vibrant" }, IsAddedToCart = false },
           new Product { Name = "Red Canvas Shoes", ImageUrl = "redcanvas.png", PreviewOneImageUrl = "redcanvas1.png", PreviewTwoImageUrl = "redcanvas2.png", PreviewThreeImageUrl = "redcanvas3.png", Description = "Classic red canvas shoes for everyday wear.", Price = 30.00m, Category = "Shoes", Rating = 4.5, IsSaved = false, PurchasedCount = 35, Tags = new List<string> { "Canvas Shoes", "Red", "Classic" }, IsAddedToCart = false },
           new Product { Name = "Graphic High Tops", ImageUrl = "graphichightops.png", PreviewOneImageUrl = "graphichightops1.png",PreviewTwoImageUrl="graphichightops2.png", PreviewThreeImageUrl="graphichightops3.png", PreviewFourImageUrl="graphichightops4.png", Description = "High-top sneakers with a bold graphic design.", Price = 55.00m, Category = "Shoes", Rating = 4.9, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "High Tops", "Graphic", "Bold" }, IsAddedToCart = false },

            // Sports Category
           new Product { Name = "Black Sports Leggings", ImageUrl = "blackleggings.png", PreviewOneImageUrl = "blackleggings1.png", PreviewTwoImageUrl = "blackleggings2.png", PreviewThreeImageUrl = "blackleggings3.png", Description = "Flexible leggings for sports and workouts.", Price = 30.00m, Category = "Sports", Rating = 4.6, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Leggings", "Sports", "Black" }, IsAddedToCart = false },
            new Product { Name = "Blue Sports Jersey", ImageUrl = "bluejersey.png", PreviewOneImageUrl = "bluejersey1.png", PreviewTwoImageUrl = "bluejersey2.png", Description = "Breathable sports jersey with number 20.", Price = 40.00m, Category = "Sports", Rating = 4.8, IsSaved = true, PurchasedCount = 70, Tags = new List<string> { "Jersey", "Sports", "Blue" }, IsAddedToCart = false },
            new Product { Name = "Red Gradient Tank Top", ImageUrl = "redtanktop.png", PreviewOneImageUrl = "redtanktop1.png", PreviewTwoImageUrl = "redtanktop2.png", Description = "Stylish red tank top with a gradient design.", Price = 25.00m, Category = "Sports", Rating = 4.6, IsSaved = false, PurchasedCount = 35, Tags = new List<string> { "Tank Top", "Sports", "Red" }, IsAddedToCart = false },
            new Product { Name = "Purple Sports Gloves", ImageUrl = "purplegloves.png", PreviewOneImageUrl = "purplegloves1.png", PreviewTwoImageUrl = "purplegloves2.png", Description = "Protection and grip in a stylish design.", Price = 25.00m, Category = "Sports", Rating = 4.5, IsSaved = false, PurchasedCount = 30, Tags = new List<string> { "Gloves", "Sports", "Purple" }, IsAddedToCart = false },
            new Product { Name = "Green Sports Bag", ImageUrl = "greensportsbag.png", PreviewOneImageUrl = "greensportsbag1.png", PreviewTwoImageUrl = "greensportsbag2.png", Description = "Durable sports bag with ample space.", Price = 35.00m, Category = "Sports", Rating = 4.6, IsSaved = true, PurchasedCount = 50, Tags = new List<string> { "Bag", "Sports", "Green" }, IsAddedToCart = false },
            new Product { Name = "Yellow Running Shoes", ImageUrl = "yellowrunningshoes.png", PreviewOneImageUrl = "yellowrunningshoes1.png",PreviewTwoImageUrl="yellowrunningshoes2.png",PreviewThreeImageUrl="yellowrunningshoes3.png", Description = "Lightweight shoes built for speed.", Price = 55.00m, Category = "Sports", Rating = 4.9, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "Running Shoes", "Sports", "Yellow" }, IsAddedToCart = false },
            new Product { Name = "Pink Training T-Shirt", ImageUrl = "pinktrainingshirt.png", PreviewOneImageUrl = "pinktrainingshirt1.png",PreviewTwoImageUrl="pinktrainingshirt2.png",Description = "Comfortable tee for training sessions.", Price = 28.00m, Category = "Sports", Rating = 4.7, IsSaved = true, PurchasedCount = 40, Tags = new List<string> { "T-Shirt", "Sports", "Pink" }, IsAddedToCart = false },           

            // Beauty Category
            new Product { Name = "Foundation", ImageUrl = "foundation.png",PreviewOneImageUrl="foundation.png", Description = "Smooth foundation for a flawless finish.", Price = 25.00m, Category = "Beauty", Rating = 4.5, IsSaved = false, PurchasedCount = 85, Tags = new List<string> { "Foundation", "Makeup" }, IsAddedToCart = false },
            new Product { Name = "Pink Lipstick", ImageUrl = "pinklipstick.png",PreviewOneImageUrl="pinklipstick1.png",PreviewTwoImageUrl="pinklipstick2.png",PreviewThreeImageUrl="pinklipstick3.png",  Description = "Bright pink lipstick for a bold look.", Price = 15.00m, Category = "Beauty", Rating = 4.4, IsSaved = false, PurchasedCount = 70, Tags = new List<string> { "Lipstick", "Pink", "Makeup" }, IsAddedToCart = false },
            new Product { Name = "Sunscreen", ImageUrl = "sunscreen.png",PreviewOneImageUrl="sunscreen1.png",PreviewTwoImageUrl="sunscreen2.png", Description = "Protective sunscreen with SPF 50.", Price = 18.00m, Category = "Beauty", Rating = 4.6, IsSaved = false, PurchasedCount = 120, Tags = new List<string> { "Sunscreen", "SPF", "Protection" }, IsAddedToCart = false },
            new Product { Name = "Red Lipstick", ImageUrl = "redlipstick.png",PreviewOneImageUrl="redlipstick1.png",PreviewTwoImageUrl="redlipstick2.png" , Description = "Vibrant red lipstick with long-lasting formula.", Price = 15.00m, Category = "Beauty", Rating = 4.7, IsSaved = true, PurchasedCount = 110, Tags = new List<string> { "Lipstick", "Red", "Makeup" }, IsAddedToCart = false },
            new Product { Name = "Lip Balm", ImageUrl = "lipbalm.png",PreviewOneImageUrl="lipbalm1.png",PreviewTwoImageUrl="lipbalm2.png", Description = "Moisturizing lip balm for soft, hydrated lips.", Price = 8.00m, Category = "Beauty", Rating = 4.3, IsSaved = true, PurchasedCount = 90, Tags = new List<string> { "Lip Balm", "Moisturizing", "Hydration" }, IsAddedToCart = false },

            // Electronics Category
            new Product { Name = "Smartwatch Series X", ImageUrl = "smartwatchblack.png", PreviewOneImageUrl = "smartwatchblack1.png", PreviewTwoImageUrl = "smartwatchblack2.png", Description = "Advanced smartwatch with fitness tracking and notifications.", Price = 199.99m, Category = "Electronics", Rating = 4.6, IsSaved = false, PurchasedCount = 150, Tags = new List<string> { "Smartwatch", "Fitness", "Wearable" }, IsAddedToCart = false },
            new Product { Name = "Wireless Earbuds Pro", ImageUrl = "earbudswhite.png", PreviewOneImageUrl = "earbudswhite1.png", PreviewTwoImageUrl = "earbudswhite2.png", Description = "Noise-canceling wireless earbuds with crystal-clear sound.", Price = 129.00m, Category = "Electronics", Rating = 4.5, IsSaved = false, PurchasedCount = 240, Tags = new List<string> { "Earbuds", "Wireless", "Audio" }, IsAddedToCart = false },
            new Product { Name = "All-in-One Desktop", ImageUrl = "desktoppink.png", PreviewOneImageUrl = "desktoppink1.png", PreviewTwoImageUrl = "desktoppink2.png", Description = "Powerful all-in-one desktop for home and office use.", Price = 899.00m, Category = "Electronics", Rating = 4.4, IsSaved = true, PurchasedCount = 105, Tags = new List<string> { "Desktop", "Computer", "All-in-One" }, IsAddedToCart = false },
            new Product { Name = "Ultra Laptop X1", ImageUrl = "laptopopen.png", PreviewOneImageUrl = "laptopopen1.png", PreviewTwoImageUrl = "laptopopen2.png", Description = "Slim and powerful laptop with long battery life.", Price = 1299.00m, Category = "Electronics", Rating = 4.7, IsSaved = true, PurchasedCount = 200, Tags = new List<string> { "Laptop", "Portable", "Performance" }, IsAddedToCart = false },
            new Product { Name = "Rechargeable AA Batteries", ImageUrl = "aabatteries.png",PreviewOneImageUrl = "aabatteries1.png", PreviewTwoImageUrl = "aabatteries2.png", PreviewThreeImageUrl="aabatteries3.png", Description = "Long-lasting rechargeable AA batteries for everyday electronics.", Price = 12.99m, Category = "Electronics", Rating = 4.4, IsSaved = false, PurchasedCount = 60, Tags = new List<string> { "Batteries", "Rechargeable", "AA" }, IsAddedToCart = false },
            new Product { Name = "iPhone 14 (Blue)", ImageUrl = "iphone14blue.png",PreviewOneImageUrl="iphone14blue1.png", PreviewTwoImageUrl="iphone14blue2.png", Description = "Powerful iPhone 14 with A15 chip and advanced camera system.", Price = 799.00m, Category = "Electronics", Rating = 4.8, IsSaved = true, PurchasedCount = 210, Tags = new List<string> { "iPhone", "Smartphone", "Apple" }, IsAddedToCart = false },
            new Product { Name = "iPhone 14 Pro (Silver)", ImageUrl = "iphone14prosilver.png",PreviewOneImageUrl="iphone14prosilver1.png", PreviewTwoImageUrl="iphone14prosilver2.png", Description = "iPhone 14 Pro with ProMotion display and dynamic island feature.", Price = 999.00m, Category = "Electronics", Rating = 4.9, IsSaved = false, PurchasedCount = 175, Tags = new List<string> { "iPhone", "Pro", "Apple" }, IsAddedToCart = true },

        };

        OrderedProducts.Add(Products.First(p => p.Name == "Men's White Graphic T-Shirt"));
        OrderedProducts.Add(Products.First(p => p.Name == "Women's Yellow Hoodie"));
        OrderedProducts.Add(Products.First(p => p.Name == "Foundation"));

        foreach (var product in OrderedProducts)
        {
            product.IsProductBought = true;
        }
    }

    void GetUserProfileDetails()
    {
        CurrentUser = new UserProfile();
        CurrentUser.Email = "emmawilliam@gmail.com";
        CurrentUser.Password = "Emma@2024";
        CurrentUser.UserName = "Emma William";
        CurrentUser.Gender = "Female";
        CurrentUser.MobileNumber = "9876554321";
    }

    public void FindSavedProducts()
    {
        if(SavedProducts!=null)
        {
            SavedProducts.Clear();
            foreach (var product in Products.Where(product => product.IsSaved))
            {
                SavedProducts.Add(product);
            }
        }
        
    }

    public void FindCartProducts()
    {
        if(MyCartProducts !=null)
        {
            MyCartProducts.Clear();
            foreach (var product in Products.Where(product => product.IsAddedToCart))
            {
                MyCartProducts.Add(product);
            }
        }
    }

    public void AddToOrders(Product product)
    {
        if (product != null && !OrderedProducts.Contains(product))
        {
            product.IsProductBought = true;
            OrderedProducts.Add(product);
        }
    }
}