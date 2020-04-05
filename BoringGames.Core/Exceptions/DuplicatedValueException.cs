using BoringGames.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Exceptions
{
    public class DuplicatedValueException : BgException
    {
        public DuplicatedValueException() : base() { }

        public DuplicatedValueException(string message) : base(message) { }

        public DuplicatedValueException(string message, ErrorCode errorCode) : base(message, errorCode) { }
    }
}
