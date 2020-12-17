using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Prism.Regions;

namespace ModernWpf.Demo.Views
{
    public partial class HyperlinkButtonPage
    {
        private IRegionManager region;
        public HyperlinkButtonPage(IRegionManager regionManager)
        {
            InitializeComponent();
            region = regionManager;
        }

        private void GoToHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            region.RequestNavigate("ContentRegion", "ListBoxPage");
        }
    }
}
