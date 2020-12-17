using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for MenuFlyoutPage.xaml
    /// </summary>
    public partial class MenuFlyoutPage : UserControl
    {
        public MenuFlyoutPage()
        {
            InitializeComponent();
        }
        private void MenuFlyoutItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MenuItem selectedItem = sender as MenuItem;

            if (selectedItem != null)
            {
                string sortOption = selectedItem.Tag.ToString();
                switch (sortOption)
                {
                    case "rating":
                        //SortByRating();
                        break;
                    case "match":
                        //SortByMatch();
                        break;
                    case "distance":
                        //SortByDistance();
                        break;
                }
                Control1Output.Text = "Sort by: " + sortOption;
            }
        }
    }
}
