using XML.Validation.App.Factories.Interfaces;
using XML.Validation.App.ViewModels.Implementations;
using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.Factories.Implementations
{
    public sealed class TabViewModelFactory : ITabViewModelFactory
    {
        private readonly IValidatorViewModelFactory _validatorViewModelFactory;

        public TabViewModelFactory(IValidatorViewModelFactory validatorViewModelFactory)
        {
            _validatorViewModelFactory = validatorViewModelFactory;
        }

        public ITabViewModel CreateTabViewModel(ITabViewModelManager tabViewModelManager)
        {
            return new TabViewModel(tabViewModelManager, _validatorViewModelFactory);
        }
    }
}
