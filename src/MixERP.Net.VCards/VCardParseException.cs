using System;

namespace MixERP.Net.VCards
{
    class VCardParseException : Exception
    {
        public VCardParseException()
        {
        }

        public VCardParseException(string message) : base(message)
        {
        }

        public VCardParseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}