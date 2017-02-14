using System;

namespace MixERP.Net.VCards.Types
{
    public sealed class VCardSerializationException : Exception
    {
        public VCardSerializationException()
        {
        }

        public VCardSerializationException(string message) : base(message)
        {
        }

        public VCardSerializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}