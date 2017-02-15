namespace MixERP.Net.VCards.Models
{
    public sealed class Photo
    {
        public bool IsEmbedded { get; }
        public string Contents { get; }
        public string Extension { get; }

        public Photo(bool isEmbedded, string extension, string contents)
        {
            this.IsEmbedded = isEmbedded;
            this.Extension = extension;
            this.Contents = contents;
        }
    }
}