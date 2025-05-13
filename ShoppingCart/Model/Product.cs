using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShoppingCart
{
    /// <summary>
    /// 
    /// </summary>
    public class Product : INotifyPropertyChanged
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? PreviewOneImageUrl { get; set; }
        public string? PreviewTwoImageUrl { get; set; }
        public string? PreviewThreeImageUrl { get; set; }
        public string? PreviewFourImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Category { get; set; }
        public double Rating { get; set; }
        public int PurchasedCount { get; set; }
        public List<String>? Tags { get; set; }

        private bool _isSaved;

        public bool IsSaved
        {
            get => _isSaved;
            set
            {
                if (_isSaved != value)
                {
                    _isSaved = value;
                    OnPropertyChanged(nameof(IsSaved));
                }
            }
        }

        private bool _isAddedtoCart;
        public bool IsAddedToCart
        {
            get => _isAddedtoCart;
            set
            {
                if (_isAddedtoCart != value)
                {
                    _isAddedtoCart = value;
                    OnPropertyChanged(nameof(IsAddedToCart));
                }
            }
        }


        private bool _isProductBuyed;
        public bool IsProductBuyed
        {
            get => _isProductBuyed;
            set
            {
                if (_isProductBuyed != value)
                {
                    _isProductBuyed = value;
                    OnPropertyChanged(nameof(IsProductBuyed));
                }
            }
        }

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
