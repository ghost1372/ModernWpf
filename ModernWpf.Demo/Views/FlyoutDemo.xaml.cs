﻿using ModernWpf.Controls;
using System.Windows;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for Flyout.xaml
    /// </summary>
    public partial class FlyoutDemo : UserControl
    {
        public FlyoutDemo()
        {
            InitializeComponent();
        }

        private void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            Flyout f = FlyoutService.GetFlyout(Control1) as Flyout;
            if (f != null)
            {
                f.Hide();
            }
        }
    }
}
