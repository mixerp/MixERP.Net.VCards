namespace MixERP.Net.VCards.Extensions
{
    internal static class StringExtensions
    {
        internal static string Or(this string str, string or)
        {
            return string.IsNullOrWhiteSpace(str) ? or : str;
        }
    }
}