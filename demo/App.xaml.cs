using System.Windows;

namespace FontAwesome.WPF.Demo;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        FontAwesomeHelper.SetVersion(6).Wait();
    }
}