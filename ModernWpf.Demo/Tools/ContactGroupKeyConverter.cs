using System;
using System.Globalization;
using System.Windows.Data;

namespace ModernWpf.Demo.Tools
{
    public class ContactGroupKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string) value).Substring(0, 1).ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}