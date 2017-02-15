using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MixERP.Net.VCards.Extensions;
using MixERP.Net.VCards.Lookups;
using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;
using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Processors
{
    public static class RelationsProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //Only vCard 4.0 supports RELATED property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }

            if (vcard.Relations == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            foreach (var relation in vcard.Relations)
            {
                string key = "RELATED";

                key = key + ";TYPE=" + relation.Type.ToVCardString();

                if (relation.Preference > 0)
                {
                    key = key + ";PREF=" + relation.Preference;
                }

                builder.Append(DefaultSerializer.GetVCardString(key, relation.RelationUri.ToString(), false, vcard.Version));
            }

            return builder.ToString();
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            var relation = new Relation();
            var preference = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "PREF");
            var type = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "TYPE");

            relation.Preference = preference.Value.ConvertTo<int>();
            relation.Type = RelationTypeLookup.Parse(type.Value);
            relation.RelationUri = new Uri(token.Values[0], UriKind.RelativeOrAbsolute);

            var relations = (List<Relation>) vcard.Relations ?? new List<Relation>();
            relations.Add(relation);
            vcard.Relations = relations;
        }
    }
}