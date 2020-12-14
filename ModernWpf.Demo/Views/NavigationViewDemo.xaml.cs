using ModernWpf.Controls;
using ModernWpf.Demo.Models;
using ModernWpf.Demo.SamplePages;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using Separator = ModernWpf.Demo.Models.Separator;
using VirtualKey = System.Windows.Input.Key;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for NavigationView
    /// </summary>
    public partial class NavigationViewDemo : UserControl
    {
        public static bool CameFromToggle = false;

        public static bool CameFromGridChange = false;

        public VirtualKey ArrowKey;

        public ObservableCollection<CategoryBase> Categories { get; set; }

        public NavigationViewDemo()
        {
            DataContext = this;
            InitializeComponent();

            nvSample2.SelectedItem = nvSample2.MenuItems.OfType<ModernWpf.Controls.NavigationViewItem>().First();
            nvSample5.SelectedItem = nvSample5.MenuItems.OfType<ModernWpf.Controls.NavigationViewItem>().First();
            nvSample6.SelectedItem = nvSample6.MenuItems.OfType<ModernWpf.Controls.NavigationViewItem>().First();
            nvSample7.SelectedItem = nvSample7.MenuItems.OfType<ModernWpf.Controls.NavigationViewItem>().First();
            nvSample8.SelectedItem = nvSample8.MenuItems.OfType<ModernWpf.Controls.NavigationViewItem>().First();

            Categories = new ObservableCollection<CategoryBase>();
            Category firstCategory = new Category { Name = "Category 1", Glyph = Symbol.Home, Tooltip = "This is category 1" };
            Categories.Add(firstCategory);
            Categories.Add(new Category { Name = "Category 2", Glyph = Symbol.Keyboard, Tooltip = "This is category 2" });
            Categories.Add(new Category { Name = "Category 3", Glyph = Symbol.Library, Tooltip = "This is category 3" });
            Categories.Add(new Category { Name = "Category 4", Glyph = Symbol.Mail, Tooltip = "This is category 4" });
            Loaded += delegate
            {
                nvSample4.SelectedItem ??= firstCategory;
            };

            //setASBSubstitutionString();

            // Fixes #218
            nvSample2.UpdateLayout();
        }

        public ModernWpf.Controls.NavigationViewPaneDisplayMode ChoosePanePosition(bool toggleOn)
        {
            if (toggleOn)
            {
                return ModernWpf.Controls.NavigationViewPaneDisplayMode.Left;
            }
            else
            {
                return ModernWpf.Controls.NavigationViewPaneDisplayMode.Top;
            }
        }

        private void NavigationView_SelectionChanged(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = (ModernWpf.Controls.NavigationViewItem)args.SelectedItem;
                if (selectedItem != null)
                {
                    string selectedItemTag = (string)selectedItem.Tag;
                    var header = (sender.Header = "Sample Page " + selectedItemTag.Substring(selectedItemTag.Length - 1)).ToString();

                    if (header.Contains("1"))
                    {
                        contentFrame.Navigate(typeof(SamplePage1));
                    }
                    else if (header.Contains("2"))
                    {
                        contentFrame.Navigate(typeof(SamplePage2));
                    }
                    else if (header.Contains("3"))
                    {
                        contentFrame.Navigate(typeof(SamplePage3));
                    }
                    else if (header.Contains("4"))
                    {
                        contentFrame.Navigate(typeof(SamplePage4));
                    }
                    else
                    {
                        contentFrame.Navigate(typeof(SampleSettingsPage));
                    }
                }
            }
        }

        private void NavigationView_SelectionChanged2(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (!CameFromGridChange)
            {
                if (args.IsSettingsSelected)
                {
                    contentFrame2.Navigate(typeof(SampleSettingsPage));
                }
                else
                {
                    var selectedItem = (ModernWpf.Controls.NavigationViewItem)args.SelectedItem;
                    string selectedItemTag = (string)selectedItem.Tag;
                    var header = (sender.Header = "Sample Page " + selectedItemTag.Substring(selectedItemTag.Length - 1)).ToString();

                    if (header.Contains("1"))
                    {
                        contentFrame2.Navigate(typeof(SamplePage1));
                    }
                    else if (header.Contains("2"))
                    {
                        contentFrame2.Navigate(typeof(SamplePage2));
                    }
                    else if (header.Contains("3"))
                    {
                        contentFrame2.Navigate(typeof(SamplePage3));
                    }
                    else if (header.Contains("4"))
                    {
                        contentFrame2.Navigate(typeof(SamplePage4));
                    }
                    else
                    {
                        contentFrame2.Navigate(typeof(SampleSettingsPage));
                    }
                }
            }

            CameFromGridChange = false;
        }

        private void NavigationView_SelectionChanged4(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame4.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = (Category)args.SelectedItem;
                string selectedItemTag = selectedItem.Name;
                var header = (sender.Header = "Sample Page " + selectedItemTag.Substring(selectedItemTag.Length - 1)).ToString();

                if (header.Contains("1"))
                {
                    contentFrame4.Navigate(typeof(SamplePage1));
                }
                else if (header.Contains("2"))
                {
                    contentFrame4.Navigate(typeof(SamplePage2));
                }
                else if (header.Contains("3"))
                {
                    contentFrame4.Navigate(typeof(SamplePage3));
                }
                else if (header.Contains("4"))
                {
                    contentFrame4.Navigate(typeof(SamplePage4));
                }
                else
                {
                    contentFrame4.Navigate(typeof(SampleSettingsPage));
                }
            }
        }


        private void NavigationView_SelectionChanged5(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame5.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = (ModernWpf.Controls.NavigationViewItem)args.SelectedItem;
                string selectedItemTag = (string)selectedItem.Tag;
                var header = (sender.Header = "Sample Page " + selectedItemTag.Substring(selectedItemTag.Length - 1)).ToString();

                if (header.Contains("1"))
                {
                    contentFrame5.Navigate(typeof(SamplePage1));
                }
                else if (header.Contains("2"))
                {
                    contentFrame5.Navigate(typeof(SamplePage2));
                }
                else if (header.Contains("3"))
                {
                    contentFrame5.Navigate(typeof(SamplePage3));
                }
                else if (header.Contains("4"))
                {
                    contentFrame5.Navigate(typeof(SamplePage4));
                }
                else
                {
                    contentFrame5.Navigate(typeof(SampleSettingsPage));
                }
            }
        }
        private void NavigationView_SelectionChanged6(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame6.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = (ModernWpf.Controls.NavigationViewItem)args.SelectedItem;
                var header = (sender.Header = "Sample Page " + (string)selectedItem.Tag).ToString();

                if (header.Contains("1"))
                {
                    contentFrame6.Navigate(typeof(SamplePage1));
                }
                else if (header.Contains("2"))
                {
                    contentFrame6.Navigate(typeof(SamplePage2));
                }
                else if (header.Contains("3"))
                {
                    contentFrame6.Navigate(typeof(SamplePage3));
                }
                else if (header.Contains("4"))
                {
                    contentFrame6.Navigate(typeof(SamplePage4));
                }
                else
                {
                    contentFrame6.Navigate(typeof(SampleSettingsPage));
                }
            }
        }

        private void NavigationView_SelectionChanged7(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame7.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = (ModernWpf.Controls.NavigationViewItem)args.SelectedItem;
                var header = (sender.Header = "Sample Page " + (string)selectedItem.Tag).ToString();

                if (header.Contains("1"))
                {
                    contentFrame7.Navigate(typeof(SamplePage1), null, args.RecommendedNavigationTransitionInfo);
                }
                else if (header.Contains("2"))
                {
                    contentFrame7.Navigate(typeof(SamplePage2), null, args.RecommendedNavigationTransitionInfo);
                }
                else if (header.Contains("3"))
                {
                    contentFrame7.Navigate(typeof(SamplePage3), null, args.RecommendedNavigationTransitionInfo);
                }
                else if (header.Contains("4"))
                {
                    contentFrame7.Navigate(typeof(SamplePage4), null, args.RecommendedNavigationTransitionInfo);
                }
                else
                {
                    contentFrame7.Navigate(typeof(SampleSettingsPage), null, args.RecommendedNavigationTransitionInfo);
                }
            }
        }

        private void NavigationView_SelectionChanged8(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            /* NOTE: for this function to work, every NavigationView must follow the same naming convention: nvSample# (i.e. nvSample3),
            and every corresponding content frame must follow the same naming convention: contentFrame# (i.e. contentFrame3) */

            // Get the sample number
            string sampleNum = (sender.Name).Substring(8);

            if (args.IsSettingsSelected)
            {
                contentFrame8.Navigate(typeof(SampleSettingsPage));
            }
            else
            {
                var selectedItem = (ModernWpf.Controls.NavigationViewItem)args.SelectedItem;
                string selectedItemTag = ((string)selectedItem.Tag);
                var header = (sender.Header = "Sample Page " + selectedItemTag.Substring(selectedItemTag.Length - 1)).ToString();

                if (header.Contains("1"))
                {
                    contentFrame8.Navigate(typeof(SamplePage1));
                }
                else if (header.Contains("2"))
                {
                    contentFrame8.Navigate(typeof(SamplePage2));
                }
                else if (header.Contains("3"))
                {
                    contentFrame8.Navigate(typeof(SamplePage3));
                }
                else if (header.Contains("4"))
                {
                    contentFrame8.Navigate(typeof(SamplePage4));
                }
                else
                {
                    contentFrame8.Navigate(typeof(SampleSettingsPage));
                }
            }
        }

        private void databindHeader_Checked(object sender, RoutedEventArgs e)
        {
            Categories = new ObservableCollection<CategoryBase>()
            {
                new Header { Name = "Header1 "},
                new Category { Name = "Category 1", Glyph = Symbol.Home, Tooltip = "This is category 1" },
                new Category { Name = "Category 2", Glyph = Symbol.Keyboard, Tooltip = "This is category 2" },
                new Separator(),
                new Header { Name = "Header2 "},
                new Category {Name = "Category 3", Glyph = Symbol.Library, Tooltip = "This is category 3" },
                new Category {Name = "Category 4", Glyph = Symbol.Mail, Tooltip = "This is category 3" }
            };
        }

        private void databindHeader_Checked_Unchecked(object sender, RoutedEventArgs e)
        {
            Categories = new ObservableCollection<CategoryBase>()
            {
                new Category { Name = "Category 1", Glyph = Symbol.Home, Tooltip = "This is category 1" },
                new Category { Name = "Category 2", Glyph = Symbol.Keyboard, Tooltip = "This is category 2" },
                new Category {Name = "Category 3", Glyph = Symbol.Library, Tooltip = "This is category 3" },
                new Category {Name = "Category 4", Glyph = Symbol.Mail, Tooltip = "This is category 3" }
            };
        }

        /*
        private void Grid_ManipulationDelta1(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            var grid = sender as Grid;
            grid.Width = grid.ActualWidth + e.Delta.Translation.X;
        }
        */

        private void headerCheck_Click(object sender, RoutedEventArgs e)
        {
            nvSample.AlwaysShowHeader = (sender as CheckBox).IsChecked == true ? true : false;
        }

        private void settingsCheck_Click(object sender, RoutedEventArgs e)
        {
            nvSample.IsSettingsVisible = (sender as CheckBox).IsChecked == true ? true : false;
        }

        private void visibleCheck_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                nvSample.IsBackButtonVisible = ModernWpf.Controls.NavigationViewBackButtonVisible.Visible;
            }
            else
            {
                nvSample.IsBackButtonVisible = ModernWpf.Controls.NavigationViewBackButtonVisible.Collapsed;
            }
        }

        private void enableCheck_Click(object sender, RoutedEventArgs e)
        {
            nvSample.IsBackEnabled = (sender as CheckBox).IsChecked == true ? true : false;
        }

        private void autoSuggestCheck_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                AutoSuggestBox asb = new AutoSuggestBox() { QueryIcon = new SymbolIcon(Symbol.Find) };
                asb.SetValue(AutomationProperties.NameProperty, "search");
                nvSample.AutoSuggestBox = asb;

                //setASBSubstitutionString();
            }
            else
            {
                nvSample.AutoSuggestBox = null;
                //navViewASB.Value = null;
            }
        }

        /*
        private void setASBSubstitutionString()
        {
            navViewASB.Value = "\r\n    <muxc:NavigationView.AutoSuggestBox> \r\n        <AutoSuggestBox QueryIcon=\"Find\" AutomationProperties.Name=\"Search\" /> \r\n    <" + "/" + "muxc:NavigationView.AutoSuggestBox> \r\n";
        }
        */

        private void panemc_Check_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                PaneHyperlink.Visibility = Visibility.Visible;
            }
            else
            {
                PaneHyperlink.Visibility = Visibility.Collapsed;
            }
        }

        private void paneFooterCheck_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                FooterStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                FooterStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void panePositionLeft_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).IsChecked == true)
            {
                if ((sender as RadioButton).Name == "nvSampleLeft" && nvSample != null)
                {
                    nvSample.PaneDisplayMode = ModernWpf.Controls.NavigationViewPaneDisplayMode.Left;
                    nvSample.IsPaneOpen = true;
                    FooterStackPanel.Orientation = Orientation.Vertical;
                }
                else if ((sender as RadioButton).Name == "nvSample8Left" && nvSample8 != null)
                {
                    nvSample8.PaneDisplayMode = ModernWpf.Controls.NavigationViewPaneDisplayMode.Left;
                    nvSample8.IsPaneOpen = true;
                }
            }
        }


        private void panePositionTop_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).IsChecked == true)
            {
                if ((sender as RadioButton).Name == "nvSampleTop" && nvSample != null)
                {
                    nvSample.PaneDisplayMode = ModernWpf.Controls.NavigationViewPaneDisplayMode.Top;
                    nvSample.IsPaneOpen = false;
                    FooterStackPanel.Orientation = Orientation.Horizontal;
                }
                else if ((sender as RadioButton).Name == "nvSample8Top" && nvSample8 != null)
                {
                    nvSample8.PaneDisplayMode = ModernWpf.Controls.NavigationViewPaneDisplayMode.Top;
                    nvSample8.IsPaneOpen = false;
                }
            }
        }

        private void panePositionLeftCompact_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).IsChecked == true)
            {
                if ((sender as RadioButton).Name == "nvSample8LeftCompact" && nvSample8 != null)
                {
                    nvSample8.PaneDisplayMode = ModernWpf.Controls.NavigationViewPaneDisplayMode.LeftCompact;
                    nvSample8.IsPaneOpen = false;
                }
            }
        }

        private void sffCheck_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                nvSample.SelectionFollowsFocus = ModernWpf.Controls.NavigationViewSelectionFollowsFocus.Enabled;
            }
            else
            {
                nvSample.SelectionFollowsFocus = ModernWpf.Controls.NavigationViewSelectionFollowsFocus.Disabled;
            }
        }

        private void suppressselectionCheck_Checked_Click(object sender, RoutedEventArgs e)
        {
            SamplePage2Item.SelectsOnInvoked = (sender as CheckBox).IsChecked == true ? false : true;
        }
    }
}
