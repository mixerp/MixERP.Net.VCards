# MixERP.Net.VCards

VCards is a standard-compliant, lightweight, and forgiving vCard parser written in C# which supports parsing and serializing vCards. The following versions are supported:

- Version 2.1
- Version 3.0
- Version 4.0

## How to Use this Library?

**Download Nuget Package**

```nuget
Install-Package MixERP.Net.VCards
```

**Create a vCard**

```csharp
var vcard = new VCard
{
    Version = VCardVersion.V4,
    FormattedName = "John Doe",
    FirstName = "John",
    LastName = "Doe",
    Classification = ClassificationType.Confidential,
    Categories = new[] {"Friend", "Fella", "Amsterdam"},
    //...
};
```
**Serialize a vCard and Save as a VCF File**

```
string serialized = vcard.Serialize();
string path = Path.Combine("C:\", "JohnDoe.vcf");
File.WriteAllText(path, serialized);
```

**Parse a VCF File**
```csharp
IEnumerable<VCard> vcards = MixERP.Net.VCards.Deserializer.Deserialize(path);
```
or

```csharp
string contents = File.ReadAllText(path, Encoding.UTF8);
IEnumerable<VCard> vcards = MixERP.Net.VCards.Deserializer.FromString(contents);

foreach (var vcard in vcards)
{
    Console.WriteLine(vcard.FirstName + " \t " + vcard.MiddleName + " " + vcard.LastName);
    Console.WriteLine(vcard.FormattedName);
}
Console.ReadLine();
```


## Supported V2 Features:
For more info, please see the [specifications here](https://www.imc.org/pdi/vcard-21.txt)

- Formatted Name (`FN` string)
- Last Name (`N` string)
- First Name (`N` string)
- Middle Name (`N` string)
- Prefix (`N` string)
- Suffix (`N` string)
- BirthDay (`BDAY` string)
- Addresses (`ADR` complex enumerable)
- Delivery Address (`LABEL` complex)
- Telephones (`TEL` complex enumerable)
- Emails  (`EMAIL` complex enumerable)
- Mailer (`MAILER` string)
- Title (`TITLE` string)
- Role (`ROLE` string)
- TimeZone (`TITLE` TimeZoneInfo)
- Logo (`LOGO` string, Base64 Encoded)
- Photo (`PHOTO` string, Base64 Encoded)
- Note (`NOTE` string)
- Last Revision (`REV` DateTime?)
- Url (`URL` Uri)
- Unique Identifier (`UID` string)
- Version (`VERSION` enum)
- Organization (`ORG` string)
- OrganizationalUnit (`ORG` string)
- Longitude (`GEO` double)
- Latitude (`GEO` double)

## Supported V3 Features:
For more info, please see the [RFC 2426 specifications here](https://www.ietf.org/rfc/rfc2426.txt)
- Nick Name (`NICKNAME` string)
- Categories (`CATEGORIES` string[])
- Sort String (`SORT-STRING` string) 
- Sound (`SOUND` string, Base64 Encoded)
- Key  (`KEY` string, Base64 Encoded)
- Classification (`CLASS` string)

## Supported V4 Features:
For more info, please see the [RFC 6350 specifications here](https://www.ietf.org/rfc/rfc6350.txt)

- Source (`SOURCE` Uri)
- Kind (`KIND` enum)
- Anniversary (`ANNIVERSARY` DateTime?)
- Gender (`GENDER` enum)
- Impps (`IMPP` complex ienumerable)
- Languages (`LANG` complex enumerable)
- Relations (`RELATED` complex enumerable)
- Calendar User Addresses (`CALADRURI` Uri enumerable) 
- Calendar Addresses (`CALURI` complex enumerable)

