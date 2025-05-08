using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace ShoppingCart;

public class ShoppingCartViewModel : ContentPage
{
    public string Email { get; set; } = "emmawilliam@gmail.com";
    public string Password { get; set; } = "Emma@2024";

    public ObservableCollection<SfRotatorItem> RotatorItems { get; set; }
    public ObservableCollection<SfRotatorItem> DesktopRotatorItems { get; set; }
    public ObservableCollection<String> Catagories { get; set; }
    public ObservableCollection<Product> Products { get; set; }
    public ObservableCollection<Product>? FilteredProducts { get; set; }
    public ObservableCollection<Product>? SavedProducts { get; set; } = new ObservableCollection<Product>();
    public ObservableCollection<Product>? MyCartProducts { get; set; } = new ObservableCollection<Product>();

    public ObservableCollection<string> FilteredCategories { get; set; }
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
        FilteredCategories = new ObservableCollection<string>();

        Products = new ObservableCollection<Product>
        {
            // Men Category
            new Product { Name = "Men's Plaid Shirt", ImageUrl = "shirt1.png", Description = "Stylish men's plaid shirt, perfect for casual outings.", Price = 24.00m, Category = "Men", Rating = 4.5, IsSaved = true, PurchasedCount = 50, Tags = new List<string> { "Collar Tshirts", "Half Sleeves", "Plain-Regular Fit" } ,IsAddedToCart=false},
            new Product { Name = "Men's Grey T-Shirt", ImageUrl = "shirt2.png", Description = "Basic grey t-shirt, ideal for everyday wear.", Price = 20.00m, Category = "Men", Rating = 4.3, IsSaved = false, PurchasedCount = 38, Tags = new List<string> { "T-Shirt", "Casual", "Grey" } ,IsAddedToCart=false},
            new Product { Name = "Men's Baseball Tee", ImageUrl = "tshirt2.png", Description = "Black and white raglan tee, sporty and stylish.", Price = 22.00m, Category = "Men", Rating = 4.4, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "T-Shirt", "Raglan", "Sporty" } ,IsAddedToCart=false},
            new Product { Name = "Men's White Tank", ImageUrl = "tshirt3.png", Description = "White sleeveless tank, great for gym or summer.", Price = 18.00m, Category = "Men", Rating = 4.2, IsSaved = false, PurchasedCount = 29, Tags = new List<string> { "Tank Top", "Sleeveless", "Workout" } ,IsAddedToCart=false},
            new Product { Name = "Men's White Tee", ImageUrl = "hoodie.png", Description = "Classic white t-shirt with a relaxed fit.", Price = 20.00m, Category = "Men", Rating = 4.5, IsSaved = true, PurchasedCount = 52, Tags = new List<string> { "T-Shirt", "White", "Casual" } ,IsAddedToCart=false},
            new Product { Name = "Men's Green Tee", ImageUrl = "tshirt1.png", Description = "Fresh green t-shirt, soft and breathable.", Price = 21.00m, Category = "Men", Rating = 4.3, IsSaved = true, PurchasedCount = 34, Tags = new List<string> { "T-Shirt", "Green", "Breathable" } ,IsAddedToCart=false},
            new Product { Name = "Men's Black Hoodie", ImageUrl = "tshirt7.png", Description = "Comfy black hoodie, ideal for cool days.", Price = 42.00m, Category = "Men", Rating = 4.6, IsSaved = true, PurchasedCount = 61, Tags = new List<string> { "Hoodie", "Black", "Warm" } ,IsAddedToCart=false},
            new Product { Name = "Men's Yellow Sweatshirt", ImageUrl = "tshirt5.png", Description = "Bright yellow sweatshirt with a cozy interior.", Price = 38.00m, Category = "Men", Rating = 4.4, IsSaved = false, PurchasedCount = 27, Tags = new List<string> { "Sweatshirt", "Yellow", "Casual" } ,IsAddedToCart=false},
            new Product { Name = "Men's Red T-Shirt", ImageUrl = "tshirt6.png", Description = "Vibrant red t-shirt, durable and soft.", Price = 21.00m, Category = "Men", Rating = 4.3, IsSaved = false, PurchasedCount = 44, Tags = new List<string> { "T-Shirt", "Red", "Comfort" } ,IsAddedToCart=false},
            new Product { Name = "Men's Green Polo", ImageUrl = "tshirt4.png", Description = "Dark green polo shirt, perfect for semi-casual wear.", Price = 28.00m, Category = "Men", Rating = 4.5, IsSaved = true, PurchasedCount = 36, Tags = new List<string> { "Polo", "Green", "Semi-Formal" } ,IsAddedToCart=false},


