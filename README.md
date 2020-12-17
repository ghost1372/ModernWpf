[![nuget-version](https://img.shields.io/nuget/v/ModernWpfUis.svg)](https://www.nuget.org/packages/ModernWpfUis) 
[![Nuget](https://img.shields.io/nuget/dt/ModernWpfUis)](https://www.nuget.org/packages/ModernWpfUis) 


# ModernWPF UI Library
Modern styles and controls for your WPF applications.

> **_NOTE:_**  This version is an unofficial version of the [ModernWPF](https://github.com/Kinnara/ModernWpf)

## Why was this version created?
The official version is depends on WinRT, This version has removed this dependency and the size of the output file will be less and there will be no need for SDK contract. also this version includes some controls and features that are not included in the original project [for example support for Persian Calendar and PersianDatePicker, More Controls and More Styles]

> **_NOTE:_**  WinRT based features will not work in this version

- All styles, and controls of the original version are also included in this version.
- This version has a tidier and cleaner structure and uses a cleaner demo.
- This project will periodically update its code based on the original version, so all the new features and fixed bugs of the original version will be included in this version.
- I am not responsible for bug fixes or adding new features. For such tasks, please contact the [original](https://github.com/Kinnara/ModernWpf) version.
- If you have any other questions, you can contact us [here](https://github.com/ghost1372/ModernWpf/discussions)

## Usage

Step 1: Add a reference to ModernWpfUis or search for ModernWpfUis on the nuget; 

```Install-Package ModernWpfUis```

Step 2: Add code in App.xaml as follows:
```XML
xmlns:ui="http://schemas.modernwpf.com/2019">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ui:ThemeResources />
                <ui:XamlControlsResources />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
```
See the [wiki](https://github.com/Kinnara/ModernWpf/wiki) for more information.

## Screenshots
![Overview of controls (dark theme)](https://raw.githubusercontent.com/Kinnara/ModernWpf/master/docs/images/Controls.Light.png)

![Control palette](https://raw.githubusercontent.com/Kinnara/ModernWpf/master/docs/images/ControlPalette1.png)

![NumberBox](https://raw.githubusercontent.com/Kinnara/ModernWpf/master/docs/images/NumberBox.png)

![Calendar](https://raw.githubusercontent.com/Kinnara/ModernWpf/master/docs/images/Calendar.png)

![Progress controls](https://raw.githubusercontent.com/Kinnara/ModernWpf/master/docs/images/Progress.png)
