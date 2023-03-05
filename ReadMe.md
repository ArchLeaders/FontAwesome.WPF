# Font Awesome for WPF

A set of primitive controls for rendering the Font Awesome icons in WPF - based off [Font-Awesome-WPF](https://github.com/charri/Font-Awesome-WPF) by [charri](https://github.com/charri)

- [Font Awesome](https://fontawesome.com/)

### Usage

```xml
<Window x:Class="FontAwesome.WPF.Demo.ShellView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:fa="http://schemas.fontawesome.io/icons/"
        Title="Font Awesome WPF Demo" Height="300" Width="300">
    <Grid Margin="20">
        <fa:Icon Value="Flag"
                 VerticalAlignment="Center"
                 HorizontalAlignment="Center" />
    </Grid>
</Window>
```

#### TextBlock based control

```xml
<fa:Glyph Value="Flag" />
```
> The Image based `fa:Icon` control is useful when you need to fill an entire space. Whereas the TextBlock base is useful when you need a certain FontSize.

#### Asign to Button.Content

```xml
<Button fa:Awesome.Content="Flag" 
        FontFamily="pack://application:,,,/FontAwesome.WPF;component/#FontAwesome"/>
```
> VS2013 XAML Designer has issues when using fonts embedded in another assembly (like this scenario), which prevents it to dispaly the glyph properly.
>
> You could either grab a copy of TTF font file and include it in you Project as a Resource, so to use it in FontFamily, or you could follow the advices proposed in this [StackOverflow thread](https://stackoverflow.com/questions/29615572/visual-studio-designer-isnt-displaying-embedded-font/29636373#29636373).

#### Code-Behind

```cs
Icon = ImageAwesome.CreateImageSource(FontAwesomeIcon.Flag, Brushes.Black);
```

### Features

#### Spinning Icons

```xml
<fa:Icon Value="Spinner" Spin="True" SpinDuration="5" />
```

#### Rotated/Flipped

```xml
<fa:Icon Value="Spinner" FlipOrientation="Horizontal" Rotation="90" />
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

- **[Arch Leaders](https://github.com/ArchLeaders):** FontAwesome v6 update, rewrite in DotNET standard
- **[charri](https://github.com/charri):** Original library author