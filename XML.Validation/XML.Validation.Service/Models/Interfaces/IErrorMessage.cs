using System.Xml.Schema;

namespace XML.Validation.Service.Models.Interfaces
{
    public interface IErrorMessage
    {
        XmlSeverityType Severity { get; }
        string Message { get; }
        XmlSchemaException Exception { get; }
        string LineNumber { get; }
    }
}
