# Font Awesome for WPF

A simple control for rendering [FontAwesome](https://fontawesome.com/) icons in WPF

## Usage

### `fa:Icon` Control

```xml
<Window x:Class="FontAwesome.WPF.Demo.ShellView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:fa="http://schemas.fontawesome.io/icons/"
        Title="Font Awesome WPF Demo" Height="300" Width="300">
    <Grid Margin="20">
        <fa:Icon IconName="font-awesome"
                 IconType="sharp"
                 Width="45"
                 Height="45"
                 VerticalAlignment="Center"
                 HorizontalAlignment="Center" />
    </Grid>
</Window>
```

### Inline Binding and Converter
> See demo project

```xml
<Window x:Class="FontAwesome.WPF.Demo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:converters="clr-namespace:FontAwesome.WPF.Converters;assembly=FontAwesome.WPF"
        Title="Font Awesome WPF Demo" Height="300" Width="300">
    <Window.Resources>
        <converters:IconConverter x:Key="IconConverter" />
    </Window.Resources>
    <Grid>
        <Menu VerticalAlignment="Top">
            <MenuItem Header="File">
                <!--  Icon without binding  -->
                <MenuItem Header="Home" Icon="{Binding Converter={StaticResource IconConverter}, ConverterParameter=house}" />

                <!--  Icon with binding  -->
                <MenuItem Header="GitHub" Icon="{Binding Icon, Converter={StaticResource IconConverter}}" />
            </MenuItem>
        </Menu>
    </Grid>
</Window>
```

### Install

[![NuGet](https://img.shields.io/nuget/v/ArchLeaders.FontAwesome.WPF.svg)](https://www.nuget.org/packages/ArchLeaders.FontAwesome.WPF) [![NuGet](https://img.shields.io/nuget/dt/ArchLeaders.FontAwesome.WPF.svg)](https://www.nuget.org/packages/ArchLeaders.FontAwesome.WPF)

#### NuGet
```powershell
Install-Package ArchLeaders.FontAwesome.WPF
```

#### Build From Source
```batch
git clone https://github.com/ArchLeaders/FontAwesome.WPF.git
dotnet build src/FontAwesome.WPF
```

### Credits

- **[Arch Leaders](https://github.com/ArchLeaders):** FontAwesome Icon control and binding converters
