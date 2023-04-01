using CommunityToolkit.Mvvm.ComponentModel;

namespace FontAwesome.WPF.Demo;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string icon = "github";
}
