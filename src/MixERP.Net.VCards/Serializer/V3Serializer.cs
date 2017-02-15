using System.Text;
using MixERP.Net.VCards.Processors;

namespace MixERP.Net.VCards.Serializer
{
    public static class V3Serializer
    {
        public static string Serialize(VCard vcard)
        {
            var builder = new StringBuilder();

            builder.Append(CategoriesProcessor.Serialize(vcard));
            builder.Append(NickNameProcessor.Serialize(vcard));
            builder.Append(SortStringProcessor.Serialize(vcard));
            builder.Append(SoundProcessor.Serialize(vcard));
            builder.Append(KeyProcessor.Serialize(vcard));
            builder.Append(ClassificationProcessor.Serialize(vcard));

            return builder.ToString();
        }
    }
}