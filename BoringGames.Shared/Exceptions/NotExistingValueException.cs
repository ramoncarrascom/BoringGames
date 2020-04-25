using BoringGames.Shared.Enums;
using System;
using System.Runtime.Serialization;

namespace BoringGames.Shared.Exceptions
{
    [Serializable]
    public class NotExistingValueException : BgException
    {
        public NotExistingValueException() : base() { }

        public NotExistingValueException(string message) : base(message) { }

        public NotExistingValueException(string message, ErrorCode errorCode) : base(message, errorCode) { }

        protected NotExistingValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
