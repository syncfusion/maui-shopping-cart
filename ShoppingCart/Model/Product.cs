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
        public bool IsAddedToCart { get; set; }

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
