using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ModernWpf.Demo.Tools
{
    public class CornerRadiusToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cr = (CornerRadius)value;
            if (cr.TopLeft == cr.TopRight &&
                cr.TopLeft == cr.BottomRight &&
                cr.TopLeft == cr.BottomRight)
            {
                return cr.TopLeft;
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new CornerRadius((double)value);
        }
    }
}
