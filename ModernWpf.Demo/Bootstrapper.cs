using ModernWpf.Demo.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace ModernWpf.Demo
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ButtonDemo>();
            containerRegistry.RegisterForNavigation<NavigationViewDemo>();
            containerRegistry.RegisterForNavigation<ProgressBarDemo>();
            containerRegistry.RegisterForNavigation<InputsDemo>();
            containerRegistry.RegisterForNavigation<FlyoutDemo>();
            containerRegistry.RegisterForNavigation<ListViewDemo>();
            containerRegistry.RegisterForNavigation<GridViewDemo>();
            containerRegistry.RegisterForNavigation<TabControlDemo>();
            containerRegistry.RegisterForNavigation<RepeaterDemo>();
            containerRegistry.RegisterForNavigation<SplitViewDemo>();
        }
    }
}
