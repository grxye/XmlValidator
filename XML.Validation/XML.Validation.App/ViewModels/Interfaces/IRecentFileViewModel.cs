using System.Windows.Input;

namespace XML.Validation.App.ViewModels.Interfaces
{
    public interface IRecentFileViewModel
    {
        string Location { get; }
        ICommand LoadRecentFileCommand { get; }
    }
}
