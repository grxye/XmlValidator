using System.Xml.Schema;
using XML.Validation.Service.Models.Interfaces;

namespace XML.Validation.Service.Factories.Interfaces
{
    public interface IErrorMessageFactory
    {
        IErrorMessage CreatErrorMessage(ValidationEventArgs e);
    }
}
