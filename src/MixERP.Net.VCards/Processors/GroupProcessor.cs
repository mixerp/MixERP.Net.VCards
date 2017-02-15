using System.Linq;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class GroupProcessor
    {
        public static string Serialize(string key, VCardVersion version, string type, bool mustEscape = false, params string[] members)
        {
            string value = string.Join(";", members.Select(x => mustEscape ? x.Escape() : x));
            return DefaultSerializer.GetVCardString(key, value, false, version, type);
        }
    }
}