using System;
using System.Collections.Generic;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards
{
    public class VCard
    {
        #region v2.1 https://www.imc.org/pdi/vcard-21.txt

        /// <summary>
        ///     <para>
        ///         This property specifies the date of birth of the individual associated with the vCard. The value for this
        ///         property is a calendar date in a complete representation consistent with ISO 8601.
        ///     </para>
        ///     <para>
        ///         This property is identified by the property name BDAY. The property value is a string conforming to the ISO
        ///         8601 calendar date, complete representation, in either basic or extended format. The following example is in
        ///         the basic format of ISO 8601:
        ///     </para>
        ///     <para>BDAY:19950415</para>
        ///     <para>The following example is in the extended format of ISO 8601:</para>
        ///     <para>BDAY:1995-04-15</para>
        ///     <para>Support for this property is optional for vCard Writers conforming to this specification.</para>
        /// </summary>
        public DateTime? BirthDay { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }

        public IEnumerable<Telephone> Telephones { get; set; }
        public IEnumerable<Email> Emails { get; set; }

        public string Mailer { get; set; } = "Frapid";

        /// <summary>
        ///     <para>
        ///         This property specifies the job title, functional position or function of the individual associated with the
        ///         vCard object within an organization. This property is based on the X.520 Title attribute. For example, “Vice
        ///         President, Research and Development”.
        ///     </para>
        ///     <para>This property is identified by the property name TITLE. An example of this property follows:</para>
        ///     <para>TITLE:V.P., Research and Development</para>
        ///     <para>Support for this property is optional for vCard Writers conforming to this specification.</para>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     <para>
        ///         This property specifies information concerning the role, occupation, or business category of the vCard object
        ///         within an organization. This property is based on the X.520 Business Category  explanatory attribute. For
        ///         example, “Programmer”. This property is included as an organizational property to avoid confusion with the
        ///         Title property and to avoid incorrect use of the Title property to record Business Category information.
        ///     </para>
        ///     <para>This property is identified by the property name ROLE. An example of this property follows:</para>
        ///     <para>ROLE:Executive</para>
        ///     <para>Support for this property is optional for vCard Writers conforming to this specification.</para>
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        ///     <para>
        ///         This property specifies information related to the standard time zone of the vCard object. The time zone is a
        ///         string as specified in a manner consistent with ISO 8601. It is an offset from Coordinated Universal Time
        ///         (UTC). An ISO 8601 UTC offset, in basic format, is specified as a positive or negative difference in units of
        ///         hours and minutes (e.g., +hhmm). If minutes are zero, then they may be omitted and the format would be
        ///         specified in units of hours (e.g., +hh). The time is specified as a 24-hour clock. Hour values are from 00 to
        ///         24, and minute values are from 00 through 59. Hour and minute values are 2-digits with high-order zeroes
        ///         required to maintain digit count. The extended format for ISO 8601 makes use of a colon (i.e., “:”) character
        ///         as a separator of the hour and minute substrings.
        ///     </para>
        ///     <para>This is not a property for capturing the daylight savings time rules observed by the vCard object.</para>
        ///     <para>
        ///         This property is identified by the property name TZ. This property is specified in a manner consistent with
        ///         ISO 8601. The property value is a signed numeric indicating the number of hours and possibly minutes from UTC.
        ///         Time zones east of UTC are positive numbers. Time zones west of UTC are negative numbers. Support for this
        ///         property is optional for vCard Writers conforming to this specification. An example of the Eastern Standard
        ///         Time (EST) zone value for this property follows using the basic format:
        ///     </para>
        ///     <para>TZ:-0500</para>
        ///     <para>An example of the Pacific Standard Time (PST) zone value for this property follows using the extended format:</para>
        ///     <para>TZ:-08:00</para>
        /// </summary>
        public TimeZoneInfo TimeZone { get; set; }

        /// <summary>
        ///     <para>
        ///         This property specifies Base64 encoded image or graphic of the logo of the organization that is associated
        ///         with the individual to which the vCard belongs.
        ///     </para>
        ///     <para>
        ///         This property is identified by the property name LOGO. An example of a value for a GIF formatted image of a
        ///         logo in Base 64 encoding for this property follows:
        ///     </para>
        ///     <code>LOGO;ENCODING=BASE64;TYPE=GIF:
        /// R0lGODdhfgA4AOYAAAAAAK+vr62trVIxa6WlpZ+fnzEpCEpzlAha/0Kc74+PjyGM ...</code>
        ///     <para>Support for this property is optional for vCard Writers conforming to this specification.</para>
        /// </summary>
        public string Logo { get; set; }

        public string Photo { get; set; }


        /// <summary>
        ///     <para>
        ///         This property specifies supplemental information or a comment that is associated with the vCard. With the use
        ///         of property grouping, the association can be limited to a group of properties. The property is based on the
        ///         X.520 Description attribute.
        ///     </para>
        /// </summary>
        public string Note { get; set; }


        /// <summary>
        ///     <para>
        ///         This property specifies the combination of the calendar date and time of day of the last update to the vCard
        ///         object. The property value is a character string conforming to the basic or extended format of ISO 8601. The
        ///         value can either be in terms of local time or UTC.
        ///     </para>
        ///     <para>
        ///         This property is identified by the property name REV. Valid values for this property are a character string
        ///         representing a combination of the calendar date and time of day conforming to the basic or extended format of
        ///         ISO 8601. The time of day can be either local time or UTC. The following example is in the basic format and
        ///         local time of ISO 8601:
        ///     </para>
        ///     <code>REV:19951031T222710</code>
        ///     <para>The following example is in the extended format and UTC time of ISO 8601:</para>
        ///     <code>REV:1995-10-31T22:27:10Z</code>
        ///     <para>Support for this property is optional for vCard Writers conforming to this specification.</para>
        /// </summary>
        public DateTime? LastRevision { get; set; }

        public Uri Url { get; set; }

        /// <summary>
        ///     <para>
        ///         This property specifies a value that represents a persistent, globally unique identifier associated with the
        ///         object. The property can be used as a mechanism to relate different vCard objects. Some examples of valid forms
        ///         of unique identifiers would include ISO 9070 formal public identifiers (FPI), X.500 distinguished names,
        ///         machine-generated “random” numbers with a statistically high likelihood of being globally unique and Uniform
        ///         Resource Locators (URL). If an URL is specified, it is suggested that the URL reference a service which will
        ///         produce an updated version of the vCard.
        ///     </para>
        ///     <para>
        ///         This property is identified by the property name UID. This property is provided to enable a vCard Reader and
        ///         Writer to uniquely identify either a vCard object instance or properties within a vCard object. Valid values
        ///         for this property are a unique character string. The following is an example of this property:
        ///     </para>
        ///     <code>UID:19950401-080045-40000F192713-0052</code>
        ///     <para>Support for this property is optional for vCard Writers conforming to this specification.</para>
        /// </summary>
        public string UniqueIdentifier { get; set; }

        /// <summary>
        ///     The vCard VCardVersion Number. Support for this property is mandatory for implementations conforming to this
        ///     specification. This property must appear within the vCard data stream.
        /// </summary>
        public VCardVersion Version { get; set; }

        #region Organization Name & Unit

        public string Organization { get; set; }

        public string OrganizationalUnit { get; set; }

        #endregion

        #region Geographic Position

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        #endregion

        #region Name & Formatted Name

        /// <summary>
        ///     <para>
        ///         This property specifies the formatted name string associated with the vCard object. This is the way that the
        ///         name is to be displayed. It can contain desired honorific prefixes, suffixes, titles, etc. For example, “Mr.
        ///         John Q. Public, Jr.”, Dr. Ann Tyler, or Hon. Judge Blackwell. This property is based on the semantics of the
        ///         X.520 Common Name attribute.
        ///     </para>
        ///     <para>
        ///         This property is identified by the property name FN. The following is an example of the Formatted Name
        ///         property:
        ///     </para>
        ///     <para>FN:Mr. John Q. Public, Esq.</para>
        ///     Support for this property is optional for vCard Writers conforming to this specification.
        /// </summary>
        public string FormattedName { get; set; }

        #region Name

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        #endregion

        #endregion

        #endregion

        #region v3.0 RFC 2426 (https://www.ietf.org/rfc/rfc2426.txt)

        /// <summary>
        ///     <para>
        ///         The descriptive name given instead of or in addition to the one belonging to a person, place, or thing. It
        ///         can also be used to specify a familiar form of a proper name specified by the FN or N types.
        ///     </para>
        ///     <para>Type example:</para>
        ///     <code>NICKNAME:Jim,Jimmie</code>
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        ///     Specifies application category information about the vCard.
        /// </summary>
        public string[] Categories { get; set; }

        public string SortString { get; set; }

        /// <summary>
        ///     A BASE64 string which specifies a digital sound content information that annotates some aspect of the vCard. By
        ///     default this type is used to specify the proper pronunciation of the name type value of the vCard.
        /// </summary>
        public string Sound { get; set; }

        /// <summary>
        ///     Specifies a public key or authentication certificate associated with the object that the vCard represents.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Specifies the access classification for the vCard object.
        /// </summary>
        public ClassificationType Classification { get; set; }

        #endregion

        #region v4.0 RFC 6350 (https://www.ietf.org/rfc/rfc6350.txt)

        /// <summary>
        ///     <para>Identifies the source of directory information contained in the content type.</para>
        ///     <para>
        ///         The SOURCE property is used to provide the means by which applications knowledgable
        ///         in the given directory service protocol can obtain additional or more up-to-date information
        ///         from the directory service. It contains a URI as defined in [RFC3986] and/or other information
        ///         referencing the vCard to which the information pertains. When directory information is available
        ///         from more than one source, the sending entity can pick what it considers to be the best source,
        ///         or multiple SOURCE properties can be included.
        ///     </para>
        ///     <para>Examples</para>
        ///     <code>SOURCE:ldap://ldap.example.com/cn=Babs%20Jensen,%20o=Babsco,%20c=US</code>
        ///     <code>SOURCE:http://directory.example.com/addressbooks/jdoe/Jean%20Dupont.vcf</code>
        /// </summary>
        public Uri Source { get; set; }

        /// <summary>
        ///     Identifies the source of directory information contained in the content type.
        /// </summary>
        public Kind Kind { get; set; }

        /// <summary>
        ///     The date of marriage, or equivalent, of the object the vCard represents.
        /// </summary>
        public DateTime? Anniversary { get; set; }

        public Gender Gender { get; set; } = Gender.Unknown;

        /// <summary>
        ///     Specifies a list of instant messaging and presence protocol communications with the object the vCard represents.
        /// </summary>
        public IEnumerable<Impp> Impps { get; set; }

        /// <summary>
        ///     Specifies the language(s) that may be used for contacting the entity associated with the vCard.
        /// </summary>
        public IEnumerable<Language> Languages { get; set; }

        //Specifies relationship between another entity and the entity represented by this vCard.
        public IEnumerable<Relation> Relations { get; set; }

        /// <summary>
        ///     Specifies the calendar user addresses [RFC5545] to which a scheduling request [RFC5546] should be sent for the
        ///     object represented by the vCard.
        /// </summary>
        public IEnumerable<Uri> CalendarUserAddresses { get; set; }

        /// <summary>
        ///     Specifies the URI for calendars associated with the object represented by the vCard.
        /// </summary>
        public IEnumerable<Uri> CalendarAddresses { get; set; }

        #endregion

        public IEnumerable<CustomExtension> CustomExtensions { get; set; }
    }
}