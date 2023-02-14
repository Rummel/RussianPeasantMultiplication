using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RussianPeasantMultiplication
{
    public class LeftStrikeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                int number = (int)value;
                return number.IsEven();
            }
            // If value is not an integer. Do not throw an exception in the converter.
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
