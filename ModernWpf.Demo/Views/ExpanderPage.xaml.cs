using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
