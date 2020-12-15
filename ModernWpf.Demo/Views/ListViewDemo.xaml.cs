using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    ///     Interaction logic for ListView.xaml
    /// </summary>
    public partial class ListViewDemo : UserControl
    {
        public ListViewDemo()
        {
            InitializeComponent();
            Loaded += ListViewDemo_Loaded;
        }

        private async void ListViewDemo_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = await Contact.GetContactsAsync();
        }

        public class Contact : INotifyPropertyChanged
        {
            public Contact(string firstName, string lastName, string company)
            {
                FirstName = firstName;
                LastName = lastName;
                Company = company;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            #region Properties

            public string FirstName { get; }
            public string LastName { get; }
            public string Company { get; private set; }
            public string Name => FirstName + " " + LastName;

            #endregion

            #region Public Methods

            public static Task<ObservableCollection<Contact>> GetContactsAsync()
            {
                IList<string> lines = new List<string>();
                var resourceStream = Application.GetResourceStream(new Uri("/Assets/Contacts.txt", UriKind.Relative));
                using (var reader = new StreamReader(resourceStream.Stream))
                {
                    while (!reader.EndOfStream) lines.Add(reader.ReadLine());
                }

                var contacts = new ObservableCollection<Contact>();

                for (var i = 0; i < lines.Count; i += 3)
                    contacts.Add(new Contact(lines[i], lines[i + 1], lines[i + 2]));

                return Task.FromResult(contacts);
            }

            public static async Task<ObservableCollection<GroupInfoList>> GetContactsGroupedAsync()
            {
                var query = from item in await GetContactsAsync()
                    group item by item.LastName.Substring(0, 1).ToUpper()
                    into g
                    orderby g.Key
                    select new GroupInfoList(g) {Key = g.Key};

                return new ObservableCollection<GroupInfoList>(query);
            }

            public override string ToString()
            {
                return Name;
            }

            public void ChangeCompany(string company)
            {
                Company = company;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Company)));
            }

            #endregion
        }

        public class GroupInfoList : List<object>
        {
            public GroupInfoList(IEnumerable<object> items) : base(items)
            {
            }

            public object Key { get; set; }
        }
    }
}