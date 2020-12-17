using System.Windows;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : UserControl
    {
        public CalendarPage()
        {
            InitializeComponent();
        }
        private void AddDatesInPastToBlackoutDates(object sender, RoutedEventArgs e)
        {
            calendar.BlackoutDates.AddDatesInPast();
        }
    }
}