            // Women Category
           new Product { Name = "Yellow Dress", ImageUrl = "gown.png", Description = "Elegant yellow dress for special occasions.", Price = 24.00m, Category = "Women", Rating = 4.5, IsSaved = false, PurchasedCount = 35, Tags = new List<string> { "Dress", "Elegant" } },
            new Product { Name = "Women's Blue Bow Blouse", ImageUrl = "blue_bow_blouse.png", Description = "Stylish blue blouse with front bow detail.", Price = 35.00m, Category = "Women", Rating = 4.7, IsSaved = true, PurchasedCount = 50, Tags = new List<string> { "Blouse", "Bow", "Blue" } ,IsAddedToCart=false},
            new Product { Name = "Women's Pink T-Shirt", ImageUrl = "pink_tshirt.png", Description = "Soft pink t-shirt perfect for casual days.", Price = 22.00m, Category = "Women", Rating = 4.5, IsSaved = false, PurchasedCount = 42, Tags = new List<string> { "T-Shirt", "Pink", "Casual" } ,IsAddedToCart=false},
            new Product { Name = "Women's White Scoop Tee", ImageUrl = "white_scoop_tee.png", Description = "White scoop neck t-shirt with a flattering fit.", Price = 24.00m, Category = "Women", Rating = 4.6, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "T-Shirt", "White", "Fitted" } ,IsAddedToCart=false},
            new Product { Name = "Women's Camel Coat", ImageUrl = "camel_coat.png", Description = "Elegant camel long coat, perfect for fall.", Price = 78.00m, Category = "Women", Rating = 4.8, IsSaved = false, PurchasedCount = 39, Tags = new List<string> { "Coat", "Camel", "Outerwear" } ,IsAddedToCart=false},
            new Product { Name = "Women's Grey Knit Sweater", ImageUrl = "grey_knit_sweater.png", Description = "Warm and cozy grey knitted sweater.", Price = 48.00m, Category = "Women", Rating = 4.7, IsSaved = false, PurchasedCount = 46, Tags = new List<string> { "Sweater", "Knit", "Grey" } ,IsAddedToCart=false},
            new Product { Name = "Women's Denim Jacket", ImageUrl = "denim_jacket.png", Description = "Classic denim jacket for versatile styling.", Price = 55.00m, Category = "Women", Rating = 4.9, IsSaved = true, PurchasedCount = 63, Tags = new List<string> { "Jacket", "Denim", "Classic" } ,IsAddedToCart=false},
            new Product { Name = "Women's Grey Wrap Top", ImageUrl = "grey_wrap_top.png", Description = "Chic wrap top in grey with stylish tie detail.", Price = 34.00m, Category = "Women", Rating = 4.6, IsSaved = false, PurchasedCount = 31, Tags = new List<string> { "Top", "Wrap", "Grey" } ,IsAddedToCart=false},
            new Product { Name = "Women's Red Off-Shoulder Top", ImageUrl = "red_offshoulder_top.png", Description = "Red off-shoulder top with elegant ruffles.", Price = 33.00m, Category = "Women", Rating = 4.7, IsSaved = true, PurchasedCount = 54, Tags = new List<string> { "Top", "Red", "Off-Shoulder" } ,IsAddedToCart=false},
            new Product { Name = "Women's Pink Flared Dress", ImageUrl = "pink_flared_dress.png", Description = "Flared pink dress perfect for special occasions.", Price = 45.00m, Category = "Women", Rating = 4.8, IsSaved = false, PurchasedCount = 48, Tags = new List<string> { "Dress", "Pink", "Elegant" } ,IsAddedToCart=false},
            // Kids Category
            new Product { Name = "Kids Dress", ImageUrl = "womendress.png", Description = "Cute and colorful dress for kids.", Price = 24.00m, Category = "Kids", Rating = 4.5, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Dress", "Colorful" } },
            new Product { Name = "Kids' Brown Tee and Shorts Set", ImageUrl = "kids_brown_set.png", Description = "Comfortable brown t-shirt and shorts set for kids.", Price = 18.00m, Category = "Kids", Rating = 4.5, IsSaved = true, PurchasedCount = 40, Tags = new List<string> { "Set", "Tee", "Shorts" } ,IsAddedToCart=false},
            new Product { Name = "Kids' Bear Hoodie Outfit", ImageUrl = "kids_bear_outfit.png", Description = "Cute hoodie with bear design and matching pants.", Price = 28.00m, Category = "Kids", Rating = 4.7, IsSaved = false, PurchasedCount = 55, Tags = new List<string> { "Hoodie", "Bear", "Outfit" } ,IsAddedToCart=false},
            new Product { Name = "Kids' Black Denim Jacket", ImageUrl = "kids_black_denim_jacket.png", Description = "Stylish black denim jacket for all seasons.", Price = 30.00m, Category = "Kids", Rating = 4.6, IsSaved = false, PurchasedCount = 47, Tags = new List<string> { "Jacket", "Denim", "Black" } ,IsAddedToCart=true},
            new Product { Name = "Kids' Tan Bear Sweater", ImageUrl = "kids_bear_sweater.png", Description = "Warm tan sweater with adorable bear print.", Price = 22.00m, Category = "Kids", Rating = 4.8, IsSaved = true, PurchasedCount = 59, Tags = new List<string> { "Sweater", "Bear", "Warm" } ,IsAddedToCart=false},
            new Product { Name = "Kids' Pink Bunny Sweater", ImageUrl = "kids_pink_bunny_sweater.png", Description = "Cozy pink sweater with bunny design.", Price = 21.00m, Category = "Kids", Rating = 4.5, IsSaved = false, PurchasedCount = 44, Tags = new List<string> { "Sweater", "Pink", "Bunny" } ,IsAddedToCart=false},
            new Product { Name = "Kids' Denim Shirt Jacket", ImageUrl = "kids_denim_shirt_jacket.png", Description = "Denim shirt-style jacket for boys and girls.", Price = 29.00m, Category = "Kids", Rating = 4.6, IsSaved = false, PurchasedCount = 50, Tags = new List<string> { "Jacket", "Denim", "Shirt Style" } ,IsAddedToCart=false},
            new Product { Name = "Kids' Teddy Sweater", ImageUrl = "kids_teddy_sweater.png", Description = "Playful cream sweater with teddy illustrations.", Price = 24.00m, Category = "Kids", Rating = 4.7, IsSaved = true, PurchasedCount = 52, Tags = new List<string> { "Sweater", "Teddy", "Fun" } ,IsAddedToCart=false},
            // Accessories Category
            new Product { Name = "Blue Handbag", ImageUrl = "bag.png", Description = "Chic blue handbag, ideal for everyday use.", Price = 24.00m, Category = "Accessories", Rating = 4.5, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "Handbag", "Chic" } },
            new Product { Name = "Blue Striped Bow Tie", ImageUrl = "bow_tie_blue_striped.png", Description = "Elegant blue-striped bow tie for formal occasions.", Price = 15.00m, Category = "Accessories", Rating = 4.6, IsSaved = true, PurchasedCount = 38, Tags = new List<string> { "Bow Tie", "Formal", "Blue" } ,IsAddedToCart=false},
            new Product { Name = "Black Necktie", ImageUrl = "black_necktie.png", Description = "Classic black necktie for professional and formal events.", Price = 14.00m, Category = "Accessories", Rating = 4.5, IsSaved = false, PurchasedCount = 41, Tags = new List<string> { "Necktie", "Black", "Classic" } ,IsAddedToCart=false},
            new Product { Name = "Beige Pleated Skirt", ImageUrl = "pleated_skirt_beige.png", Description = "Stylish beige pleated mini skirt.", Price = 20.00m, Category = "Accessories", Rating = 4.4, IsSaved = false, PurchasedCount = 36, Tags = new List<string> { "Skirt", "Beige", "Pleated" } ,IsAddedToCart=false},
            new Product { Name = "Round Black Sunglasses", ImageUrl = "sunglasses_round_black.png", Description = "Trendy round sunglasses with black lenses.", Price = 30.00m, Category = "Accessories", Rating = 4.5, IsSaved = true, PurchasedCount = 39, Tags = new List<string> { "Sunglasses", "Black", "Round" } ,IsAddedToCart=false},
            new Product { Name = "Brown Leather Belt", ImageUrl = "belt_brown_leather.png", Description = "Durable brown leather belt with metal buckle.", Price = 18.00m, Category = "Accessories", Rating = 4.6, IsSaved = false, PurchasedCount = 48, Tags = new List<string> { "Belt", "Leather", "Brown" } ,IsAddedToCart=false},
            new Product { Name = "Red-Blue Check Scarf", ImageUrl = "scarf_check_red_blue.png", Description = "Warm scarf with red and blue checkered pattern.", Price = 22.00m, Category = "Accessories", Rating = 4.7, IsSaved = true, PurchasedCount = 52, Tags = new List<string> { "Scarf", "Winter", "Checkered" } ,IsAddedToCart=false},
            new Product { Name = "Black Knit Beanie", ImageUrl = "beanie_black_knit.png", Description = "Cozy black knit beanie for cold weather.", Price = 16.00m, Category = "Accessories", Rating = 4.5, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Beanie", "Winter", "Black" } ,IsAddedToCart=false},
            new Product { Name = "Striped Winter Gloves", ImageUrl = "gloves_winter_striped.png", Description = "Warm gloves with blue, black, and white stripes.", Price = 12.00m, Category = "Accessories", Rating = 4.4, IsSaved = true, PurchasedCount = 34, Tags = new List<string> { "Gloves", "Winter", "Striped" } ,IsAddedToCart=false},            
            // Shoes Category
            new Product { Name = "Casual Sandals", ImageUrl = "sandals_casual.png", Description = "Comfortable sandals for everyday wear.", Price = 35.00m, Category = "Shoes", Rating = 4.3, IsSaved = false, PurchasedCount = 50, Tags = new List<string> { "Sandals", "Casual" } ,IsAddedToCart=false},
            new Product { Name = "Flip Flops", ImageUrl = "flip_flops_nude.png", Description = "Easy slip-on sandals.", Price = 18.00m, Category = "Shoes", Rating = 4.2, IsSaved = false, PurchasedCount = 43, Tags = new List<string> { "Flip Flops", "Casual" } ,IsAddedToCart=false},
            new Product { Name = "Black High Heels", ImageUrl = "heels_black.png", Description = "Elegant black heels perfect for formal evenings.", Price = 55.00m, Category = "Shoes", Rating = 4.6, IsSaved = true, PurchasedCount = 35, Tags = new List<string> { "Heels", "Black", "Formal" } ,IsAddedToCart=false},
            new Product { Name = "Leather Loafers", ImageUrl = "loafers_black.png", Description = "Elegant leather loafers perfect for formal occasions.", Price = 70.00m, Category = "Shoes", Rating = 4.9, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "Loafers", "Leather" } ,IsAddedToCart=false},
            new Product { Name = "Running Sneakers", ImageUrl = "sneakers_blue.png", Description = "Comfortable running sneakers for all-day wear.", Price = 60.00m, Category = "Shoes", Rating = 4.8, IsSaved = true, PurchasedCount = 100, Tags = new List<string> { "Sneakers", "Running" } ,IsAddedToCart=false},
            new Product { Name = "Women's Flats", ImageUrl = "flats_pink.png", Description = "Simple and comfy flats.", Price = 28.00m, Category = "Shoes", Rating = 4.5, IsSaved = true, PurchasedCount = 52, Tags = new List<string> { "Flats", "Comfy" } ,IsAddedToCart=false},
            new Product { Name = "Men's Boots", ImageUrl = "boots_brown.png", Description = "Rugged and stylish.", Price = 95.00m, Category = "Shoes", Rating = 4.7, IsSaved = false, PurchasedCount = 47, Tags = new List<string> { "Boots", "Rugged" } ,IsAddedToCart=false},
            new Product { Name = "Slip-on Shoes", ImageUrl = "shoes_slipon_brown.png", Description = "Convenient slip-on style.", Price = 38.00m, Category = "Shoes", Rating = 4.4, IsSaved = true, PurchasedCount = 34, Tags = new List<string> { "Slip-on", "Convenient" } ,IsAddedToCart=false},
            // Sports Category
            new Product { Name = "Sports Socks", ImageUrl = "socks.png", Description = "Comfortable ankle sports socks.", Price = 12.00m, Category = "Sports", Rating = 4.4, IsSaved = true, PurchasedCount = 80, Tags = new List<string> { "Socks", "Sportswear" } ,IsAddedToCart=false},
            new Product { Name = "Sports Sneakers", ImageUrl = "sneakers.png", Description = "High-performance athletic sneakers.", Price = 85.00m, Category = "Sports", Rating = 4.7, IsSaved = true, PurchasedCount = 110, Tags = new List<string> { "Sneakers", "Shoes" } ,IsAddedToCart=false},
            new Product { Name = "Green Sports Cap", ImageUrl = "green_cap.png", Description = "Olive green adjustable sports cap.", Price = 18.00m, Category = "Sports", Rating = 4.3, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Cap", "Headwear" } ,IsAddedToCart=false},
            new Product { Name = "Purple & White Cap", ImageUrl = "purple_white_cap.png", Description = "Purple and white sports cap.", Price = 18.00m, Category = "Sports", Rating = 4.5, IsSaved = false, PurchasedCount = 50, Tags = new List<string> { "Cap", "Headwear" } ,IsAddedToCart=false},
            new Product { Name = "Sports Jacket", ImageUrl = "sports_jacket.png", Description = "Lightweight water-resistant sports jacket.", Price = 60.00m, Category = "Sports", Rating = 4.6, IsSaved = true, PurchasedCount = 70, Tags = new List<string> { "Jacket", "Outerwear" } ,IsAddedToCart=false},
            new Product { Name = "White/Blue Sports T-Shirt", ImageUrl = "sports_tee_blue_white.png", Description = "Breathable white and blue sports t-shirt.", Price = 25.00m, Category = "Sports", Rating = 4.5, IsSaved = false, PurchasedCount = 67, Tags = new List<string> { "T-Shirt", "Sportswear" } ,IsAddedToCart=false},
            new Product { Name = "Blue Sports T-Shirt", ImageUrl = "sports_tee_blue.png", Description = "Classic blue sports t-shirt.", Price = 22.00m, Category = "Sports", Rating = 4.4, IsSaved = true, PurchasedCount = 83, Tags = new List<string> { "T-Shirt", "Sportswear" } ,IsAddedToCart=false},           
            // Beauty Category
            new Product { Name = "Red Lipstick", ImageUrl = "red_lipstick.png", Description = "Vibrant red lipstick with long-lasting formula.", Price = 15.00m, Category = "Beauty", Rating = 4.7, IsSaved = true, PurchasedCount = 110, Tags = new List<string> { "Lipstick", "Red", "Makeup" } ,IsAddedToCart=false},
            new Product { Name = "Eyeshadow Palette", ImageUrl = "eyeshadow_palette.png", Description = "12-shade eyeshadow palette with matte and shimmer finishes.", Price = 25.00m, Category = "Beauty", Rating = 4.6, IsSaved = false, PurchasedCount = 78, Tags = new List<string> { "Eyeshadow", "Palette", "Makeup" } ,IsAddedToCart=true},
            new Product { Name = "Pink Blush", ImageUrl = "pink_blush.png", Description = "Soft pink blush for a natural glow.", Price = 12.00m, Category = "Beauty", Rating = 4.5, IsSaved = true, PurchasedCount = 64, Tags = new List<string> { "Blush", "Pink", "Makeup" } ,IsAddedToCart=false},
            new Product { Name = "Complete Makeup Kit", ImageUrl = "makeup_kit.png", Description = "All-in-one beauty kit with essentials for any look.", Price = 60.00m, Category = "Beauty", Rating = 4.8, IsSaved = true, PurchasedCount = 95, Tags = new List<string> { "Makeup", "Kit", "Complete" } ,IsAddedToCart=false},
            new Product { Name = "Hair Styling Set", ImageUrl = "hair_styling_set.png", Description = "Professional hair styling tools for salon-quality results.", Price = 40.00m, Category = "Beauty", Rating = 4.6, IsSaved = false, PurchasedCount = 59, Tags = new List<string> { "Hair", "Styling", "Tools" } ,IsAddedToCart=false},
            new Product { Name = "Pink Lipstick", ImageUrl = "pink_lipstick.png", Description = "Bright pink lipstick for a bold look.", Price = 15.00m, Category = "Beauty", Rating = 4.4, IsSaved = false, PurchasedCount = 70, Tags = new List<string> { "Lipstick", "Pink", "Makeup" } ,IsAddedToCart=false},
            // Electronics Category
            new Product { Name = "Smartphone", ImageUrl = "smartphone1.png", Description = "Latest smartphone with high-resolution display.", Price = 699.00m, Category = "Electronics", Rating = 4.7, IsSaved = true, PurchasedCount = 150, Tags = new List<string> { "Phone", "Smartphone", "Electronics" } ,IsAddedToCart=false},
            new Product { Name = "Washing Machine", ImageUrl = "washing_machine.png", Description = "Fully automatic washing machine with quick wash feature.", Price = 420.00m, Category = "Electronics", Rating = 4.5, IsSaved = false, PurchasedCount = 65, Tags = new List<string> { "Washing Machine", "Appliance" } ,IsAddedToCart=false},
            new Product { Name = "Single Door Refrigerator", ImageUrl = "fridge_single.png", Description = "Energy-efficient single door refrigerator.", Price = 249.00m, Category = "Electronics", Rating = 4.4, IsSaved = false, PurchasedCount = 48, Tags = new List<string> { "Refrigerator", "Appliance", "Single Door" } ,IsAddedToCart=true},
            new Product { Name = "Double Door Refrigerator", ImageUrl = "fridge_double.png", Description = "Spacious double door refrigerator.", Price = 475.00m, Category = "Electronics", Rating = 4.6, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "Refrigerator", "Double Door", "Appliance" } ,IsAddedToCart=false},
            new Product { Name = "Kitchen Appliance Set", ImageUrl = "kitchen_appliance_set.png", Description = "Complete set of kitchen appliances for daily use.", Price = 150.00m, Category = "Electronics", Rating = 4.7, IsSaved = true, PurchasedCount = 85, Tags = new List<string> { "Kitchen", "Appliances", "Set" } ,IsAddedToCart=false},
            new Product { Name = "Steam Iron", ImageUrl = "steam_iron.png", Description = "Steam iron for crisp and smooth clothes.", Price = 35.00m, Category = "Electronics", Rating = 4.5, IsSaved = false, PurchasedCount = 72, Tags = new List<string> { "Iron", "Home" } ,IsAddedToCart=false},
            new Product { Name = "Laptop", ImageUrl = "laptop.png", Description = "High-performance laptop suitable for work and play.", Price = 850.00m, Category = "Electronics", Rating = 4.8, IsSaved = true, PurchasedCount = 133, Tags = new List<string> { "Laptop", "Electronics", "Computer" } ,IsAddedToCart=false},
        };

        
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
}