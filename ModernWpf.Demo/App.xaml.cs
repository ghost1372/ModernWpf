using System.Windows;

namespace ModernWpf.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var boot = new Bootstrapper();
            boot.Run();
        }
    }
}
