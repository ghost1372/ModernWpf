using ModernWpf.Controls;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for AutoSuggestBoxPage.xaml
    /// </summary>
    public partial class AutoSuggestBoxPage : UserControl
    {
        public AutoSuggestBoxPage()
        {
            InitializeComponent();
        }
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            Debug.WriteLine("TextChanged: " + args.Reason);
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> suggestions = new List<string>()
                {
                    sender.Text + "1",
                    sender.Text + "2"
                };
                Control1.ItemsSource = suggestions;
            }
        }

        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            Debug.WriteLine("SuggestionChosen");
            SuggestionOutput.Text = args.SelectedItem.ToString();
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            Debug.WriteLine("QuerySubmitted: " + args.QueryText);
        }
    }
}
