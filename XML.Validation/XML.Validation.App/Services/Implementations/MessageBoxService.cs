using System.Windows;
using XML.Validation.App.Services.Interfaces;

namespace XML.Validation.App.Services.Implementations
{
    internal sealed class MessageBoxService : IMessageBoxService
    {
        public void ShowMessageBox(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            MessageBox.Show(messageBoxText, caption, button, icon);
        }
    }
}
