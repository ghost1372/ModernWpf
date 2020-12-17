using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    ///     Interaction logic for RepeaterDemo.xaml
    /// </summary>
    public partial class ItemsRepeaterPage : UserControl
    {
        private readonly StackLayout HorizontalStackLayout;
        private readonly int MaxLength = 425;
        private readonly Random random = new Random();
        private readonly UniformGridLayout UniformGridLayout;

        private readonly StackLayout VerticalStackLayout;

        public ObservableCollection<Bar> BarItems;
        private bool isHorizontal;

        public ItemsRepeaterPage()
        {
            InitializeComponent();
            VerticalStackLayout = (StackLayout)Resources[nameof(VerticalStackLayout)];
            HorizontalStackLayout = (StackLayout)Resources[nameof(HorizontalStackLayout)];
            UniformGridLayout = (UniformGridLayout)Resources[nameof(UniformGridLayout)];

            InitializeData();
            repeater2.ItemsSource = Enumerable.Range(0, 500);
            repeater.ItemsSource = BarItems;
        }

        ~ItemsRepeaterPage()
        {
        }

        private void InitializeData()
        {
            if (BarItems == null)
            {
                BarItems = new ObservableCollection<Bar>();
            }

            BarItems.Add(new Bar(300, MaxLength));
            BarItems.Add(new Bar(25, MaxLength));
            BarItems.Add(new Bar(175, MaxLength));

            var basicData = new List<object>();
            basicData.Add(64);
            basicData.Add(
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
            basicData.Add(128);
            basicData.Add(
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.");
            basicData.Add(256);
            basicData.Add(
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.");
            basicData.Add(512);
            basicData.Add(
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            basicData.Add(1024);
            MixedTypeRepeater.ItemsSource = basicData;

            var nestedCategories = new List<NestedCategory>();
            nestedCategories.Add(
                new NestedCategory("Fruits", new ObservableCollection<string>
                {
                    "Apricots",
                    "Bananas",
                    "Grapes",
                    "Strawberries",
                    "Watermelon",
                    "Plums",
                    "Blueberries"
                }));

            nestedCategories.Add(
                new NestedCategory("Vegetables", new ObservableCollection<string>
                {
                    "Broccoli",
                    "Spinach",
                    "Sweet potato",
                    "Cauliflower",
                    "Onion",
                    "Brussel sprouts",
                    "Carrots"
                }));

            nestedCategories.Add(
                new NestedCategory("Grains", new ObservableCollection<string>
                {
                    "Rice",
                    "Quinoa",
                    "Pasta",
                    "Bread",
                    "Farro",
                    "Oats",
                    "Barley"
                }));

            nestedCategories.Add(
                new NestedCategory("Proteins", new ObservableCollection<string>
                {
                    "Steak",
                    "Chicken",
                    "Tofu",
                    "Salmon",
                    "Pork",
                    "Chickpeas",
                    "Eggs"
                }));

            outerRepeater.ItemsSource = nestedCategories;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            BarItems.Add(new Bar(random.Next(MaxLength), MaxLength));
            DeleteBtn.IsEnabled = true;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BarItems.Count > 0)
            {
                BarItems.RemoveAt(0);
                if (BarItems.Count == 0)
                {
                    DeleteBtn.IsEnabled = false;
                }
            }
        }

        private void OrientationBtn_Click(object sender, RoutedEventArgs e)
        {
            string layoutKey = string.Empty, itemTemplateKey = string.Empty;

            if (isHorizontal)
            {
                layoutKey = "VerticalStackLayout";
                itemTemplateKey = "HorizontalBarTemplate";
            }
            else
            {
                layoutKey = "HorizontalStackLayout";
                itemTemplateKey = "VerticalBarTemplate";
            }

            repeater.Layout = Resources[layoutKey] as VirtualizingLayout;
            repeater.ItemTemplate = Resources[itemTemplateKey] as DataTemplate;
            repeater.ItemsSource = BarItems;

            isHorizontal = !isHorizontal;
        }

        private void LayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var layoutKey = ((FrameworkElement)sender).Tag as string;

            repeater2.Layout = Resources[layoutKey] as VirtualizingLayout;
        }

        private void RadioBtn_Click(object sender, RoutedEventArgs e)
        {
            var itemTemplateKey = string.Empty;
            var layoutKey = ((FrameworkElement)sender).Tag as string;

            if (layoutKey.Equals(nameof(VerticalStackLayout))
            ) // we used x:Name in the resources which both acts as the x:Key value and creates a member field by the same name
            {
                itemTemplateKey = "HorizontalBarTemplate";

                repeater.MaxWidth = MaxLength + 12;
            }
            else if (layoutKey.Equals(nameof(HorizontalStackLayout)))
            {
                itemTemplateKey = "VerticalBarTemplate";

                repeater.MaxWidth = 6000;
            }
            else if (layoutKey.Equals(nameof(UniformGridLayout)))
            {
                itemTemplateKey = "CircularTemplate";

                repeater.MaxWidth = 540;
            }

            repeater.Layout = Resources[layoutKey] as VirtualizingLayout;
            repeater.ItemTemplate = Resources[itemTemplateKey] as DataTemplate;
            repeater.ItemsSource = BarItems;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = await ListViewPage.Contact.GetContactsAsync();
        }

        private void ChangeFirstItemButton_Click(object sender, RoutedEventArgs e)
        {
            var contacts = (ObservableCollection<ListViewPage.Contact>)DataContext;
            contacts[0] = new ListViewPage.Contact("First", "Last", "Line 1\nLine 2");
        }

        private void ModifyFirstItemButton_Click(object sender, RoutedEventArgs e)
        {
            var contacts = (ObservableCollection<ListViewPage.Contact>)DataContext;
            var firstContact = contacts[0];
            if (firstContact.Company.Contains("\n"))
            {
                firstContact.ChangeCompany("Line 1");
            }
            else
            {
                firstContact.ChangeCompany("Line 1\nLine 2");
            }
        }
    }

    public class NestedCategory
    {
        public NestedCategory(string catName, ObservableCollection<string> catItems)
        {
            CategoryName = catName;
            CategoryItems = catItems;
        }

        public string CategoryName { get; set; }
        public ObservableCollection<string> CategoryItems { get; set; }
    }


    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Normal { get; set; }
        public DataTemplate Accent { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if ((int)item % 2 == 0)
            {
                return Normal;
            }

            return Accent;
        }
    }

    public class StringOrIntTemplateSelector : DataTemplateSelector
    {
        // Define the (currently empty) data templates to return
        // These will be "filled-in" in the XAML code.
        public DataTemplate StringTemplate { get; set; }

        public DataTemplate IntTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            // Return the correct data template based on the item's type.
            if (item.GetType() == typeof(string))
            {
                return StringTemplate;
            }

            if (item.GetType() == typeof(int))
            {
                return IntTemplate;
            }

            return null;
        }
    }

    public class Bar
    {
        public Bar(double length, int max)
        {
            Length = length;
            MaxLength = max;

            Height = length / 4;
            MaxHeight = max / 4;

            Diameter = length / 6;
            MaxDiameter = max / 6;
        }

        public double Length { get; set; }
        public int MaxLength { get; set; }

        public double Height { get; set; }
        public double MaxHeight { get; set; }

        public double Diameter { get; set; }
        public double MaxDiameter { get; set; }
    }

    public class SpacingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d && double.IsNaN(d))
            {
                return 0d;
            }

            return value;
        }
    }

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return new SolidColorBrush(color);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}