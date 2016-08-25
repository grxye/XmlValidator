using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.Factories.Interfaces
{
    public interface ITabViewModelFactory
    {
        ITabViewModel CreateTabViewModel(ITabViewModelManager tabViewModelManager);
    }
}
