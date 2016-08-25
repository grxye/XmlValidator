using System.Xml.Schema;
using XML.Validation.Service.Models.Interfaces;

namespace XML.Validation.Service.Models.Implementations
{
    public sealed class ErrorMessage : IErrorMessage
    {
        public ErrorMessage(XmlSeverityType severity, string message, 
            XmlSchemaException exception, int lineNumber)
        {
            Severity = severity;
            Message = message;
            Exception = exception;
            LineNumber = lineNumber.ToString("N0");
        }

        public XmlSeverityType Severity { get; }
        public string Message { get; }
        public XmlSchemaException Exception { get; }
        public string LineNumber { get; }
    }
}
