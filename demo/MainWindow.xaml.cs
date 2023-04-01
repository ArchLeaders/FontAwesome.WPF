using System.Windows;

namespace FontAwesome.WPF.Demo;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        (DataContext as MainWindowViewModel)!.Icon = "circle-stop:regular";
        // icon0.IconName = "cloud-sun-rain";
        // icon0.IconType = "solid";
        // icon0.Rotation = 90;
    }
}
