using System.Collections.Generic;

namespace XML.Validation.Service.Models.Interfaces
{
    public interface IValidationOutput
    {
        IReadOnlyCollection<IErrorMessage> ErrorMessages { get; }
        IReadOnlyCollection<string> OutputWindowMessages { get; }
        void AddErrorMessage(IErrorMessage e);
        void AddOutputMessage(string message);
    }
}
