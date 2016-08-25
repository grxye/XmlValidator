using System;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Xml.Schema;
using XML.Validation.Service.Factories.Interfaces;
using XML.Validation.Service.Models.Interfaces;
using XML.Validation.Service.Processing.Interfaces;

namespace XML.Validation.Service.Processing.Implementations
{
    public sealed class PmmlValidator : IPmmlValidator
    {
        private readonly IValidationOutputFactory _validationOutputFactory;
        private readonly IErrorMessageFactory _errorMessageFactory;

        public PmmlValidator(IValidationOutputFactory validationOutputFactory, 
            IErrorMessageFactory errorMessageFactory)
        {
            _validationOutputFactory = validationOutputFactory;
            _errorMessageFactory = errorMessageFactory;
        }

        public IValidationOutput Validate(string pmmlLocation, string xsdLocation)
        {
            var validationOutput = _validationOutputFactory.CreateValidationOutput();
            var stopWatch = new Stopwatch();

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("http://www.dmg.org/PMML-4_2", xsdLocation);

            stopWatch.Start();
            XDocument xDoc = XDocument.Load(pmmlLocation, LoadOptions.SetLineInfo);
            stopWatch.Stop();
            TimeSpan loadTime = stopWatch.Elapsed;

            stopWatch.Restart();
            xDoc.Validate(schemas, (o, e) =>
            {
                validationOutput.AddErrorMessage(_errorMessageFactory.CreatErrorMessage(e));
            });
            stopWatch.Stop();
            TimeSpan validateTime = stopWatch.Elapsed;

            var fileSize = new FileInfo(pmmlLocation).Length.TranslateFileSize();
            validationOutput.AddOutputMessage($"Size of file: {fileSize}");
            validationOutput.AddOutputMessage($"Time to load file: {loadTime}");
            validationOutput.AddOutputMessage($"Time to validate file: {validateTime}");
            validationOutput.AddOutputMessage($"Number of errors: {validationOutput.ErrorMessages.Count}");

            return validationOutput;
        }
    }
}
