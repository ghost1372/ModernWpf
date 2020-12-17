using System.Windows;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for ExpanderPage.xaml
    /// </summary>
    public partial class ExpanderPage : UserControl
    {
        public ExpanderPage()
        {
            InitializeComponent();
            UpdateVisualState();
        }

        private void ExpandDirection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            VisualStateManager.GoToElementState((FrameworkElement)Content, expander.ExpandDirection.ToString(), false);
        }
    }
}
