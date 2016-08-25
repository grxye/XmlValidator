using System.ComponentModel;
using System.Windows.Input;

namespace XML.Validation.App.ViewModels.Interfaces
{
    public interface ITabViewModel : INotifyPropertyChanged
    {
        string Name { get; set; }
        IValidatorViewModel Content { get; }
        ICommand CloseTabCommand { get; }
    }
}
