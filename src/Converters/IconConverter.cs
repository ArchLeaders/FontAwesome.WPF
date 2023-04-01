using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FontAwesome.WPF.Converters;

public class IconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string valueStr) {
            return GetIcon(valueStr);
        }
        else if (parameter is string parameterStr) {
            return GetIcon(parameterStr);
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Icon icon) {
            return icon.IconName;
        }

        return value;
    }

    private Icon GetIcon(string str)
    {
        Icon icon = new();

        if (str.Contains(':')) {
            var pts = str.Split(':');
            icon.IconName = pts[0];
            icon.IconType = pts[1];
        }
        else {
            icon.IconName = str;
        }

        return icon;
    }
}
