using BoringGames.Shared.Enums;
using System;
using System.Runtime.Serialization;

namespace BoringGames.Shared.Exceptions
{
    [Serializable]
    public class DuplicatedValueException : BgException
    {
        public DuplicatedValueException() : base() { }

        public DuplicatedValueException(string message) : base(message) { }

        public DuplicatedValueException(string message, ErrorCode errorCode) : base(message, errorCode) { }

        protected DuplicatedValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
