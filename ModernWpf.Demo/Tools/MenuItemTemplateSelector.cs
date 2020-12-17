using ModernWpf.Demo.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Separator = ModernWpf.Demo.Models.Separator;

namespace ModernWpf.Demo.Tools
{
    [ContentProperty("ItemTemplate")]
    internal class MenuItemTemplateSelector : DataTemplateSelector
    {
        internal DataTemplate HeaderTemplate = (DataTemplate)XamlReader.Parse(
            @"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                   <NavigationViewItemHeader Content='{Binding Name}' />
                  </DataTemplate>");

        internal DataTemplate SeparatorTemplate = (DataTemplate)XamlReader.Parse(
            @"<DataTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
                    <NavigationViewItemSeparator />
                  </DataTemplate>");

        public DataTemplate ItemTemplate { get; set; }

        //public string PaneTitle { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return item is Separator ? SeparatorTemplate : item is Header ? HeaderTemplate : ItemTemplate;
        }
    }
}