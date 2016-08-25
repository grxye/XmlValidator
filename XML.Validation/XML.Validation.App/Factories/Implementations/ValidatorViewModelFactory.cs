using XML.Validation.App.Factories.Interfaces;
using XML.Validation.App.Services.Interfaces;
using XML.Validation.App.ViewModels.Implementations;
using XML.Validation.App.ViewModels.Interfaces;
using XML.Validation.Service.Processing.Interfaces;

namespace XML.Validation.App.Factories.Implementations
{
    internal sealed class ValidatorViewModelFactory : IValidatorViewModelFactory
    {
        private readonly IRecentFilesManager _recentFiles;
        private readonly IPmmlValidator _pmmlValidator;
        private readonly IOpenFileDialogService _openFileDialogService;
        private readonly IGetFileNameService _getFileNameService;

        public ValidatorViewModelFactory(
            IRecentFilesManager recentFiles,
            IPmmlValidator pmmlValidator,
            IOpenFileDialogService openFileDialogService,
            IGetFileNameService getFileNameService)
        {
            _recentFiles = recentFiles;
            _pmmlValidator = pmmlValidator;
            _openFileDialogService = openFileDialogService;
            _getFileNameService = getFileNameService;
        }

        public IValidatorViewModel CreateValidatorViewModel(ITabViewModelManager tabViewModelManager)
        {
            return new ValidatorViewModel(tabViewModelManager, _recentFiles, _pmmlValidator,
                _openFileDialogService, _getFileNameService);
        }
    }
}
