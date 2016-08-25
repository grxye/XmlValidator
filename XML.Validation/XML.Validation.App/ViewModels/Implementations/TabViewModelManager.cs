using System.Collections.ObjectModel;
using System.Windows.Input;
using XML.Validation.App.Factories.Interfaces;
using XML.Validation.App.MVVM;
using XML.Validation.App.ViewModels.Interfaces;

namespace XML.Validation.App.ViewModels.Implementations
{
    public class TabViewModelManager : PropertyChangedBase, ITabViewModelManager
    {
        private readonly ITabViewModelFactory _tabViewModelFactory;
        private readonly ObservableCollection<ITabViewModel> _tabs;
        private ITabViewModel _activeTabViewModel;

        public TabViewModelManager(ITabViewModelFactory tabViewModelFactory)
        {
            _tabViewModelFactory = tabViewModelFactory;
            _tabs = new ObservableCollection<ITabViewModel>();
            Tabs = new ReadOnlyObservableCollection<ITabViewModel>(_tabs);

            CreateNewTab();

            CreateNewTabCommand = new SimpleDelegateCommand(CreateNewTab);
        }

        public ReadOnlyObservableCollection<ITabViewModel> Tabs { get; }

        public int Count => _tabs.Count;

        public ITabViewModel ActiveTabViewModel
        {
            get { return _activeTabViewModel; }
            set { SetValue(ref _activeTabViewModel, value); }
        }

        public ICommand CreateNewTabCommand { get; }

        private void CreateNewTab()
        {
            var newTabViewModel = _tabViewModelFactory.CreateTabViewModel(this);
            _tabs.Add(newTabViewModel);
            ActiveTabViewModel = newTabViewModel;
        }

        public bool CloseTab(ITabViewModel tabViewModel)
        {
            return _tabs.Remove(tabViewModel);
        }

        public void CreateNewTabForRecentFile(string fileLocation)
        {
            CreateNewTabCommand.Execute(null);
            var activeTabViewModel = ActiveTabViewModel.Content;
            activeTabViewModel.FilePath = fileLocation;
            activeTabViewModel.ValidateCommand.Execute(null);
        }

    }

}
