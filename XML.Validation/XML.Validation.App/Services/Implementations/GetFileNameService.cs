using System.Diagnostics.CodeAnalysis;
using System.IO;
using XML.Validation.App.Services.Interfaces;

namespace XML.Validation.App.Services.Implementations
{
    [ExcludeFromCodeCoverage]
    public class GetFileNameService : IGetFileNameService
    {
        public string GetFileNameWithoutExtension(string fileLocation)
        {
            return Path.GetFileNameWithoutExtension(fileLocation);
        }
    }
}
