using MixERP.Net.VCards.Types;

namespace MixERP.Net.VCards.Models
{
    public sealed class Language
    {
        public LanguageType Type { get; set; }
        public int Preference { get; set; }
        public string Name { get; set; }
    }
}