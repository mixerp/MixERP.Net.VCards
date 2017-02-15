using System;
using System.Collections.Generic;
using System.Linq;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Lookups
{
    public static class TelephoneTypeLookup
    {
        private static readonly Dictionary<TelephoneType, string> Lookup = new Dictionary<TelephoneType, string>
        {
            {TelephoneType.Preferred, "PREF"},
            {TelephoneType.Work, "WORK"},
            {TelephoneType.Home, "HOME"},
            {TelephoneType.Voice, "VOICE"},
            {TelephoneType.Fax, "FAX"},
            {TelephoneType.Message, "MSG"},
            {TelephoneType.Cell, "CELL"},
            {TelephoneType.Pager, "PAGER"},
            {TelephoneType.Bbs, "BBS"},
            {TelephoneType.Modem, "MODEM"},
            {TelephoneType.Car, "CAR"},
            {TelephoneType.Isdn, "ISDN"},
            {TelephoneType.Video, "VIDEO"},
            {TelephoneType.Personal, "PCS"}
        };

        public static string ToVCardString(this TelephoneType type, VCardVersion version)
        {
            string result = Lookup[type];

            if (result == "PCS" && version == VCardVersion.V2_1)
            {
                return string.Empty;
                //throw new VCardSerializationException("The personal communication services telephone number type is not supported by vCard 2.1!");
            }

            return result;
        }

        public static TelephoneType Parse(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return TelephoneType.Preferred;
            }

            return Lookup.FirstOrDefault(x => string.Equals(x.Value, type, StringComparison.OrdinalIgnoreCase)).Key;
        }
    }
}