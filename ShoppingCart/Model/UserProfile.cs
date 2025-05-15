using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShoppingCart
{
    public class UserProfile : INotifyPropertyChanged
    {
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

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
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

        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        private string _mobileNumber;
        public string MobileNumber
        {
            get => _mobileNumber;
            set
            {
                if (_mobileNumber != value)
                {
                    _mobileNumber = value;
                    OnPropertyChanged(nameof(MobileNumber));
                }
            }
        }

        public ObservableCollection<Address> Addresses { get; set; }

        public class Address
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        public UserProfile()
        {
            Addresses = new ObservableCollection<Address>
            {
                new Address { Title = "Home", Description = "No.67, 21st cross street, Chennai-xxxxxx" },
                new Address { Title = "Office", Description = "No.67, 21st cross street, Chennai-xxxxxx" },
                new Address { Title = "Office", Description = "No.67, 21st cross street, Chennai-xxxxxx" },
                new Address { Title = "Office", Description = "No.67, 21st cross street, Chennai-xxxxxx" },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
