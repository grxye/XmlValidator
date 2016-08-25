using System.Windows;

namespace XML.Validation.App.Services.Interfaces
{
    public interface IMessageBoxService
    {
        void ShowMessageBox(string messageBoxText, string caption, MessageBoxButton button,
            MessageBoxImage icon);

    }
}
