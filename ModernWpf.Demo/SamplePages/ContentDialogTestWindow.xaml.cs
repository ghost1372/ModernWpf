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
using ModernWpf.Controls;
using ModernWpf.Demo.Tools;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for ContentDialogTestWindow.xaml
    /// </summary>
    public partial class ContentDialogTestWindow : Window
    {
        public ContentDialogTestWindow()
        {
            InitializeComponent();
        }

        private void ShowDialogInThisWindow(object sender, RoutedEventArgs e)
        {
            _ = new TestContentDialog().ShowAsync();
        }

        private void ShowDialogInMainWindow(object sender, RoutedEventArgs e)
        {
            DispatcherHelper.RunOnMainThread(async () =>
            {
                try
                {
                    await new TestContentDialog() { Owner = Application.Current.MainWindow }.ShowAsync();
                }
                catch (Exception ex)
                {
                    this.RunOnUIThread(() =>
                    {
                        _ = new ContentDialog
                        {
                            Owner = this,
                            Content = ex.Message,
                            CloseButtonText = "Close"
                        }.ShowAsync();
                    });
                }
            });
        }
    }
}
