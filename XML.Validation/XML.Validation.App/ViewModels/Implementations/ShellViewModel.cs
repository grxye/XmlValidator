using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.ViewModels.Implementations
{
    public sealed class ShellViewModel : IShellViewModel
    {
        private readonly ITabViewModelManager _tabViewModelManager;
        private readonly IRecentFilesManager _recentFiles;

        public ShellViewModel(ITabViewModelManager tabViewModelManager, IRecentFilesManager recentFiles)
        {
            _tabViewModelManager = tabViewModelManager;
            _recentFiles = recentFiles;
            _recentFiles.Initialize(tabViewModelManager);
        }

        public ITabViewModelManager TabViewModelManager { get { return _tabViewModelManager; } }
        public IRecentFilesManager RecentFilesViewModel { get { return _recentFiles; } }
    }
}
