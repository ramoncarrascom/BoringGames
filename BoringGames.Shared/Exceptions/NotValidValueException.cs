using BoringGames.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Shared.Exceptions
{
    public class NotValidValueException : BgException
    {
        public NotValidValueException() : base() { }

        public NotValidValueException(string message) : base(message) { }

        public NotValidValueException(string message, ErrorCode errorCode) : base(message, errorCode) { }
    }
}
