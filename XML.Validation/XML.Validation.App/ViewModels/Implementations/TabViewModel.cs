using System.Windows.Input;
using XML.Validation.App.Factories.Interfaces;
using XML.Validation.App.MVVM;
using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.ViewModels.Implementations
{
    public class TabViewModel : PropertyChangedBase, ITabViewModel
    {
        private readonly ITabViewModelManager _tabViewModelManager;
        private string _name;

        public TabViewModel(ITabViewModelManager tabViewModelManager,
            IValidatorViewModelFactory validatorViewModelFactory)
        {
            _tabViewModelManager = tabViewModelManager;
            CloseTabCommand = new SimpleDelegateCommand(CloseTab);
            _name = $"New Tab {_tabViewModelManager.Count + 1}";
            Content = validatorViewModelFactory.CreateValidatorViewModel(tabViewModelManager);
        }

        public IValidatorViewModel Content { get; }

        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        public ICommand CloseTabCommand { get; }

        private void CloseTab()
        {
            _tabViewModelManager.CloseTab(this);
        }
    }
}
