using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace XML.Validation.App.ViewModels.Interfaces
{
    public interface ITabViewModelManager : INotifyPropertyChanged
    {
        ReadOnlyObservableCollection<ITabViewModel> Tabs { get; }
        int Count { get; }
        ITabViewModel ActiveTabViewModel { get; set; }
        ICommand CreateNewTabCommand { get; }
        bool CloseTab(ITabViewModel tabViewModel);
        void CreateNewTabForRecentFile(string fileLocation);
    }
}
