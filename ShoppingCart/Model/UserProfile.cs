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
                new Address
                {
                    Title = "Home",
                    Description = "No. 67, 21st Cross Street, Anna Nagar, Chennai - 600040"
                },
                new Address
                {
                    Title = "Office",
                    Description = "RMZ Millenia Business Park, Perungudi, Chennai - 600096"
                },
                new Address
                {
                    Title = "Parents' House",
                    Description = "No. 12, 5th Main Road, Besant Nagar, Chennai - 600090"
                },
                new Address
                {
                    Title = "Friend's Place",
                    Description = "Flat 204, Block B, Olympia Grande, Pallavaram, Chennai - 600043"
                },
            };

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
