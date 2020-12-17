using Prism.Regions;
using System.Windows;

namespace ModernWpf.Demo.Views
{
    public partial class HyperlinkButtonPage
    {
        private readonly IRegionManager region;
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
