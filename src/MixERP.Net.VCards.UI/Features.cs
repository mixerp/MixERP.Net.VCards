namespace MixERP.Net.VCards.UI
{
    internal static class Features
    {
        internal static T Or<T>(this T actual, T substitute)
        {
            if (actual == null)
            {
                return substitute;
            }

            return actual;
        }
    }
}