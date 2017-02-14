using System;
using System.IO;
using System.Text;

namespace MixERP.Net.VCards.Helpers
{
    internal static class FileHelper
    {
        internal static string[] ReadVCardString(string path)
        {
            if (!File.Exists(path))
            {
                return new string[] { };
            }

            using (var sr = File.OpenText(path))
            {
                var builder = new StringBuilder();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    builder.Append(line);
                    builder.Append(Environment.NewLine);
                }

                string contents = builder.ToString();

                contents = contents.Replace("BEGIN:VCARD", "");
                return contents.Split(new[] { "END:VCARD" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}