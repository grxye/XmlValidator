using System.Collections.Generic;
using System.Xml.Schema;
using XML.Validation.Service.Factories.Interfaces;
using XML.Validation.Service.Models.Interfaces;

namespace XML.Validation.Service.Models.Implementations
{
    public sealed class ValidationOutput : IValidationOutput
    {
        private readonly List<IErrorMessage> _errorMessages;
        private readonly List<string> _outputWindowMessages;

        public ValidationOutput()
        {
            _errorMessages = new List<IErrorMessage>();
            _outputWindowMessages = new List<string>();
        }

        public IReadOnlyCollection<IErrorMessage> ErrorMessages => _errorMessages;

        public IReadOnlyCollection<string> OutputWindowMessages => _outputWindowMessages;

        public void AddErrorMessage(IErrorMessage e)
        {
            _errorMessages.Add(e);
        }

        public void AddOutputMessage(string message)
        {
            _outputWindowMessages.Add(message);
        }

    }
}
