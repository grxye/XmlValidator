using MahApps.Metro.Controls;
using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = AppContainer.Container.GetInstance<IShellViewModel>();
        }
    }
}
