using BoringGames.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Exceptions
{
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
    }
}
