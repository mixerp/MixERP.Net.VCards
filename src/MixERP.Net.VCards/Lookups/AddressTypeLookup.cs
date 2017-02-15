using System;
using System.Collections.Generic;
using System.Linq;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Lookups
{
    public static class AddressTypeLookup
    {
        private static readonly Dictionary<AddressType, string> Lookup = new Dictionary<AddressType, string>
        {
            {AddressType.Domestic, "DOM"},
            {AddressType.Home, "HOME"},
            {AddressType.International, "INTL"},
            {AddressType.Parcel, "PARCEL"},
            {AddressType.Postal, "POSTAL"},
            {AddressType.Work, "WORK"}
        };

        public static string ToVCardString(this AddressType addressType)
        {
            return Lookup[addressType];
        }

        public static AddressType Parse(string addressType)
        {
            if (string.IsNullOrWhiteSpace(addressType))
            {
                return AddressType.Postal;
            }

            return Lookup.FirstOrDefault(x => string.Equals(x.Value, addressType, StringComparison.OrdinalIgnoreCase)).Key;
        }
    }
}