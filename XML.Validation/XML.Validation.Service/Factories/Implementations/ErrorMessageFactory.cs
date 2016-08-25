using System.Xml.Schema;
using XML.Validation.Service.Factories.Interfaces;
using XML.Validation.Service.Models.Implementations;
using XML.Validation.Service.Models.Interfaces;

namespace XML.Validation.Service.Factories.Implementations
{
    public sealed class ErrorMessageFactory : IErrorMessageFactory
    {
        public IErrorMessage CreatErrorMessage(ValidationEventArgs e)
        {
            return new ErrorMessage(e.Severity, e.Message, e.Exception, e.Exception.LineNumber);
        }
    }
}
