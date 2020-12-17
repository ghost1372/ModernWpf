using ModernWpf.Controls;
using ModernWpf.Demo.Tools;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string AutoHideScrollBarsKey = "AutoHideScrollBars";
        private readonly ControlPagesData _controlPages = new ControlPagesData();
        private readonly IRegionManager region;

        public MainWindow()
        {

        }
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            region = regionManager;
        }

        private void Control2_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            //We only want to get results when it was a user typing,
            //otherwise we assume the value got filled in by TextMemberPath
            //or the handler for SuggestionChosen
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suggestions = SearchControls(sender.Text);

                if (suggestions.Count > 0)
                {
                    sender.ItemsSource = suggestions;
                }
                else
                {
                    sender.ItemsSource = new string[] { "No results found" };
                }
            }
        }

        private void Control2_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null && args.ChosenSuggestion is ControlInfoDataItem)
            {
                //User selected an item, take an action
                SelectControl(args.ChosenSuggestion as ControlInfoDataItem);
            }
            else if (!string.IsNullOrEmpty(args.QueryText))
            {
                //Do a fuzzy search based on the text
                var suggestions = SearchControls(sender.Text);
                if (suggestions.Count > 0)
                {
                    SelectControl(suggestions.FirstOrDefault());
                }
            }
        }

        private void Control2_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            //Don't autocomplete the TextBox when we are showing "no results"
            if (args.SelectedItem is ControlInfoDataItem control)
            {
                sender.Text = control.Title;
            }
        }

        private void SelectControl(ControlInfoDataItem control)
        {
            if (control != null)
            {
                region.RequestNavigate("ContentRegion", control.PageType.Name);
            }
        }
        private List<ControlInfoDataItem> SearchControls(string query)
        {
            var querySplit = query.Split(' ');
            var suggestions = _controlPages.Where(
                item =>
                {
                    // Idea: check for every word entered (separated by space) if it is in the name,  
                    // e.g. for query "split button" the only result should "SplitButton" since its the only query to contain "split" and "button" 
                    // If any of the sub tokens is not in the string, we ignore the item. So the search gets more precise with more words 
                    bool flag = true;
                    foreach (string queryToken in querySplit)
                    {
                        // Check if token is not in string 
                        if (item.Title.IndexOf(queryToken, StringComparison.CurrentCultureIgnoreCase) < 0)
                        {
                            // Token is not in string, so we ignore this item. 
                            flag = false;
                        }
                    }
                    return flag;
                });
            return suggestions.OrderByDescending(i => i.Title.StartsWith(query, StringComparison.CurrentCultureIgnoreCase)).ThenBy(i => i.Title).ToList();
        }


        private void Default_Checked(object sender, RoutedEventArgs e)
        {
            SetApplicationTheme(null);
        }

        private void Light_Checked(object sender, RoutedEventArgs e)
        {
            SetApplicationTheme(ApplicationTheme.Light);
        }

        private void Dark_Checked(object sender, RoutedEventArgs e)
        {
            SetApplicationTheme(ApplicationTheme.Dark);
        }
        private void SizingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem menuItem)
            {
                bool compact = menuItem.Tag as string == "Compact";

                var xcr = Application.Current.Resources.MergedDictionaries.OfType<XamlControlsResources>().FirstOrDefault();
                if (xcr != null)
                {
                    xcr.UseCompactResources = compact;
                }
            }
        }

        private void ShadowsAuto_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.Remove(SystemParameters.DropShadowKey);
        }

        private void ShadowsEnabled_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[SystemParameters.DropShadowKey] = true;
        }

        private void ShadowsDisabled_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[SystemParameters.DropShadowKey] = false;
        }

        private void AutoHideScrollBarsAuto_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.Remove(AutoHideScrollBarsKey);
        }

        private void AutoHideScrollBarsOn_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[AutoHideScrollBarsKey] = true;
        }

        private void AutoHideScrollBarsOff_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[AutoHideScrollBarsKey] = false;
        }

        private void NewWindow(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(() =>
            {
                var window = new MainWindow();
                window.Closed += delegate
                {
                    Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
                };
                window.Show();
                Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        private void OnThemeButtonClick(object sender, RoutedEventArgs e)
        {
            DispatcherHelper.RunOnMainThread(() =>
            {
                if (ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark)
                {
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
                }
                else
                {
                    ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
                }
            });
        }

        private void SetApplicationTheme(ApplicationTheme? theme)
        {
            DispatcherHelper.RunOnMainThread(() =>
            {
                ThemeManager.Current.ApplicationTheme = theme;
            });
        }


        private void ForceGC(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}