using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public ObservableCollection<Product>? SavedProducts { get; set; }

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

        Products = new ObservableCollection<Product>
        {
            // Men Category
            new Product { Name = "Men's T-Shirt", ImageUrl = "shirt2.png", Description = "Classic men's t-shirt, soft and comfortable.", Price = 24.00m, Category = "Men", Rating = 4.5, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "T-Shirt", "Comfortable" } },
            new Product { Name = "Men's Plaid Shirt", ImageUrl = "shirt1.png", Description = "Stylish men's plaid shirt, perfect for casual outings.", Price = 24.00m, Category = "Men", Rating = 4.5, IsSaved = true, PurchasedCount = 50, Tags = new List<string> { "Collar Tshirts", "Half Sleeves", "Plain-Regular Fit" } },
            new Product { Name = "Men's Denim Jacket", ImageUrl = "shirt2.png", Description = "Classic men's denim jacket, perfect for layering.", Price = 45.00m, Category = "Men", Rating = 4.7, IsSaved = true, PurchasedCount = 75, Tags = new List<string> { "Jacket", "Denim" } },
            new Product { Name = "Men's Leather Belt", ImageUrl = "shirt1.png", Description = "High-quality men's leather belt, suitable for any outfit.", Price = 30.00m, Category = "Men", Rating = 4.6, IsSaved = false, PurchasedCount = 60, Tags = new List<string> { "Belt", "Leather" } },
            new Product { Name = "Men's Hoodie", ImageUrl = "shirt2.png", Description = "Warm and stylish hoodie.", Price = 40.00m, Category = "Men", Rating = 4.4, IsSaved = false, PurchasedCount = 32, Tags = new List<string> { "Hoodie", "Warm" } },
            new Product { Name = "Men's Formal Shirt", ImageUrl = "bag.png", Description = "Perfect for office wear.", Price = 35.00m, Category = "Men", Rating = 4.6, IsSaved = true, PurchasedCount = 28, Tags = new List<string> { "Formal", "Shirt" } },
            new Product { Name = "Men's Shorts", ImageUrl = "bag.png", Description = "Comfy summer shorts.", Price = 20.00m, Category = "Men", Rating = 4.3, IsSaved = false, PurchasedCount = 41, Tags = new List<string> { "Shorts", "Comfort" } },
            new Product { Name = "Men's Suit", ImageUrl = "bag.png", Description = "Elegant formal suit.", Price = 150.00m, Category = "Men", Rating = 4.9, IsSaved = true, PurchasedCount = 19, Tags = new List<string> { "Suit", "Formal" } },
            new Product { Name = "Men's Watch", ImageUrl = "bag.png", Description = "Stylish men's wristwatch.", Price = 85.00m, Category = "Men", Rating = 4.7, IsSaved = false, PurchasedCount = 66, Tags = new List<string> { "Watch", "Stylish" } },
            new Product { Name = "Men's Cap", ImageUrl = "bag.png", Description = "Cool cap for sunny days.", Price = 15.00m, Category = "Men", Rating = 4.2, IsSaved = true, PurchasedCount = 30, Tags = new List<string> { "Cap", "Sun Protection" } },

            // Women Category
            new Product { Name = "Yellow Dress", ImageUrl = "gown.png", Description = "Elegant yellow dress for special occasions.", Price = 24.00m, Category = "Women", Rating = 4.5, IsSaved = false, PurchasedCount = 35, Tags = new List<string> { "Dress", "Elegant" } },
            new Product { Name = "Women's Floral Top", ImageUrl = "bag.png", Description = "Beautiful floral top that adds elegance to any look.", Price = 35.00m, Category = "Women", Rating = 4.8, IsSaved = true, PurchasedCount = 80, Tags = new List<string> { "Floral", "Top" } },
            new Product { Name = "Leather Jacket", ImageUrl = "bag.png", Description = "Stylish leather jacket for a chic look.", Price = 75.00m, Category = "Women", Rating = 4.9, IsSaved = false, PurchasedCount = 55, Tags = new List<string> { "Jacket", "Leather" } },
            new Product { Name = "Women's Jeans", ImageUrl = "bag.png", Description = "Comfortable and trendy women's jeans.", Price = 45.00m, Category = "Women", Rating = 4.8, IsSaved = true, PurchasedCount = 90, Tags = new List<string> { "Jeans", "Trendy" } },
            new Product { Name = "Women's Necklace", ImageUrl = "bag.png", Description = "Elegant necklace to complement any outfit.", Price = 55.00m, Category = "Women", Rating = 4.9, IsSaved = false, PurchasedCount = 48, Tags = new List<string> { "Necklace", "Elegant" } },
            new Product { Name = "Women's Handbag", ImageUrl = "bag.png", Description = "Stylish handbag for everyday use.", Price = 65.00m, Category = "Women", Rating = 4.7, IsSaved = true, PurchasedCount = 62, Tags = new List<string> { "Handbag", "Stylish" } },
            new Product { Name = "Women's Skirt", ImageUrl = "bag.png", Description = "Flowy and feminine.", Price = 32.00m, Category = "Women", Rating = 4.5, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "Skirt", "Feminine" } },
            new Product { Name = "Women's Blazer", ImageUrl = "bag.png", Description = "Perfect for professional look.", Price = 55.00m, Category = "Women", Rating = 4.7, IsSaved = true, PurchasedCount = 26, Tags = new List<string> { "Blazer", "Professional" } },
            new Product { Name = "Women's Heels", ImageUrl = "bag.png", Description = "Elegant high heels.", Price = 65.00m, Category = "Women", Rating = 4.6, IsSaved = true, PurchasedCount = 53, Tags = new List<string> { "Heels", "Elegant" } },
            new Product { Name = "Women's Scarf", ImageUrl = "bag.png", Description = "Cozy and stylish scarf.", Price = 18.00m, Category = "Women", Rating = 4.3, IsSaved = false, PurchasedCount = 39, Tags = new List<string> { "Scarf", "Cozy" } },
            new Product { Name = "Women's Sunglasses", ImageUrl = "bag.png", Description = "Trendy sunglasses.", Price = 22.00m, Category = "Women", Rating = 4.6, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Sunglasses", "Trendy" } },

            // Kids Category
            new Product { Name = "Kids Dress", ImageUrl = "womendress.png", Description = "Cute and colorful dress for kids.", Price = 24.00m, Category = "Kids", Rating = 4.5, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Dress", "Colorful" } },
            new Product { Name = "Kids' Graphic T-Shirt", ImageUrl = "bag.png", Description = "Fun and colorful graphic t-shirt for kids.", Price = 15.00m, Category = "Kids", Rating = 4.5, IsSaved = true, PurchasedCount = 95, Tags = new List<string> { "Kids", "Graphic T-Shirt" } },
            new Product { Name = "Kids' Denim Shorts", ImageUrl = "bag.png", Description = "Comfortable denim shorts for kids' playtime.", Price = 20.00m, Category = "Kids", Rating = 4.4, IsSaved = false, PurchasedCount = 70, Tags = new List<string> { "Kids", "Denim Shorts" } },
            new Product { Name = "Kids' Sneakers", ImageUrl = "bag.png", Description = "Colorful and durable sneakers for children.", Price = 30.00m, Category = "Kids", Rating = 4.3, IsSaved = false, PurchasedCount = 49, Tags = new List<string> { "Sneakers", "Durable" } },
            new Product { Name = "Kids' Backpack", ImageUrl = "bag.png", Description = "Sturdy backpack with fun designs for kids.", Price = 25.00m, Category = "Kids", Rating = 4.6, IsSaved = true, PurchasedCount = 67, Tags = new List<string> { "Backpack", "Fun" } },
            new Product { Name = "Kids' Pajamas", ImageUrl = "bag.png", Description = "Soft and cozy pajamas for a good night's sleep.", Price = 20.00m, Category = "Kids", Rating = 4.4, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Pajamas", "Cozy" } },
            new Product { Name = "Kids' Raincoat", ImageUrl = "bag.png", Description = "Waterproof and fun.", Price = 28.00m, Category = "Kids", Rating = 4.4, IsSaved = false, PurchasedCount = 25, Tags = new List<string> { "Raincoat", "Waterproof" } },
            new Product { Name = "Kids' Cap", ImageUrl = "bag.png", Description = "Cool cap for sunny adventures.", Price = 10.00m, Category = "Kids", Rating = 4.3, IsSaved = true, PurchasedCount = 35, Tags = new List<string> { "Cap", "Sun Protection" } },
            new Product { Name = "Kids' Socks Pack", ImageUrl = "bag.png", Description = "Pack of colorful socks.", Price = 12.00m, Category = "Kids", Rating = 4.5, IsSaved = false, PurchasedCount = 38, Tags = new List<string> { "Socks", "Colorful" } },
            new Product { Name = "Kids' Swimsuit", ImageUrl = "bag.png", Description = "Fun for the pool!", Price = 20.00m, Category = "Kids", Rating = 4.7, IsSaved = true, PurchasedCount = 21, Tags = new List<string> { "Swimsuit", "Pool" } },
            new Product { Name = "Kids' Beanie", ImageUrl = "bag.png", Description = "Warm knitted hat.", Price = 15.00m, Category = "Kids", Rating = 4.5, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "Beanie", "Warm" } },

            // Accessories Category
            new Product { Name = "Blue Handbag", ImageUrl = "bag.png", Description = "Chic blue handbag, ideal for everyday use.", Price = 24.00m, Category = "Accessories", Rating = 4.5, IsSaved = true, PurchasedCount = 60, Tags = new List<string> { "Handbag", "Chic" } },
            new Product { Name = "Leather Phone Case", ImageUrl = "bag.png", Description = "Durable leather phone case with a sleek design.", Price = 20.00m, Category = "Accessories", Rating = 4.6, IsSaved = true, PurchasedCount = 55, Tags = new List<string> { "Phone", "Leather Case" } },
            new Product { Name = "Fashionable Earrings", ImageUrl = "bag.png", Description = "Stylish earrings that enhance any look.", Price = 25.00m, Category = "Accessories", Rating = 4.7, IsSaved = false, PurchasedCount = 85, Tags = new List<string> { "Earrings", "Fashion" } },
            new Product { Name = "Wristwatch", ImageUrl = "bag.png", Description = "Elegant wristwatch for any outfit.", Price = 95.00m, Category = "Accessories", Rating = 4.8, IsSaved = true, PurchasedCount = 42, Tags = new List<string> { "Wristwatch", "Elegant" } },
            new Product { Name = "Sunglasses", ImageUrl = "bag.png", Description = "Cool shades for sunny days.", Price = 30.00m, Category = "Accessories", Rating = 4.5, IsSaved = false, PurchasedCount = 39, Tags = new List<string> { "Sunglasses", "Cool" } },
            new Product { Name = "Hairband Pack", ImageUrl = "bag.png", Description = "Colorful hairbands for every day.", Price = 10.00m, Category = "Accessories", Rating = 4.3, IsSaved = true, PurchasedCount = 20, Tags = new List<string> { "Hairbands", "Colorful" } },
            new Product { Name = "Pendant", ImageUrl = "bag.png", Description = "Charming pendant necklace.", Price = 45.00m, Category = "Accessories", Rating = 4.7, IsSaved = true, PurchasedCount = 33, Tags = new List<string> { "Pendant", "Charming" } },
            new Product { Name = "Travel Pouch", ImageUrl = "bag.png", Description = "Organize your essentials.", Price = 18.00m, Category = "Accessories", Rating = 4.6, IsSaved = false, PurchasedCount = 37, Tags = new List<string> { "Pouch", "Travel" } },
            new Product { Name = "Smart Watch Band", ImageUrl = "bag.png", Description = "Silicone band for smartwatches.", Price = 12.00m, Category = "Accessories", Rating = 4.4, IsSaved = true, PurchasedCount = 29, Tags = new List<string> { "Watch Band", "Silicone" } },
            
            // Shoes Category
            new Product { Name = "Running Sneakers", ImageUrl = "bag.png", Description = "Comfortable running sneakers for all-day wear.", Price = 60.00m, Category = "Shoes", Rating = 4.8, IsSaved = true, PurchasedCount = 100, Tags = new List<string> { "Sneakers", "Running" } },
            new Product { Name = "Leather Loafers", ImageUrl = "bag.png", Description = "Elegant leather loafers perfect for formal occasions.", Price = 70.00m, Category = "Shoes", Rating = 4.9, IsSaved = false, PurchasedCount = 40, Tags = new List<string> { "Loafers", "Leather" } },
            new Product { Name = "Basketball Shoes", ImageUrl = "bag.png", Description = "High-performance shoes for basketball players.", Price = 110.00m, Category = "Shoes", Rating = 4.7, IsSaved = true, PurchasedCount = 85, Tags = new List<string> { "Basketball", "Performance" } },
            new Product { Name = "Casual Sandals", ImageUrl = "bag.png", Description = "Comfortable sandals for everyday wear.", Price = 35.00m, Category = "Shoes", Rating = 4.3, IsSaved = false, PurchasedCount = 50, Tags = new List<string> { "Sandals", "Casual" } },
            new Product { Name = "Hiking Boots", ImageUrl = "bag.png", Description = "Durable boots for outdoor adventures.", Price = 120.00m, Category = "Shoes", Rating = 4.8, IsSaved = true, PurchasedCount = 65, Tags = new List<string> { "Hiking", "Durable" } },
            new Product { Name = "Flip Flops", ImageUrl = "bag.png", Description = "Easy slip-on sandals.", Price = 18.00m, Category = "Shoes", Rating = 4.2, IsSaved = false, PurchasedCount = 43, Tags = new List<string> { "Flip Flops", "Casual" } },
            new Product { Name = "Women's Flats", ImageUrl = "bag.png", Description = "Simple and comfy flats.", Price = 28.00m, Category = "Shoes", Rating = 4.5, IsSaved = true, PurchasedCount = 52, Tags = new List<string> { "Flats", "Comfy" } },
            new Product { Name = "Men's Boots", ImageUrl = "bag.png", Description = "Rugged and stylish.", Price = 95.00m, Category = "Shoes", Rating = 4.7, IsSaved = false, PurchasedCount = 47, Tags = new List<string> { "Boots", "Rugged" } },
            new Product { Name = "Slip-on Shoes", ImageUrl = "bag.png", Description = "Convenient slip-on style.", Price = 38.00m, Category = "Shoes", Rating = 4.4, IsSaved = true, PurchasedCount = 34, Tags = new List<string> { "Slip-on", "Convenient" } },
            new Product { Name = "Children's Shoes", ImageUrl = "bag.png", Description = "Fun and supportive kids' shoes.", Price = 27.00m, Category = "Shoes", Rating = 4.6, IsSaved = false, PurchasedCount = 59, Tags = new List<string> { "Kids Shoes", "Supportive" } },

            // Sports Category
            new Product { Name = "Yoga Mat", ImageUrl = "bag.png", Description = "Non-slip yoga mat for a secure workout.", Price = 30.00m, Category = "Sports", Rating = 4.5, IsSaved = true, PurchasedCount = 95, Tags = new List<string> { "Yoga", "Mat" } },
            new Product { Name = "Dumbbells Set", ImageUrl = "bag.png", Description = "Versatile dumbbells set for strength training.", Price = 40.00m, Category = "Sports", Rating = 4.6, IsSaved = false, PurchasedCount = 60, Tags = new List<string> { "Dumbbells", "Fitness" } },
            new Product { Name = "Tennis Racket", ImageUrl = "bag.png", Description = "Professional-grade tennis racket.", Price = 90.00m, Category = "Sports", Rating = 4.6, IsSaved = true, PurchasedCount = 78, Tags = new List<string> { "Tennis", "Racket" } },
            new Product { Name = "Soccer Ball", ImageUrl = "bag.png", Description = "High-quality soccer ball for matches.", Price = 25.00m, Category = "Sports", Rating = 4.4, IsSaved = false, PurchasedCount = 90, Tags = new List<string> { "Soccer", "Ball" } },
            new Product { Name = "Running Shorts", ImageUrl = "bag.png", Description = "Lightweight shorts designed for running.", Price = 30.00m, Category = "Sports", Rating = 4.5, IsSaved = true, PurchasedCount = 56, Tags = new List<string> { "Running", "Shorts" } },
            new Product { Name = "Football", ImageUrl = "bag.png", Description = "Durable football for outdoor play.", Price = 25.00m, Category = "Sports", Rating = 4.4, IsSaved = false, PurchasedCount = 51, Tags = new List<string> { "Football", "Outdoor" } },
            new Product { Name = "Basketball", ImageUrl = "bag.png", Description = "Official size and weight.", Price = 30.00m, Category = "Sports", Rating = 4.5, IsSaved = true, PurchasedCount = 62, Tags = new List<string> { "Basketball", "Official" } },
            new Product { Name = "Water Bottle", ImageUrl = "bag.png", Description = "Insulated water bottle for athletes.", Price = 15.00m, Category = "Sports", Rating = 4.6, IsSaved = false, PurchasedCount = 73, Tags = new List<string> { "Water Bottle", "Insulated" } },
            new Product { Name = "Gym Bag", ImageUrl = "bag.png", Description = "Spacious and tough gym bag.", Price = 45.00m, Category = "Sports", Rating = 4.8, IsSaved = true, PurchasedCount = 55, Tags = new List<string> { "Gym", "Bag" } },
            new Product { Name = "Skipping Rope", ImageUrl = "bag.png", Description = "Ideal for cardio workouts.", Price = 12.00m, Category = "Sports", Rating = 4.3, IsSaved = false, PurchasedCount = 44, Tags = new List<string> { "Skipping", "Cardio" } },
           
            // Beauty Category
            new Product { Name = "Perfume", ImageUrl = "bag.png", Description = "Exquisite perfume with a long-lasting fragrance.", Price = 50.00m, Category = "Beauty", Rating = 4.7, IsSaved = true, PurchasedCount = 30, Tags = new List<string> { "Perfume", "Fragrance" } },
            new Product { Name = "Foundation", ImageUrl = "bag.png", Description = "Smooth foundation for a flawless look.", Price = 25.00m, Category = "Beauty", Rating = 4.8, IsSaved = false, PurchasedCount = 45, Tags = new List<string> { "Foundation", "Flawless" } },
            new Product { Name = "Lipstick", ImageUrl = "bag.png", Description = "Long-lasting lipstick with vibrant colors.", Price = 20.00m, Category = "Beauty", Rating = 4.7, IsSaved = false, PurchasedCount = 95, Tags = new List<string> { "Lipstick", "Long-lasting" } },
            new Product { Name = "Moisturizer", ImageUrl = "bag.png", Description = "Hydrating moisturizer for smooth skin.", Price = 30.00m, Category = "Beauty", Rating = 4.8, IsSaved = true, PurchasedCount = 42, Tags = new List<string> { "Moisturizer", "Hydrating" } },
            new Product { Name = "Mascara", ImageUrl = "bag.png", Description = "Volumizing mascara for defined lashes.", Price = 18.00m, Category = "Beauty", Rating = 4.6, IsSaved = false, PurchasedCount = 47, Tags = new List<string> { "Mascara", "Volumizing" } },
            new Product { Name = "Face Cream", ImageUrl = "bag.png", Description = "Moisturizing cream for all skin types.", Price = 18.00m, Category = "Beauty", Rating = 4.5, IsSaved = false, PurchasedCount = 64, Tags = new List<string> { "Face Cream", "Moisturizing" } },
            new Product { Name = "Lipstick Set", ImageUrl = "bag.png", Description = "Matte finish lipsticks in 5 shades.", Price = 22.00m, Category = "Beauty", Rating = 4.6, IsSaved = true, PurchasedCount = 78, Tags = new List<string> { "Lipstick", "Matte" } },
            new Product { Name = "Eyeliner Pen", ImageUrl = "bag.png", Description = "Waterproof long-lasting eyeliner.", Price = 10.00m, Category = "Beauty", Rating = 4.2, IsSaved = false, PurchasedCount = 59, Tags = new List<string> { "Eyeliner", "Waterproof" } },
            new Product { Name = "Nail Polish Kit", ImageUrl = "bag.png", Description = "Colorful nail polish set with 6 shades.", Price = 14.50m, Category = "Beauty", Rating = 4.4, IsSaved = true, PurchasedCount = 47, Tags = new List<string> { "Nail Polish", "Colorful" } },
            new Product { Name = "Face Sheet Masks", ImageUrl = "bag.png", Description = "Pack of 10 hydrating face masks.", Price = 20.00m, Category = "Beauty", Rating = 4.7, IsSaved = false, PurchasedCount = 72, Tags = new List<string> { "Face Masks", "Hydrating" } },

            // Electronics Category
            new Product { Name = "Smartphone", ImageUrl = "bag.png", Description = "Latest model smartphone with advanced features.", Price = 700.00m, Category = "Electronics", Rating = 4.9, IsSaved = true, PurchasedCount = 110, Tags = new List<string> { "Phone", "Smartphone" } },
            new Product { Name = "Wireless Headphone", ImageUrl = "bag.png", Description = "Wireless headphones with superior sound quality.", Price = 150.00m, Category = "Electronics", Rating = 4.5, IsSaved = false, PurchasedCount = 75, Tags = new List<string> { "Headphones", "Bluetooth" } },
            new Product { Name = "Laptop", ImageUrl = "bag.png", Description = "Lightweight laptop with high-speed performance.", Price = 1000.00m, Category = "Electronics", Rating = 4.8, IsSaved = true, PurchasedCount = 95, Tags = new List<string> { "Laptop", "Performance" } },
            new Product { Name = "Smartwatch", ImageUrl = "bag.png", Description = "Feature-packed smartwatch with health tracking.", Price = 250.00m, Category = "Electronics", Rating = 4.7, IsSaved = false, PurchasedCount = 82, Tags = new List<string> { "Smartwatch", "Tracking" } },
            new Product { Name = "Tablet", ImageUrl = "bag.png", Description = "Portable tablet with a powerful display.", Price = 500.00m, Category = "Electronics", Rating = 4.9, IsSaved = true, PurchasedCount = 110, Tags = new List<string> { "Tablet", "Display" } },
            new Product { Name = "Wireless Earbuds", ImageUrl = "bag.png", Description = "Bluetooth earbuds with noise canceling.", Price = 65.00m, Category = "Electronics", Rating = 4.6, IsSaved = true, PurchasedCount = 88, Tags = new List<string> { "Earbuds", "Bluetooth" } },
            new Product { Name = "Smartphone Stand", ImageUrl = "bag.png", Description = "Adjustable desk stand for phones.", Price = 12.00m, Category = "Electronics", Rating = 4.3, IsSaved = false, PurchasedCount = 74, Tags = new List<string> { "Phone Stand", "Adjustable" } },
            new Product { Name = "Power Bank", ImageUrl = "bag.png", Description = "10,000mAh fast-charging power bank.", Price = 30.00m, Category = "Electronics", Rating = 4.7, IsSaved = true, PurchasedCount = 91, Tags = new List<string> { "Power Bank", "Fast-charging" } },
            new Product { Name = "Bluetooth Speaker", ImageUrl = "bag.png", Description = "Portable waterproof speaker.", Price = 45.00m, Category = "Electronics", Rating = 4.5, IsSaved = false, PurchasedCount = 66, Tags = new List<string> { "Speaker", "Waterproof" } },
            new Product { Name = "USB-C Hub", ImageUrl = "bag.png", Description = "Multi-port USB-C hub with HDMI & USB.", Price = 25.00m, Category = "Electronics", Rating = 4.4, IsSaved = true, PurchasedCount = 58, Tags = new List<string> { "USB-C", "Hub" } }

        };

        
    }
}