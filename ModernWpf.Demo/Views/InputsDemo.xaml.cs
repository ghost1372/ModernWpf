using System.Linq;
using System.Windows.Controls;

namespace ModernWpf.Demo.Views
{
    /// <summary>
    /// Interaction logic for Inputs.xaml
    /// </summary>
    public partial class InputsDemo : UserControl
    {
        public InputsDemo()
        {
            InitializeComponent();
            Combo2.ItemsSource = Enumerable.Range(1, 5000).ToList();
            Combo2.SelectedIndex = 0;
        }
    }
}
