using System;
using System.Linq;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Serializer
{
    internal static class DefaultSerializer
    {
        internal static string GetVCardString(string key, string value, bool mustEscape, VCardVersion version, string type = "", string encoding = "")
        {
            string[] types = {type};
            return GetVCardString(key, value, mustEscape, version, types, encoding);
        }

        internal static string GetVCardString(string key, string value, bool mustEscape, VCardVersion version, string[] types, string encoding = "")
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return string.Empty;
            }

            if (mustEscape)
            {
                value = value.Escape();
            }

            //Legal values for v3
            //"TYPE=dom;TYPE=postal"
            //or
            //"TYPE=dom,postal"
            string type = "TYPE=" + string.Join(",", types);

            if (version == VCardVersion.V2_1)
            {
                type = string.Join(";", types);
            }

            string line = key;


            if (types.Any(x => !string.IsNullOrWhiteSpace(x)))
            {
                line = line + ";" + type;
            }

            if (!string.IsNullOrWhiteSpace(encoding))
            {
                line = line + $";ENCODING={encoding}";
            }

            line = line + ":" + value + Environment.NewLine;
            return line;
        }
    }
}