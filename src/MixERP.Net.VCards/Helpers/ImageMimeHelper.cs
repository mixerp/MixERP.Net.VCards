using System.Collections.Generic;
using System.Linq;

namespace MixERP.Net.VCards.Helpers
{
    public static class ImageMimeHelper
    {
        public const string FallBack = "image/jpeg";

        public static readonly Dictionary<string, string> MimeTypes = new Dictionary<string, string>
        {
            {"bm", "image/bmp"},
            {"bmp", "image/bmp"},
            {"gif", "image/gif"},
            {"ico", "image/x-icon"},
            {"jpe", "image/jpeg"},
            {"jpeg", "image/jpeg"},
            {"jpg", "image/jpeg"},
            {"pic", "image/pict"},
            {"pict", "image/pict"},
            {"png", "image/png"},
            {"tiff", "image/tiff"},
            {"tif", "image/tiff"},
            {"xbm", " image/x-xbitmap"}
        };

        public static string GetMimeType(string extension)
        {
            var candidate = MimeTypes.First(x => x.Key.Equals(extension.TrimStart('.').ToLower()));
            return candidate.Value ?? FallBack;
        }
    }
}