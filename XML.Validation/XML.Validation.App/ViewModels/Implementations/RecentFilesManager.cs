using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using XML.Validation.App.Factories.Interfaces;
using XML.Validation.App.Services.Interfaces;
using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.ViewModels.Implementations
{
    public sealed class RecentFilesManager : IRecentFilesManager
    {
        private readonly IRecentFileViewModelFactory _recentFileViewModelFactory;
        private ITabViewModelManager _tabViewModelManager;
        private readonly IMessageBoxService _messageBoxService;
        private readonly ObservableCollection<IRecentFileViewModel> _recentFiles;
        private readonly StringCollection _recentFilesInSettings;

        public RecentFilesManager(IRecentFileViewModelFactory recentFileViewModelFactory,
            IMessageBoxService messageBoxService)
        {
            _recentFileViewModelFactory = recentFileViewModelFactory;
            _messageBoxService = messageBoxService;
            _recentFiles = new ObservableCollection<IRecentFileViewModel>();
            RecentFiles = new ReadOnlyObservableCollection<IRecentFileViewModel>(_recentFiles);
            _recentFilesInSettings = Properties.Settings.Default.RecentFiles;
        }

        public void Initialize(ITabViewModelManager manager)
        {
            _tabViewModelManager = manager;
            GetExistingRecentFiles();
        }

        public ReadOnlyObservableCollection<IRecentFileViewModel> RecentFiles { get; }

        private void GetExistingRecentFiles()
        {
            foreach(var file in _recentFilesInSettings)
            {
                _recentFiles.Add(_recentFileViewModelFactory.CreateRecentFileViewModel(file, this));
            }
        }

        public void AddRecentFile(string location)
        {
            if (!_recentFilesInSettings.Contains(location))
            {
                if (_recentFilesInSettings.Count == 10)
                {
                    _recentFilesInSettings.RemoveAt(9);
                    _recentFiles.RemoveAt(9);
                }
                _recentFiles.Insert(0, _recentFileViewModelFactory.CreateRecentFileViewModel(location, this));

                _recentFilesInSettings.Insert(0, location);
                Properties.Settings.Default.Save();
            }
            else
            {
                _recentFiles.Move(GetIndex(location), 0);
            }           
        }

        public void OpenRecentFile(string location)
        {
            if (!File.Exists(location))
            {
                _recentFiles.RemoveAt(GetIndex(location));
                _recentFilesInSettings.Remove(location);
                _messageBoxService.ShowMessageBox("File does not exist.", "PMML Validator",
                    System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
                return;
            }

            _tabViewModelManager.CreateNewTabForRecentFile(location);
        }

        private int GetIndex(string searchKey)
        {
            int index = 0;
            foreach (var file in _recentFiles)
            {
                if (file.Location == searchKey)
                {
                    return index;
                }
                index++;
            }

            return -1;
        }
    }
}
