using System.Diagnostics.CodeAnalysis;
using Microsoft.Win32;
using XML.Validation.App.Services.Interfaces;

namespace XML.Validation.App.Services.Implementations
{
    [ExcludeFromCodeCoverage]
    public class OpenFileDialogService : IOpenFileDialogService
    {
        public string OpenBrowseFileDialog()
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".xml",
                Filter = "PMML/XML documents (.xml)|*.xml"
            };

            return dialog.ShowDialog() == true ? dialog.FileName : null;
        }
    }
}
