using System.Collections.Generic;
using System.Linq;
using System.Text;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Lookups;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class AddressesProcessor
    {
        private static string Serialize(Address address, VCardVersion version)
        {
            string type = address.Type.ToVCardString();

            string key = "ADR";

            if (version == VCardVersion.V4)
            {
                if (address.Longitude != null && address.Latitude != null)
                {
                    key = key + ";GEO=\"" + address.Longitude.Value.ToString("N4") + "," + address.Latitude.Value.ToString("N4") + "\"";
                }

                if (address.Preference > 0)
                {
                    key = key + ";PREF=" + address.Preference;
                }

                if (!string.IsNullOrWhiteSpace(address.Label))
                {
                    key = key + ";LABEL=\"" + address.Label.Escape() + "\"";
                }

                if (address.TimeZone != null)
                {
                    key = key + ";TZ=\"" + address.TimeZone.ToVCardValue(version) + "\"";
                }
            }

            return GroupProcessor.Serialize(key, version, type, true, address.PoBox, address.ExtendedAddress, address.Street, address.Locality, address.Region, address.PostalCode, address.Country);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            var address = new Address();

            if (vcard.Version == VCardVersion.V4)
            {
                var geo = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "GEO");
                if (!string.IsNullOrWhiteSpace(geo.Value))
                {
                    var coordinates = geo.Value.Split(',').Select(x => x.Trim()).ToList();

                    if (coordinates.Count > 0)
                    {
                        address.Longitude = coordinates[0].ConvertToNullableT<double>();
                    }

                    if (coordinates.Count > 1)
                    {
                        address.Latitude = coordinates[0].ConvertToNullableT<double>();
                    }
                }

                var type = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "TYPE");
                address.Type = AddressTypeLookup.Parse(type.Value);

                var pref = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "PREF");
                address.Preference = pref.Value.ConvertTo<int>();

                var label = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "LABEL");
                address.Label = label.Value;

                var timezone = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "TZ");
                address.TimeZone = TimeZoneInfoProcessor.FromVCardValue(timezone.Value);
            }

            if (token.Values.Length > 0)
            {
                address.PoBox = token.Values[0];
            }

            if (token.Values.Length > 1)
            {
                address.ExtendedAddress = token.Values[1];
            }

            if (token.Values.Length > 2)
            {
                address.Street = token.Values[2];
            }

            if (token.Values.Length > 3)
            {
                address.Locality = token.Values[3];
            }

            if (token.Values.Length > 4)
            {
                address.Region = token.Values[4];
            }

            if (token.Values.Length > 5)
            {
                address.PostalCode = token.Values[5];
            }

            if (token.Values.Length > 6)
            {
                address.Country = token.Values[6];
            }

            var addresses = (List<Address>) vcard.Addresses ?? new List<Address>();
            addresses.Add(address);
            vcard.Addresses = addresses;
        }

        public static string Serialize(VCard vcard)
        {
            if (vcard.Addresses == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (var address in vcard.Addresses)
            {
                builder.Append(Serialize(address, vcard.Version));
            }

            return builder.ToString();
        }
    }
}