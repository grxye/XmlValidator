using XML.Validation.Service.Factories.Interfaces;
using XML.Validation.Service.Models.Implementations;
using XML.Validation.Service.Models.Interfaces;

namespace XML.Validation.Service.Factories.Implementations
{
    public sealed class ValidationOutputFactory : IValidationOutputFactory
    {
        public IValidationOutput CreateValidationOutput()
        {
            return new ValidationOutput();
        }
    }
}
