using System.Collections.Generic;
using XML.Validation.Service.Models.Interfaces;

namespace XML.Validation.Service.Processing.Interfaces
{
    public interface IPmmlValidator
    {
        IValidationOutput Validate(string pmmlLocation, string xsdLocation);
    }
}
