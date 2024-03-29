﻿using System.Globalization;
using System.Windows.Data;

namespace FontAwesome.WPF.Converters;

internal class DivideValue : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (double)value / 2;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (double)value * 2;
    }
}
