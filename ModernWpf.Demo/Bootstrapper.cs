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
            containerRegistry.RegisterForNavigation<AppBarButtonPage>();
            containerRegistry.RegisterForNavigation<AppBarSeparatorPage>();
            containerRegistry.RegisterForNavigation<AppBarToggleButtonPage>();
            containerRegistry.RegisterForNavigation<AutoSuggestBoxPage>();
            containerRegistry.RegisterForNavigation<ButtonsPage>();
            containerRegistry.RegisterForNavigation<CalendarPage>();
            containerRegistry.RegisterForNavigation<CheckBoxPage>();
            containerRegistry.RegisterForNavigation<ComboBoxPage>();
            containerRegistry.RegisterForNavigation<CommandBarFlyoutPage>();
            containerRegistry.RegisterForNavigation<CommandBarPage>();
            containerRegistry.RegisterForNavigation<CompactSizingPage>();
            containerRegistry.RegisterForNavigation<ContentDialogPage>();
            containerRegistry.RegisterForNavigation<ContextMenuPage>();
            containerRegistry.RegisterForNavigation<ControlPalettePage>();
            containerRegistry.RegisterForNavigation<DataGridPage>();
            containerRegistry.RegisterForNavigation<DatePickerPage>();
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
