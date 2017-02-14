namespace MixERP.Net.VCards.Types
{
    /// <summary>
    ///     This property parameter specifies the sub-types of physical delivery that is associated with the delivery address.
    ///     For example, the label may need to be differentiated for Home, Work, Parcel, Postal, Domestic, and International
    ///     physical delivery. One or more sub-types can be specified for a given delivery address.
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        ///     Indicates a domestic address.
        /// </summary>
        Domestic,

        /// <summary>
        ///     Indicates an international address
        /// </summary>
        International,

        /// <summary>
        ///     Indicates an postal address
        /// </summary>
        Postal,

        /// <summary>
        ///     Indicates an parcel delivery address
        /// </summary>
        Parcel,

        /// <summary>
        ///     Indicates an home address
        /// </summary>
        Home,

        /// <summary>
        ///     Indicates an work address
        /// </summary>
        Work
    }
}