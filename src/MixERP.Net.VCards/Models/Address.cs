using System;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Models
{
    /// <summary>
    ///     <para>
    ///         This property specifies a structured representation of the physical delivery address for the vCard object.
    ///         The property is made up of components that are based on the X.500 Post Office Box attribute, the X.520 Street
    ///         Address geographical attribute, the X.520 Locality Name geographical attribute, the X.520 State or Province
    ///         Name geographical attribute, the X.520 Postal Code attribute, and the X.520 Country Name geographical
    ///         attribute.
    ///     </para>
    ///     <para>
    ///         This property is identified by the property name ADR. The property value consists of components of the
    ///         address specified as positional fields separated by the Field Delimiter character (ASCII decimal 59).
    ///     </para>
    ///     <para>
    ///         The property value is a concatenation of
    ///         the Post Office Address (first field)
    ///         Extended Address (second field),
    ///         Street (third field),
    ///         Locality (fourth field),
    ///         Region (fifth field),
    ///         Postal Code (six field),
    ///         and Country (seventh field) strings.
    ///         An example of this property follows:
    ///     </para>
    ///     <para>ADR;DOM;HOME:P.O. Box 101;Suite 101;123 Main Street;Any Town;CA;91921-1234;</para>
    ///     <para>Support for this property is optional for vCard Writers conforming to this specification.</para>
    /// </summary>
    public sealed class Address
    {
        public AddressType Type { get; set; }

        /// <summary>
        ///     Post office box number
        /// </summary>
        public string PoBox { get; set; }

        public string ExtendedAddress { get; set; }

        public string Street { get; set; }

        public string Locality { get; set; }

        public string Region { get; set; }
        public string PostalCode { get; set; }

        public string Country { get; set; }

        #region v4.0

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string Label { get; set; }
        public TimeZoneInfo TimeZone { get; set; }
        public int Preference { get; set; }

        #endregion

        #region Non Standard
        public IEquatable<CustomExtension> Extensions { get; set; }
        #endregion
    }
}