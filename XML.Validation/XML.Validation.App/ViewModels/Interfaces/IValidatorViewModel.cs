using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using XML.Validation.Service.Models.Interfaces;

namespace XML.Validation.App.ViewModels.Interfaces
{
    public interface IValidatorViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        string FilePath { get; set; }

        ICommand BrowseFileCommand { get; }

        ICommand ValidateCommand { get; }

        IReadOnlyCollection<string> CanEditLocation(string newLocation);

        ReadOnlyObservableCollection<IErrorMessage> ErrorMessages { get; }

        ReadOnlyObservableCollection<string> OutputWindowMessages { get; }
    }
}
