using System.Collections.Generic;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Processors;

namespace MixERP.Net.VCards.Parser
{
    public static class AllParsers
    {
        public static readonly Dictionary<string, Process> Parsers = new Dictionary<string, Process>
        {
            #region v2.1
            {"VERSION", VersionProcessor.Parse},
            {"N", NameProcessor.Parse}, //LastName, FirstName, MiddleName, Prefix, Suffix
            {"FN", FormattedNameProcessor.Parse},
            {"BDAY", BirthDayProcessor.Parse},
            {"ADR", AddressesProcessor.Parse}, //Longitude, Latitude, Preference, Label, TimeZone, PoBox, ExtendedAddress, Street, Locality, Region, PostalCode, Country
            {"LABEL", DeliveryAddressProcessor.Parse},
            {"REV", LastRevisionProcessor.Parse},
            {"TEL", TelephonesProcessor.Parse},
            {"EMAIL", EmailsProcessor.Parse},
            {"MAILER", MailerProcessor.Parse},
            {"TITLE", TitleProcessor.Parse},
            {"ROLE", RoleProcessor.Parse},
            {"TZ", TimeZoneInfoProcessor.Parse},
            {"LOGO", LogoProcessor.Parse},
            {"PHOTO", PhotoProcessor.Parse},
            {"NOTE", NoteProcessor.Parse},
            {"URL", UrlProcessor.Parse},
            {"UID", UidProcessor.Parse},
            {"ORG", OrganizationProcessor.Parse}, //Organization, OrganizationalUnit
            {"GEO", GeographyProcessor.Parse}, //Longitude, Latitude
            {"X-*", ExtensionsProcessor.Parse}, //Longitude, Latitude
            {"item*", ExtensionsProcessor.Parse}, //Longitude, Latitude
            #endregion

            #region v3.0
            {"NICKNAME", NickNameProcessor.Parse},
            {"CATEGORIES", CategoriesProcessor.Parse},
            {"SORT-STRING", SortStringProcessor.Parse},
            {"SOUND", SoundProcessor.Parse},
            {"KEY", KeyProcessor.Parse},
            {"CLASS", ClassificationProcessor.Parse},

            #endregion
            #region v4.0
            {"SOURCE", SourceUriProcessor.Parse},
            {"KIND", KindProcessor.Parse},
            {"ANNIVERSARY", AnniversaryProcessor.Parse},
            {"GENDER", GenderProcessor.Parse},
            {"IMPP", ImppsProcessor.Parse},
            {"LANG", LanguagesProcessor.Parse},
            {"RELATED", RelationsProcessor.Parse},
            {"CALURI", CalendarAddressesProcessor.Parse},
            {"CALADRURI", CalendarUserAddressesProcessor.Parse}
            #endregion
        };

        public delegate void Process(Token token, ref VCard vcard);
    }
}