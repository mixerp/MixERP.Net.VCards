using System;

namespace MixERP.Net.VCards.Extensions
{
    public static class GenericExtensions
    {
        public static T ConvertTo<T>(this string valueAsString) where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
            {
                return default(T);
            }

            return (T) Convert.ChangeType(valueAsString, typeof(T));
        }

        public static T? ConvertToNullableT<T>(this string valueAsString) where T : struct
        {
            if (string.IsNullOrEmpty(valueAsString))
            {
                return null;
            }

            return (T) Convert.ChangeType(valueAsString, typeof(T));
        }

        public static T Coalesce<T>(this T actual, T substitute)
        {
            if (actual == null)
            {
                return substitute;
            }

            return actual;
        }
    }
}