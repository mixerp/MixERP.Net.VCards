using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Models
{
    /// <summary>
    ///     This property specifies the canonical number string for a telephone number for telephony communication with the
    ///     vCard object. The value of this property is specified in a canonical form in order to specify an unambiguous
    ///     representation of the globally unique telephony endpoint. This property is based on the X.520 Telephone Number
    ///     attribute.
    /// </summary>
    public sealed class Telephone
    {
        public TelephoneType Type { get; set; }
        public string Number { get; set; }
        public int Preference { get; set; }
    }
}