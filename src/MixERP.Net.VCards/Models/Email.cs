using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Models
{
    /// <summary>
    ///     <para>
    ///         This property specifies the address for electronic mail communication with the vCard object. The address is
    ///         in the form of a specific addressing type. For example, the Internet mail address for John Public might be
    ///         “John.Public@abc.com” or the CompuServe Information Service address might be “71234,5678”.This property is
    ///         identified by the property name EMAIL.
    ///     </para>
    ///     <para>An example of this property follows:</para>
    ///     <para>EMAIL;INTERNET:john.public@abc.com</para>
    ///     <para>Support for this property is optional for vCard Writers conforming to this specification.</para>
    /// </summary>
    public sealed class Email
    {
        public EmailType Type { get; set; }
        public string EmailAddress { get; set; }
        public int Preference { get; set; }
    }
}