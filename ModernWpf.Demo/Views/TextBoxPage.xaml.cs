using System.Windows;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for TextBoxPage.xaml
    /// </summary>
    public partial class TextBoxPage : UserControl
    {
        public TextBoxPage()
        {
            InitializeComponent();
        }
        private void ClearClipboard(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
        }

        private void OptionsExpander_Expanded(object sender, RoutedEventArgs e)
        {
            OptionsExpander.Header = "Hide options";
        }

        private void OptionsExpander_Collapsed(object sender, RoutedEventArgs e)
        {
            OptionsExpander.Header = "Show options";
        }
    }
}
