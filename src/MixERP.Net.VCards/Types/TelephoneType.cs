namespace MixERP.Net.VCards.Types
{
    /// <summary>
    /// This property parameter specifies the sub-type of telephone that is associated with the telephone number (e.g., Home, Work, Cellular, Facsimile, Video, Modem, Message Service, or Preferred). One or more sub-type values can be specified for a given telephone number.
    /// </summary>
    public enum TelephoneType
    {
        /// <summary>
        /// Indicates preferred number.
        /// </summary>
        Preferred,

        /// <summary>
        /// Indicates a work number.
        /// </summary>
        Work,

        /// <summary>
        /// Indicates a home number
        /// </summary>
        Home,

        /// <summary>
        /// Indicates a voice number (Default).
        /// </summary>
        Voice,

        /// <summary>
        /// Indicates a facsimile number.
        /// </summary>
        Fax,

        /// <summary>
        /// Indicates a messaging service on the number.
        /// </summary>
        Message,

        /// <summary>
        /// Indicates a cellular number.
        /// </summary>
        Cell,

        /// <summary>
        /// Indicates a pager number.
        /// </summary>
        Pager,

        /// <summary>
        /// Indicates a bulletin board service number.
        /// </summary>
        Bbs,

        /// <summary>
        /// Indicates a MODEM number.
        /// </summary>
        Modem,

        /// <summary>
        /// Indicates a car-phone number.
        /// </summary>
        Car,

        /// <summary>
        /// Indicates an Integrated Services Digital Network number.
        /// </summary>
        Isdn,

        /// <summary>
        /// Indicates a video-phone number.
        /// </summary>
        Video,
        /// <summary>
        /// Indicates preferred number.
        /// </summary>
        Personal
    }
}