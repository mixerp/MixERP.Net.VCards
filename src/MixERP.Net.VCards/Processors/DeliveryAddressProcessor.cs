using System.Linq;
using System.Text;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Lookups;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    internal static class DeliveryAddressProcessor
    {
        internal static string SerializeDeliveryAddress(this DeliveryAddress value, VCardVersion version)
        {
            if (value == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            string type = value.Type.ToVCardString();

            const string key = "LABEL";

            builder.Append(GroupProcessor.Serialize(key, version, type, true, value.Address.Escape()));

            return builder.ToString();
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            var deliveryAddress = new DeliveryAddress();

            if (vcard.Version == VCardVersion.V4)
            {
                string address = token.Values[0];
                string type = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "TYPE").Value;

                deliveryAddress.Address = address;
                deliveryAddress.Type = AddressTypeLookup.Parse(type);
            }

            vcard.DeliveryAddress = deliveryAddress;
        }
    }
}