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

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
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
