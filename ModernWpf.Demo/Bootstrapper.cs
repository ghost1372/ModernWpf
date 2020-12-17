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
            containerRegistry.RegisterForNavigation<ExpanderPage>();
            containerRegistry.RegisterForNavigation<FlyoutPage>();
            containerRegistry.RegisterForNavigation<GridSplitterPage>();
            containerRegistry.RegisterForNavigation<GridViewPage>();
            containerRegistry.RegisterForNavigation<GroupBoxPage>();
            containerRegistry.RegisterForNavigation<HyperlinkButtonPage>();
            containerRegistry.RegisterForNavigation<ItemsRepeaterPage>();
            containerRegistry.RegisterForNavigation<ListBoxPage>();
            containerRegistry.RegisterForNavigation<ListViewPage>();
            containerRegistry.RegisterForNavigation<ListView2Page>();
            containerRegistry.RegisterForNavigation<MenuFlyoutPage>();
            containerRegistry.RegisterForNavigation<MenuPage>();
            containerRegistry.RegisterForNavigation<NavigationViewPage>();
            containerRegistry.RegisterForNavigation<NumberBoxPage>();
            containerRegistry.RegisterForNavigation<PageTransitionPage>();
            containerRegistry.RegisterForNavigation<PasswordBoxPage>();
            containerRegistry.RegisterForNavigation<PersonPicturePage>();
            containerRegistry.RegisterForNavigation<PivotPage>();
            containerRegistry.RegisterForNavigation<PopupPlacementPage>();
            containerRegistry.RegisterForNavigation<ProgressPage>();
            containerRegistry.RegisterForNavigation<ProgressRingPerfPage>();
            containerRegistry.RegisterForNavigation<RadioButtonsPage>();
            
           
            containerRegistry.RegisterForNavigation<TabControlDemo>();
            containerRegistry.RegisterForNavigation<SplitViewDemo>();
        }
    }
}
