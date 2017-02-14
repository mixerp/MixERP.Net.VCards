using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.UI
{
    public class Program
    {
        private const bool OnlyLogFailed = false;
        private static int _failures = 0;
        private static int _total = 0;

        private static void Main(string[] args)
        {
            CreateVCard();
            ParseVCard();

            if(_failures > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{_failures} out of {_total} failed.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All tests passed.");
            }

            Console.ReadLine();
        }

        private static void CreateVCard()
        {
            string root = AppContext.BaseDirectory;
            string path = Path.Combine(root, "../../../serialized.vcf");
            var vcard = SampleVCards.Get();
            string serialized = vcard.Serialize();

            File.WriteAllText(path, serialized);
        }


        private static void ParseVCard()
        {
            string root = AppContext.BaseDirectory;
            string path = Path.Combine(root, "../../../serialized.vcf");
            var expected = SampleVCards.Get();

            var vcards = Deserializer.Deserialize(path).ToList();

            Console.WriteLine("Welcome to MixERP.Net.VCards.");
            Console.WriteLine();
            Console.WriteLine();

            foreach (var actual in vcards)
            {
                //v2.1
                AssertValue("FormattedName", expected.FormattedName, actual.FormattedName);
                AssertValue("FirstName", expected.FirstName, actual.FirstName);
                AssertValue("MiddleName", expected.MiddleName, actual.MiddleName);
                AssertValue("LastName", expected.LastName, actual.LastName);
                AssertValue("Prefix", expected.Prefix, actual.Prefix);
                AssertValue("Suffix", expected.Suffix, actual.Suffix);
                AssertValue("BirthDay", expected.BirthDay?.ToString("o"), actual.BirthDay?.ToString("o"));
                AssertValue("Addresses", JsonConvert.SerializeObject(expected.Addresses.Or(new List<Address>()).OrderBy(x => x.Preference).ThenBy(x => x.Locality), Formatting.Indented), JsonConvert.SerializeObject(actual.Addresses.Or(new List<Address>()).OrderBy(x => x.Preference).ThenBy(x => x.Locality), Formatting.Indented));
                AssertValue("DeliveryAddress", JsonConvert.SerializeObject(expected.DeliveryAddress.Or(new DeliveryAddress()), Formatting.Indented), JsonConvert.SerializeObject(actual.DeliveryAddress.Or(new DeliveryAddress()), Formatting.Indented));
                AssertValue("Telephones", JsonConvert.SerializeObject(expected.Telephones.Or(new List<Telephone>()).OrderBy(x => x.Type).ThenBy(x => x.Number), Formatting.Indented), JsonConvert.SerializeObject(actual.Telephones.Or(new List<Telephone>()).OrderBy(x => x.Type).ThenBy(x => x.Number), Formatting.Indented));
                AssertValue("Emails", JsonConvert.SerializeObject(expected.Emails, Formatting.Indented), JsonConvert.SerializeObject(actual.Emails, Formatting.Indented));
                AssertValue("Mailer ", expected.Mailer, actual.Mailer);
                AssertValue("Title", expected.Title, actual.Title);
                AssertValue("Role", expected.Role, actual.Role);
                AssertValue("TimeZone", expected.TimeZone.ToString(), actual.TimeZone?.ToString());
                AssertValue("Logo", expected.Logo, actual.Logo);
                AssertValue("Photo", expected.Photo, actual.Photo);
                AssertValue("Note", expected.Note, actual.Note);
                AssertValue("LastRevision", expected.LastRevision?.ToString("o"), actual.LastRevision?.ToString("o"));
                AssertValue("Url", expected.Url?.ToString(), actual.Url?.ToString());
                AssertValue("UniqueIdentifier", expected.UniqueIdentifier, actual.UniqueIdentifier);
                AssertValue("Organization", expected.Organization, actual.Organization);
                AssertValue("OrganizationalUnit", expected.OrganizationalUnit, actual.OrganizationalUnit);
                AssertValue("Longitude", expected.Longitude.ToString(), actual.Longitude.ToString());
                AssertValue("Longitude", expected.Latitude.ToString(), actual.Latitude.ToString());

                //V3
                AssertValue("NickName", expected.NickName, actual.NickName);
                AssertValue("Categories", JsonConvert.SerializeObject(expected.Categories, Formatting.Indented), JsonConvert.SerializeObject(actual.Categories, Formatting.Indented));
                AssertValue("SortString", expected.SortString, actual.SortString);
                AssertValue("Sound", expected.Sound, actual.Sound);
                AssertValue("Key", expected.Key, actual.Key);
                AssertValue("Classification", Enum.GetName(typeof(ClassificationType), expected.Classification), Enum.GetName(typeof(ClassificationType), actual.Classification));

                //v4.0
                AssertValue("Source", expected.Source.ToString(), actual.Source?.ToString());
                AssertValue("Kind", Enum.GetName(typeof(Kind), expected.Kind), Enum.GetName(typeof(Kind), actual.Kind));
                AssertValue("Anniversary", expected.Anniversary?.ToString("o"), actual.Anniversary?.ToString("o"));
                AssertValue("Gender", Enum.GetName(typeof(Gender), expected.Gender), Enum.GetName(typeof(Gender), actual.Gender));
                AssertValue("Impps", JsonConvert.SerializeObject(expected.Impps, Formatting.Indented), JsonConvert.SerializeObject(actual.Impps, Formatting.Indented));
                AssertValue("Languages", JsonConvert.SerializeObject(expected.Languages, Formatting.Indented), JsonConvert.SerializeObject(actual.Languages, Formatting.Indented));
                AssertValue("Relations", JsonConvert.SerializeObject(expected.Relations, Formatting.Indented), JsonConvert.SerializeObject(actual.Relations, Formatting.Indented));
                AssertValue("CalendarUserAddresses", JsonConvert.SerializeObject(expected.CalendarUserAddresses, Formatting.Indented), JsonConvert.SerializeObject(actual.CalendarUserAddresses, Formatting.Indented));
                AssertValue("CalendarAddresses", JsonConvert.SerializeObject(expected.CalendarAddresses, Formatting.Indented), JsonConvert.SerializeObject(actual.CalendarAddresses, Formatting.Indented));
            }
        }

        //[Fact]
        private static void AssertValue(string propertyName, string expected, string actual)
        {
            _total++;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (OnlyLogFailed)
            {
                if (expected.Or("").Equals(actual.Or(""), StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }

            if (expected.Or("").Equals(actual.Or(""), StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Property : {propertyName} (PASSED)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Property : {propertyName} (FAILED)");
                _failures++;
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Expected Value : {expected}");
            Console.WriteLine($"Actual Value   : {actual}");

            //Assert.Equal(expected, actual);
            Console.WriteLine();
        }
    }
}