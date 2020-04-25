using BoringGames.Shared.Enums;
using System;
using System.Runtime.Serialization;

namespace BoringGames.Shared.Exceptions
{
    [Serializable]
    public class BgException : Exception
    {        
        public ErrorCode ErrorCode { get; private set; }

        public BgException() : base() 
        {
            ErrorCode = ErrorCode.NOT_AVAILABLE;
        }

        public BgException(string message) : base(message) 
        {
            ErrorCode = ErrorCode.NOT_AVAILABLE;
        }

        public BgException(string message, ErrorCode errorCode) : this(message)
        {
            ErrorCode = errorCode;
        }

        protected BgException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ErrorCode = (ErrorCode)info.GetValue("ErrorCode", typeof(ErrorCode));
        }

    }
}
