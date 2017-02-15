namespace MixERP.Net.VCards.Extensions
{
    public static class StringExtensions
    {
        public static string Or(this string str, string or)
        {
            return string.IsNullOrWhiteSpace(str) ? or : str;
        }
    }
}