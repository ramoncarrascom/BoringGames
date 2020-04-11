using BoringGames.Shared.Enums;
using System;
using System.Runtime.Serialization;

namespace BoringGames.Shared.Exceptions
{
    [Serializable]
    public class NotValidStateException : BgException
    {
        public NotValidStateException() : base() { }

        public NotValidStateException(string message) : base(message) { }

        public NotValidStateException(string message, ErrorCode errorCode) : base(message, errorCode) { }

        protected NotValidStateException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
