using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FontAwesome.WPF;

[TemplatePart(Name = "PART_Path", Type = typeof(System.Windows.Shapes.Path))]
public class Icon : Control
{
    private System.Windows.Shapes.Path? _path;
    private Geometry? _data;

    static Icon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(Icon), new FrameworkPropertyMetadata(typeof(Icon)));
    }

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Icon));
    public CornerRadius CornerRadius {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static new readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register("BorderThickness", typeof(double), typeof(Icon));
    public new double BorderThickness {
        get => (double)GetValue(BorderThicknessProperty);
        set => SetValue(BorderThicknessProperty, value);
    }

    public static readonly DependencyProperty IconNameProperty = DependencyProperty.Register("IconName", typeof(string),
        typeof(Icon), new(string.Empty, OnIconChangedCallBack));
    public string IconName {
        get => (string)GetValue(IconNameProperty);
        set => SetValue(IconNameProperty, value);
    }

    public static readonly DependencyProperty IconTypeProperty = DependencyProperty.Register("IconType", typeof(string),
        typeof(Icon), new("solid", OnIconChangedCallBack));
    public string IconType {
        get => (string)GetValue(IconTypeProperty);
        set => SetValue(IconTypeProperty, value);
    }

    private static void OnIconChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender is Icon icon) {
            if (FontAwesomeHelper.TryGetIcon(icon.IconName, icon.IconType, out icon._data) && icon._path != null) {
                icon._path.Data = icon._data;
            }
        }
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _path = (System.Windows.Shapes.Path)GetTemplateChild("PART_Path");
        _path.Data = _data;
    }
}
