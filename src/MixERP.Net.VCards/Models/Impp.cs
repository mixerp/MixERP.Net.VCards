using System;

namespace MixERP.Net.VCards.Models
{
    /// <summary>
    ///     Specifies the URI for instant messaging and presence protocol communications with the object the vCard represents.
    /// </summary>
    public sealed class Impp
    {
        public int Preference { get; set; }
        public Uri Address { get; set; }
    }
}