using System.Windows;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for ThemesPage.xaml
    /// </summary>
    public partial class ThemesPage : UserControl
    {
        public ThemesPage()
        {
            InitializeComponent();

            if (App.IsMultiThreaded)
            {
                AccentColorPicker.Visibility = Visibility.Collapsed;
            }
        }

        ~ThemesPage()
        {
        }
    }

    public class ShapePreset
    {
        public ShapePreset(string value, string displayName)
        {
            Value = value;
            DisplayName = displayName;
        }

        public string Value { get; }

        public string DisplayName { get; }
    }
}
