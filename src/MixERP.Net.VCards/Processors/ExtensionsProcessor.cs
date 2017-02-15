using System.Text;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using System.Collections.Generic;
using System.Linq;

namespace MixERP.Net.VCards.Processors
{
    internal static class ExtensionsProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            var builder = new StringBuilder();

            if (vcard.CustomExtensions == null)
            {
                return builder.ToString();
            }

            foreach (var extension in vcard.CustomExtensions)
            {
                var key = extension.Key;
                foreach (var value in extension.Values)
                {
                    var vcardString = DefaultSerializer.GetVCardString(key, value, true, vcard.Version);
                    builder.Append(vcardString);
                }
            }

            return builder.ToString();
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            var key = token.Key;
            var extensions = (List<CustomExtension>)vcard.CustomExtensions ?? new List<CustomExtension>();

            var entry = extensions.FirstOrDefault(x => x.Key.Equals(key, System.StringComparison.OrdinalIgnoreCase));

            if (entry != null)
            {
                entry.Values = entry.Values.Union(token.Values);
            }
            else
            {
                extensions.Add(new CustomExtension
                {
                    Key = token.Key,
                    Values = token.Values
                });
            }

            vcard.CustomExtensions = extensions;
        }
    }
}