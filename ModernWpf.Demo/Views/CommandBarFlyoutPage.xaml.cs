using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;
using System.Windows;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for CommandBarFlyoutPage.xaml
    /// </summary>
    public partial class CommandBarFlyoutPage : UserControl
    {
        private readonly CommandBarFlyout CommandBarFlyout1;

        public CommandBarFlyoutPage()
        {
            InitializeComponent();
            CommandBarFlyout1 = (CommandBarFlyout)Resources[nameof(CommandBarFlyout1)];
        }

        private void OnElementClicked(object sender, RoutedEventArgs e)
        {
            // Do custom logic
            SelectedOptionText.Text = "You clicked: " + (sender as AppBarButton).Label;

            //var command = (ICommandBarElement)sender;
            //if (CommandBarFlyout1.PrimaryCommands.Contains(command))
            //{
            //    CommandBarFlyout1.PrimaryCommands.Remove(command);
            //}
            //else if (CommandBarFlyout1.SecondaryCommands.Contains(command))
            //{
            //    CommandBarFlyout1.SecondaryCommands.Remove(command);
            //}
        }

        private void ShowMenu(bool isTransient)
        {
            CommandBarFlyout1.ShowMode = isTransient ? FlyoutShowMode.Transient : FlyoutShowMode.Standard;
            CommandBarFlyout1.ShowAt(Image1);
        }

        private void MyImageButton_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            // always show a context menu in standard mode
            ShowMenu(false);
        }

        private void MyImageButton_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu((sender as Button).IsMouseOver);
        }
    }
}
