using System.Collections.ObjectModel;

namespace XML.Validation.App.ViewModels.Interfaces
{
    public interface IRecentFilesManager
    {
        ReadOnlyObservableCollection<IRecentFileViewModel> RecentFiles { get; }

        void Initialize(ITabViewModelManager manager);

        void AddRecentFile(string location);

        void OpenRecentFile(string location);
    }
}
