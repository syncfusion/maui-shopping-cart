using System.Globalization;

namespace ShoppingCart
{
    public class TagSeparateConverter : IValueConverter
    {
       
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is List<string> tags && tags.Count > 0)
            {
                return string.Join(" | ", tags);
            }
            return string.Empty;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
