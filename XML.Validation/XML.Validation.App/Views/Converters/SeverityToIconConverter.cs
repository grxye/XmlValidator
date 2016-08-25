using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Xml.Schema;

namespace XML.Validation.App.Views.Converters
{
    public sealed class SeverityToIconConverter : IValueConverter
    {
        private static readonly IDictionary<XmlSeverityType, string> SeverityToStringMapper = new Dictionary<XmlSeverityType, string>
        {
            {XmlSeverityType.Error, "error.png" },
            {XmlSeverityType.Warning, "warning.png" }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return SeverityToStringMapper[(XmlSeverityType)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
