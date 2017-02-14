using MixERP.Net.VCards.Models;
using MixERP.Net.VCards.Serializer;

namespace MixERP.Net.VCards.Processors
{
    internal static class NoteProcessor
    {
        internal static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("NOTE", vcard.Note, true, vcard.Version);
        }

        internal static void Parse(Token token, ref VCard vcard)
        {
            vcard.Note = token.Values[0];
        }
    }
}