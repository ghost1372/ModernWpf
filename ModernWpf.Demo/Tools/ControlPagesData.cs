using ModernWpf.Demo.Views;
using System;
using System.Collections.Generic;

namespace ModernWpf.Demo.Tools
{
    public class ControlPagesData : List<ControlInfoDataItem>
    {
        public ControlPagesData()
        {
            AddPage(typeof(Overview));
            AddPage(typeof(ControlPalettePage), "Control Palette");
            AddPage(typeof(ThemesPage));
            AddPage(typeof(ThemeResourcesPage), "Theme Resources");
            AddPage(typeof(CompactSizingPage), "Compact Sizing");
            AddPage(typeof(PageTransitionPage), "Page Transitions");
            AddPage(typeof(ThreadedUIPage), "Threaded UI");
            AddPage(typeof(AppBarButtonPage));
            AddPage(typeof(AppBarSeparatorPage));
            AddPage(typeof(AppBarToggleButtonPage));
            AddPage(typeof(AutoSuggestBoxPage));
            AddPage(typeof(ButtonsPage));
            AddPage(typeof(CalendarPage));
            AddPage(typeof(CheckBoxPage));
            AddPage(typeof(ComboBoxPage));
            AddPage(typeof(CommandBarPage));
            AddPage(typeof(CommandBarFlyoutPage));
            AddPage(typeof(ContentDialogPage));
            AddPage(typeof(ContextMenuPage));
            AddPage(typeof(DataGridPage));
            AddPage(typeof(DatePickerPage));
            AddPage(typeof(ExpanderPage));
            AddPage(typeof(FlyoutPage));
            AddPage(typeof(GridSplitterPage));
            AddPage(typeof(GridViewPage));
            AddPage(typeof(GroupBoxPage));
            AddPage(typeof(HyperlinkButtonPage));
            AddPage(typeof(ItemsRepeaterPage));
            AddPage(typeof(ListBoxPage));
            AddPage(typeof(ListViewPage));
            AddPage(typeof(ListView2Page), "ListView (ModernWPF)");
            AddPage(typeof(MenuPage));
            AddPage(typeof(MenuFlyoutPage));
            AddPage(typeof(NavigationViewPage));
            AddPage(typeof(NumberBoxPage));
            AddPage(typeof(PasswordBoxPage));
            AddPage(typeof(PersianToolkit));
            AddPage(typeof(PersonPicturePage));
            AddPage(typeof(PopupPlacementPage));
            AddPage(typeof(ProgressPage), "Progress Controls");
            AddPage(typeof(RadioButtonsPage));
            AddPage(typeof(RatingControlPage));
            AddPage(typeof(RichTextBoxPage));
            AddPage(typeof(ShadowPage));
            AddPage(typeof(SimpleStackPanelPage));
            AddPage(typeof(SliderPage));
            AddPage(typeof(SplitViewPage));
            AddPage(typeof(StatusBarPage));
            AddPage(typeof(TabControlPage));
            AddPage(typeof(PivotPage), "TabControlPivotStyle");
            AddPage(typeof(TextBoxPage));
            AddPage(typeof(ToggleSwitchPage));
            AddPage(typeof(ToolTipPage));
            AddPage(typeof(TreeViewPage));
            AddPage(typeof(WindowPage));
        }

        private void AddPage(Type pageType, string displayName = null)
        {
            Add(new ControlInfoDataItem(pageType, displayName));
        }
    }
}
