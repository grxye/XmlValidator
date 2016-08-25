using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.Factories.Interfaces
{
    public interface IValidatorViewModelFactory
    {
        IValidatorViewModel CreateValidatorViewModel(ITabViewModelManager tabViewModelManager);
    }
}
