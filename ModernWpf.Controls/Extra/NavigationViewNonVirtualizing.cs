#if Core3_0_OR_NEWER
namespace ModernWpf.Controls
{
    public class NavigationViewNonVirtualizing : NavigationView
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (GetTemplateChild("MenuItemsHost") is ItemsRepeater leftNavRepeater)
            {
                leftNavRepeater.Layout = new NonVirtualizingStackLayout();
            }
        }
    }
}
#endif