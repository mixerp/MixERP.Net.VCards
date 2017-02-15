using System;
using System.Collections.Generic;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Types;
using System.Globalization;

namespace MixERP.Net.VCards.UI
{
    public static class SampleVCards
    {
        public static VCard Get()
        {
            return new VCard
            {
                Version = VCardVersion.V4,
                FormattedName = "John Doe",
                FirstName = "John",
                LastName = "Doe",
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Newfoundland Standard Time"),
                DeliveryAddress = new DeliveryAddress
                {
                    Type = AddressType.Parcel,
                    Address = "New Orleans"
                },
                Addresses = new List<Address>
                    {
                        new Address
                        {
                            Type = AddressType.Home,
                            PoBox = "234",
                            ExtendedAddress = "Address Line 2",
                            Street = "Street",
                            Locality = "City",
                            Region = "State",
                            PostalCode = "234234",
                            Country = "United States",
                            Label = "Home Address",
                            Preference = 1,
                            TimeZone = TimeZoneInfo.Local
                        }
                    },
                Telephones = new List<Telephone>
                    {
                        new Telephone
                        {
                            Type = TelephoneType.Preferred,
                            Number = "(345) 501-2527"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Home,
                            Number = "(614) 220-8747"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Work,
                            Number = "(262) 857-3144"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Car,
                            Number = "+44 909 879 0893"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Fax,
                            Number = "+1-202-555-0177"
                        },
                        new Telephone
                        {
                            Type = TelephoneType.Cell,
                            Number = "202-555-0198"
                        }
                    },
                BirthDay = DateTime.Today.AddYears(-20),
                Emails = new List<Email>
                    {
                        new Email
                        {
                            Type = EmailType.Smtp,
                            EmailAddress = "john@example.com"
                        },
                        new Email
                        {
                            Type = EmailType.AppleLink,
                            EmailAddress = "example@applelink.com"
                        }
                    },
                LastRevision = DateTime.Parse("2017-02-14T20:40:50.1899247Z", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                Note = "This is a test",
                Url = new Uri("http://example.com"),
                Organization = "ABC, Inc.",
                NickName = "Jim, Jimmie",
                SortString = "Jim",
                Categories = new[] { "Friends", "School", "Bike" },
                Classification = ClassificationType.Private,
                OrganizationalUnit = "North American, Division;Marketing",
                Title = "V.P., Research, and Development",
                Mailer = "Frapid",
                Latitude = -17.87,
                Longitude = 37.24,
                Prefix = "Mr.",
                Suffix = "Esq.",
                UniqueIdentifier = "970e501e-30fb-4cd1-90c6-5ce55b79a1a6",
                Role = "Executive",
                Source = new Uri("http://directory.example.com/addressbooks/jdoe/Jean%20Dupont.vcf"),
                Kind = Kind.Individual,
                Anniversary = DateTime.Today.AddYears(-3),
                Gender = Gender.Male,
                Impps = new List<Impp>
                    {
                        new Impp
                        {
                            Preference = 1,
                            Address = new Uri("test@example.com", UriKind.RelativeOrAbsolute)
                        },
                        new Impp
                        {
                            Preference = 2,
                            Address = new Uri("xmpp:alice@example.com", UriKind.RelativeOrAbsolute)
                        }
                    },
                Languages = new List<Language>
                    {
                        new Language
                        {
                            Type = LanguageType.Home,
                            Preference = 1,
                            Name = "en"
                        },
                        new Language
                        {
                            Type = LanguageType.Work,
                            Preference = 1,
                            Name = "fr"
                        }
                    },
                Relations = new List<Relation>
                    {
                        new Relation
                        {
                            Type = RelationType.Colleague,
                            Preference = 1,
                            RelationUri = new Uri("https://facebook.com/1")
                        },
                        new Relation
                        {
                            Type = RelationType.Acquaintance,
                            Preference = 1,
                            RelationUri = new Uri("http://example.com/directory/jdoe.vcf")
                        }
                    },
                CalendarUserAddresses = new List<Uri>
                    {
                        new Uri("mailto:janedoe@example.com"),
                        new Uri("http://example.com/calendar/jdoe")
                    },
                CalendarAddresses = new List<Uri>
                    {
                        new Uri("http://cal.example.com/calA"),
                        new Uri("ftp://ftp.example.com/calA.ics", UriKind.Absolute)
                    },
                CustomExtensions = new List<CustomExtension>
                {
                    new CustomExtension
                    {
                        Key = "X-ASSISTANT",
                        Value = "William James"
                    },
                    new CustomExtension
                    {
                        Key = "X-ASSISTANT",
                        Values = new[]{"John Crichton", "aeryn sun" }
                    },
                    new CustomExtension
                    {
                        Key = "X-SKYPE",
                        Values = new[]{"092B3492", "092F3492" }
                    },
                    new CustomExtension
                    {
                        Key = "item1.TEL",
                        Values = new[]{"092B3492", "092F3492" }
                    }
                }
            };

        }
    }
}