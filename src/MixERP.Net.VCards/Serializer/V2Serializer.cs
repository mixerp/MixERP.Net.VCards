using System.Text;
using MixERP.Net.VCards.Processors;

namespace MixERP.Net.VCards.Serializer
{
    internal static class V2Serializer
    {
        internal static string Serialize(VCard vcard)
        {
            var builder = new StringBuilder();

            builder.Append(VersionProcessor.Serialize(vcard));
            builder.Append(FormattedNameProcessor.Serialize(vcard));
            builder.Append(NameProcessor.Serialize(vcard));
            builder.Append(BirthDayProcessor.Serialize(vcard));
            builder.Append(MailerProcessor.Serialize(vcard));
            builder.Append(TitleProcessor.Serialize(vcard));
            builder.Append(RoleProcessor.Serialize(vcard));
            builder.Append(TimeZoneInfoProcessor.Serialize(vcard));

            //Todo: check if the value is URI or BASE64 string.
            builder.Append(LogoProcessor.Serialize(vcard));
            builder.Append(PhotoProcessor.Serialize(vcard));

            builder.Append(NoteProcessor.Serialize(vcard));
            builder.Append(LastRevisionProcessor.Serialize(vcard.LastRevision, vcard.Version));
            builder.Append(UrlProcessor.Serialize(vcard));
            builder.Append(UidProcessor.Serialize(vcard));
            builder.Append(OrganizationProcessor.Serialize(vcard));
            builder.Append(GeographyProcessor.Serialize(vcard));

            builder.Append(AddressesProcessor.Serialize(vcard));
            builder.Append(DeliveryAddressProcessor.Serialize(vcard));
            builder.Append(TelephonesProcessor.Serialize(vcard));
            builder.Append(EmailsProcessor.Serialize(vcard));
            builder.Append(ExtensionsProcessor.Serialize(vcard));

            return builder.ToString();
        }
    }
}