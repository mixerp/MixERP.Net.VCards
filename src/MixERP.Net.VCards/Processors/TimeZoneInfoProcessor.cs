using System;
using System.Linq;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;
using System.Globalization;

namespace MixERP.Net.VCards.Processors
{
    internal static class TimeZoneInfoProcessor
    {
        internal static string ToVCardValue(this TimeZoneInfo timeZone, VCardVersion version)
        {
            var offset = timeZone.BaseUtcOffset;
            string iso8601 = offset.ToString("hh\\:mm");

            if (offset.TotalMilliseconds < 0)
            {
                iso8601 = "-" + iso8601;
            }

            return iso8601;
        }

        internal static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("TZ", vcard.TimeZone.ToVCardValue(vcard.Version), false, vcard.Version);
        }

        //Todo: verify the correctness of this function
        //Please note that the string representation of time zone is an ISO 8601 time span.
        internal static TimeZoneInfo FromVCardValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            TimeSpan timeSpan;

            if (value.Contains(":"))
            {
                timeSpan = TimeSpan.Parse(value);
            }
            else
            {
                if (value.StartsWith("-"))
                {
                    value = value.Substring(1);

                    if(value.Length == 4)
                    {
                        timeSpan = TimeSpan.ParseExact(value, "hhmm", CultureInfo.InvariantCulture).Negate();
                    }

                    if(value.Length == 6)
                    {
                        timeSpan = TimeSpan.ParseExact(value, "hhmmss", CultureInfo.InvariantCulture).Negate();
                    }
                }
                else
                {
                    timeSpan = TimeSpan.ParseExact(value, "hhmm", CultureInfo.InvariantCulture);
                }
            }

            return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(x => x.BaseUtcOffset == timeSpan);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            string value = token.Values[0];
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var timezone = FromVCardValue(value);
            if (timezone == null)
            {
                return;
            }

            vcard.TimeZone = timezone;
        }
    }
}