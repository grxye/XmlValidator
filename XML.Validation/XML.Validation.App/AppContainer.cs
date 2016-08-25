using SimpleInjector;
using XML.Validation.App.Factories.Implementations;
using XML.Validation.App.Factories.Interfaces;
using XML.Validation.App.Services.Implementations;
using XML.Validation.App.Services.Interfaces;
using XML.Validation.App.ViewModels.Implementations;
using XML.Validation.App.ViewModels.Interfaces;
using XML.Validation.Service.Factories.Implementations;
using XML.Validation.Service.Factories.Interfaces;
using XML.Validation.Service.Processing.Implementations;
using XML.Validation.Service.Processing.Interfaces;
using Container = SimpleInjector.Container;

namespace XML.Validation.App
{
    public sealed class AppContainer
    {
        private static Container _container;

        public static Container Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new Container();
                    Build(_container);
                }
                return _container;
            }
        }

        private static void Build(Container container)
        {
            container.Register<IPmmlValidator, PmmlValidator>(Lifestyle.Singleton);
            container.Register<IOpenFileDialogService, OpenFileDialogService>(Lifestyle.Singleton);
            container.Register<IGetFileNameService, GetFileNameService>(Lifestyle.Singleton);
            container.Register<IValidatorViewModelFactory, ValidatorViewModelFactory>(Lifestyle.Singleton);
            container.Register<ITabViewModelFactory, TabViewModelFactory>(Lifestyle.Singleton);

            container.Register<ITabViewModelManager, TabViewModelManager>(Lifestyle.Singleton);
            container.Register<IRecentFileViewModelFactory, RecentFileViewModelFactory>(Lifestyle.Singleton);

            container.Register<IMessageBoxService, MessageBoxService>(Lifestyle.Singleton);
            container.Register<IRecentFilesManager, RecentFilesManager>(Lifestyle.Singleton);

            container.Register<IShellViewModel, ShellViewModel>(Lifestyle.Singleton);

            container.Register<IErrorMessageFactory, ErrorMessageFactory>(Lifestyle.Singleton);
            container.Register<IValidationOutputFactory, ValidationOutputFactory>(Lifestyle.Singleton);
           
            container.Verify();
        }
    }
}
