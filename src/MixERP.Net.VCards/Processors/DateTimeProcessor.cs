using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;
using System;
using System.Globalization;

namespace MixERP.Net.VCards.Processors
{
    public static class DateTimeProcessor
    {
        /// <summary>
        /// Includes DATE-AND-OR-TIME formats defined in vCard specification.
        /// See <a href="https://tools.ietf.org/html/rfc6350#section-4.3.4">https://tools.ietf.org/html/rfc6350#section-4.3.4</a>
        /// </summary>
        private readonly static string[] _acceptedDateTimeFormats =
            new[]
        {
            "o",
            "s",
            "yyyyMMddTHHmmssZ",
            "yyyyMMddTHHmmss",
            "yyyyMMdd",
            "yyyy-MM-ddTHH:mm:ssZ",
            "yyyy-MM-dd",
            "yyyy-MM",
            "yyyy",
            "THHmmss-ffff",
            "THHmmssZ",
            "THHmmss",
            "THHmm",
            "THH",
            "T-mmss",
            "T--ss",
            "--MMddTHHmmssZ",
            "--MMddTHHmm",
            "--MMdd",
            "---ddTHH",
            "---dd"
        };

        public static string Serialize(DateTime? value, string key, VCardVersion version)
        {
            string serializedValue = value?.ToString("o") ?? string.Empty;

            return string.IsNullOrWhiteSpace(serializedValue) ? string.Empty : DefaultSerializer.GetVCardString(key, serializedValue, false, version);
        }

        public static DateTime? Parse(string value)
        {
            DateTime parsed;

            if (DateTime.TryParseExact(
                value,
                _acceptedDateTimeFormats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.RoundtripKind,
                out parsed))
            {
                return parsed;
            }

            return null;
        }
    }

}