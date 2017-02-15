using System;

namespace MixERP.Net.VCards.Helpers
{
    public static class VCardHelper
    {
        public static string[] SplitCards(string contents)
        {
            contents = contents.Replace("BEGIN:VCARD", "");
            return contents.Split(new[] { "END:VCARD" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}