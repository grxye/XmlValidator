using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.Factories.Interfaces
{
    public interface IRecentFileViewModelFactory
    {
        IRecentFileViewModel CreateRecentFileViewModel(string location, IRecentFilesManager manager);
    }
}
