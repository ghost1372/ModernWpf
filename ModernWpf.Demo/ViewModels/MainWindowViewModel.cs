using ModernWpf.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace ModernWpf.Demo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        readonly IRegionManager region;
        private DelegateCommand<NavigationViewSelectionChangedEventArgs> _SwitchCommand;
        public DelegateCommand<NavigationViewSelectionChangedEventArgs> SwitchCommand =>
            _SwitchCommand ?? (_SwitchCommand = new DelegateCommand<NavigationViewSelectionChangedEventArgs>(Switch));
        public MainWindowViewModel(IRegionManager regionManager)
        {
            region = regionManager;
        }

        private void Switch(NavigationViewSelectionChangedEventArgs e)
        {
            if (e.SelectedItem is NavigationViewItem item)
            {
                if (item.Tag != null)
                {
                    region.RequestNavigate("ContentRegion", item.Tag.ToString());
                }
            }
        }
    }
}
