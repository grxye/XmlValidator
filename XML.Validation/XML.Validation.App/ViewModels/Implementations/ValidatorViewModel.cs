using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using XML.Validation.App.MVVM;
using XML.Validation.App.Services.Interfaces;
using XML.Validation.App.ViewModels.Interfaces;
using XML.Validation.Service.Models.Interfaces;
using XML.Validation.Service.Processing.Interfaces;

namespace XML.Validation.App.ViewModels.Implementations
{
    /// <summary>
    /// ValidatorViewModel Class that calls the different service classes and store the results
    /// so that they can be binded to the UI.
    /// </summary>
    public sealed class ValidatorViewModel : NotifyDataErrorInfoBase, IValidatorViewModel
    {
        private readonly ITabViewModelManager _tabViewModelManager;
        private readonly IPmmlValidator _pmmlValidator;
        private readonly IOpenFileDialogService _openFileDialogService;
        private readonly IGetFileNameService _getFileNameService;
        private readonly IRecentFilesManager _recentFiles;

        private string _filePath;
        private bool _isBusy;
        private readonly ObservableCollection<IErrorMessage> _errorMessages;
        private readonly ObservableCollection<string> _outputWindowMessages;

        public ValidatorViewModel(ITabViewModelManager tabViewModelManager,
            IRecentFilesManager recentFiles,
            IPmmlValidator pmmlValidator,
            IOpenFileDialogService openFileDialogService,
            IGetFileNameService getFileNameService)
        {
            _tabViewModelManager = tabViewModelManager;
            _pmmlValidator = pmmlValidator;
            _openFileDialogService = openFileDialogService;
            _getFileNameService = getFileNameService;
            _recentFiles = recentFiles;            

            BrowseFileCommand = new SimpleDelegateCommand(BrowseFile);
            ValidateCommand = new SimpleDelegateCommand(ValidateFile, CanValidate);

            _errorMessages = new ObservableCollection<IErrorMessage>();
            ErrorMessages = new ReadOnlyObservableCollection<IErrorMessage>(_errorMessages);

            _outputWindowMessages = new ObservableCollection<string>();
            OutputWindowMessages = new ReadOnlyObservableCollection<string>(_outputWindowMessages);
        }

        public string FilePath
        {
            get { return _filePath; }
            set { SetValue(ref _filePath, value, CanEditLocation); }
        }

        public IReadOnlyCollection<string> CanEditLocation(string newLocation)
        {
            var messages = new List<string>();
            if (!File.Exists(newLocation))
                messages.Add("File does not exist");
            return messages;
        }

        /// <summary>
        /// Command and private method for the Browse File Button.
        /// </summary>
        public ICommand BrowseFileCommand { get; }

        private void BrowseFile()
        {
            var openFileResult = _openFileDialogService.OpenBrowseFileDialog();
            if (openFileResult != null)
            {
                FilePath = openFileResult;
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetValue(ref _isBusy, value); }
        }

        /// <summary>
        /// Command and private method for the Validate Button.
        /// Calls the Validator and prints the error messages to UI.
        /// </summary>
        public ICommand ValidateCommand { get; }

        private async void ValidateFile()
        {
            _tabViewModelManager.ActiveTabViewModel.Name = _getFileNameService.GetFileNameWithoutExtension(_filePath);

            _recentFiles.AddRecentFile(_filePath);

            _errorMessages.Clear();
            _outputWindowMessages.Clear();

            IsBusy = true;
            var startNew = Task.Factory.StartNew(ValidateTask);
            var validationOutput = await startNew;

            foreach (var errorMessage in validationOutput.ErrorMessages)
            {
                _errorMessages.Add(errorMessage);
            }

            foreach (var outputWindowMessage in validationOutput.OutputWindowMessages)
            {
                _outputWindowMessages.Add(outputWindowMessage);
            }

            RaisePropertyChanged(nameof(ErrorMessages));
            RaisePropertyChanged(nameof(OutputWindowMessages));
            IsBusy = false;
        }

        private IValidationOutput ValidateTask()
        {
            return _pmmlValidator.Validate(_filePath,
                $"{AppDomain.CurrentDomain.BaseDirectory}\\pmml-4-2.xsd");
        }

        private bool CanValidate()
        {
            return !HasErrors && !string.IsNullOrEmpty(_filePath);
        }

        public ReadOnlyObservableCollection<IErrorMessage> ErrorMessages { get; }
        public ReadOnlyObservableCollection<string> OutputWindowMessages { get; }
    }
}
