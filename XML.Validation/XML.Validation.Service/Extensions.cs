using System;

namespace XML.Validation.Service
{
    public static class Extensions
    {
        public static string TranslateFileSize(this long bytes)
        {
            if (bytes >= 1024)
            {
                var result = Math.Round(bytes/1024d, 2, MidpointRounding.AwayFromZero);
                if (result < 1024)
                {
                    return $"{result} KB";
                }
                result = Math.Round(result/1024d, 2, MidpointRounding.AwayFromZero);
                return $"{result} MB";
            }

            return $"{bytes} B";
        }
    }
}
