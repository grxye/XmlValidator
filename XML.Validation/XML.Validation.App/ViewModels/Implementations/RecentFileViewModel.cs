using System.Windows.Input;
using XML.Validation.App.MVVM;
using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.ViewModels.Implementations
{
    public sealed class RecentFileViewModel : IRecentFileViewModel
    {
        private readonly IRecentFilesManager _recentFilesManager;
        private string _location;

        public RecentFileViewModel(string location, IRecentFilesManager recentFilesManager)
        {
            _recentFilesManager = recentFilesManager;
            LoadRecentFileCommand = new SimpleDelegateCommand(LoadRecentFile);
            _location = location;
        }

        public string Location => _location;

        public ICommand LoadRecentFileCommand { get; }

        private void LoadRecentFile()
        {
            _recentFilesManager.OpenRecentFile(_location);
        }
    }
}
