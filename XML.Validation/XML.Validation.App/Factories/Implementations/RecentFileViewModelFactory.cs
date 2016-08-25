using XML.Validation.App.Factories.Interfaces;
using XML.Validation.App.ViewModels.Implementations;
using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.Factories.Implementations
{
    public sealed class RecentFileViewModelFactory : IRecentFileViewModelFactory
    {
        public IRecentFileViewModel CreateRecentFileViewModel(string location, IRecentFilesManager manager)
        {
            return new RecentFileViewModel(location, manager);
        }
    }
}
