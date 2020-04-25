using BoringGames.Shared.Enums;
using System;
using System.Runtime.Serialization;

namespace BoringGames.Shared.Exceptions
{
    [Serializable]
    public class NotValidValueException : BgException
    {
        public NotValidValueException() : base() { }

        public NotValidValueException(string message) : base(message) { }

        public NotValidValueException(string message, ErrorCode errorCode) : base(message, errorCode) { }

        protected NotValidValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
