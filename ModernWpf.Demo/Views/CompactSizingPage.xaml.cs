using ModernWpf.Demo.SamplePages;
using ModernWpf.Media.Animation;
using System.Windows;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for CompactSizingPage.xaml
    /// </summary>
    public partial class CompactSizingPage : UserControl
    {
        public CompactSizingPage()
        {
            InitializeComponent();
        }
        private void Example1_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SampleStandardSizingPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Standard_Checked(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SampleStandardSizingPage), null, new SuppressNavigationTransitionInfo());
        }

        private void Compact_Checked(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SampleCompactSizingPage), null, new SuppressNavigationTransitionInfo());
        }
    }
}
