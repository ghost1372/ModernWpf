using ModernWpf.Controls;
using ModernWpf.Demo.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using GridView = ModernWpf.Controls.GridView;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for GridViewDemo.xaml
    /// </summary>
    public partial class GridViewDemo : UserControl
    {
        WrapPanel StyledGridIWG;
        public GridViewDemo()
        {
            InitializeComponent();
            this.DataContext = this;

            // Get data objects and place them into an ObservableCollection
            List<CustomDataObject> tempList = CustomDataObject.GetDataObjects();
            ObservableCollection<CustomDataObject> Items = new ObservableCollection<CustomDataObject>(tempList);
            ObservableCollection<CustomDataObject> Items2 = new ObservableCollection<CustomDataObject>(tempList);
            BasicGridView.ItemsSource = Items2;
            ContentGridView.ItemsSource = Items;
            StyledGrid.ItemsSource = Items;
        }

        private void ItemTemplate_Checked(object sender, RoutedEventArgs e)
        {
            var tag = (sender as FrameworkElement).Tag;
            if (tag != null)
            {
                string template = tag.ToString();
                ContentGridView.ItemTemplate = (DataTemplate)this.Resources[template];
            }
        }

        private void ContentGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is GridView gridView)
            {
                SelectionOutput.Text = string.Format("You have selected {0} item(s).", gridView.SelectedItems.Count);
            }
        }

        private void ContentGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClickOutput.Text = "You clicked " + (e.ClickedItem as CustomDataObject).Title + ".";
        }

        private void BasicGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClickOutput0.Text = "You clicked " + (e.ClickedItem as CustomDataObject).Title + ".";
        }

        private void ItemClickCheckBox_Click(object sender, RoutedEventArgs e)
        {
            ClickOutput.Text = string.Empty;
        }

        private void SelectionCheckBox_Click(object sender, RoutedEventArgs e)
        {
            SelectionOutput.Text = string.Empty;
        }

        private void FlowDirectionCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (ContentGridView.FlowDirection == FlowDirection.LeftToRight)
            {
                ContentGridView.FlowDirection = FlowDirection.RightToLeft;
            }
            else
            {
                ContentGridView.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        private void SelectionModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContentGridView != null)
            {
                string colorName = e.AddedItems[0].ToString();
                switch (colorName)
                {
                    case "Single":
                        ContentGridView.SelectionMode = SelectionMode.Single;
                        break;
                    case "Multiple":
                        ContentGridView.SelectionMode = SelectionMode.Multiple;
                        break;
                    case "Extended":
                        ContentGridView.SelectionMode = SelectionMode.Extended;
                        break;
                }
            }
        }

        private void StyledGrid_InitWrapGrid(object sender, RoutedEventArgs e)
        {
            // Update ItemsWrapGrid object created on page load by assigning it to StyledGrid's ItemWrapGrid
            StyledGridIWG = sender as WrapPanel;

            // Now we can change StyledGrid's MaximumRowsorColumns property within its ItemsPanel>ItemsPanelTemplate>ItemsWrapGrid.
            //StyledGridIWG.MaximumRowsOrColumns = 3;
        }
    }
}
