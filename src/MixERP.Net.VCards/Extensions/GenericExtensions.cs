using System;

namespace MixERP.Net.VCards.Extensions
{
    internal static class GenericExtensions
    {
        internal static T ConvertTo<T>(this string valueAsString) where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
            {
                return default(T);
            }

            return (T) Convert.ChangeType(valueAsString, typeof(T));
        }

        internal static T? ConvertToNullableT<T>(this string valueAsString) where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
            {
                return null;
            }

            return (T) Convert.ChangeType(valueAsString, typeof(T));
        }
    }
}