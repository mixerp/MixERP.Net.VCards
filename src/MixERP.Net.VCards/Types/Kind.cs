namespace MixERP.Net.VCards.Types
{
    /// <summary>
    ///     Specifies the kind of object the vCard represents.
    /// </summary>
    public enum Kind
    {
        /// <summary>
        ///     For a vCard representing a single person or entity.
        /// </summary>
        Individual,

        /// <summary>
        ///     For a vCard representing a group of persons or entities.
        ///     <para>
        ///         The group's member entities can be other vCards or other types
        ///         of entities, such as email addresses or web sites.  A group
        ///         vCard will usually contain MEMBER properties to specify the
        ///         members of the group, but it is not required to.  A group vCard
        ///         without MEMBER properties can be considered an abstract
        ///         grouping, or one whose members are known empirically
        ///         (perhaps "IETF Participants" or "Republican U.S. Senators").
        ///     </para>
        /// </summary>
        Group,

        /// <summary>
        /// For a vCard representing an organization.
        /// <para>An organization vCard will not (in fact, MUST NOT) contain MEMBER properties
        /// and so these are something of a cross between "individual" and
        /// "group".  An organization is a single entity, but not a person
        /// It might represent a business or government, a department or
        /// division within a business or government, a club, an
        /// association, or the like.
        /// </para>
        /// <para>All properties in an organization vCard apply to the
        /// organization as a whole, as is the case with a group vCard.
        /// For example, an EMAIL property might specify the address of a
        /// contact point for the organization.
        /// </para>
        /// </summary>
        Organization,

        /// <summary>
        /// For a named geographical place.
        /// 
        /// <para>A location vCard will usually contain a GEO property, but it is not required to.
        /// A location vCard without a GEO property can be considered an
        /// abstract location, or one whose definition is known empirically
        /// (perhaps "New England" or "The Seashore").
        /// </para>
        /// <para>
        /// All properties in a location vCard apply to the location
        /// itself, and not with any entity that might exist at that
        /// location.  For example, in a vCard for an office building, an
        /// ADR property might give the mailing address for the building,
        /// and a TEL property might specify the telephone number of the
        /// receptionist.
        /// </para>
        /// </summary>
        Location
    }
}