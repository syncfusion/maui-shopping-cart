using System.Collections.ObjectModel;

namespace ShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class Product
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Category { get; set; }
        public double Rating { get; set; }
        public bool IsSaved { get; set; }
        public int PurchasedCount { get; set; }
        public List<String>? Tags { get; set; }

    }
}
