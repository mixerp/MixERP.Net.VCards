using System;
using System.IO;
using System.Text;

namespace MixERP.Net.VCards.Helpers
{
    public static class FileHelper
    {
        public static string[] ReadVCardString(string path)
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
                return VCardHelper.SplitCards(contents);
            }
        }
    }
}