using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Exceptions
{
    public class NotValidValueException : BgException
    {
        public NotValidValueException() : base() { }

        public NotValidValueException(string message) : base(message) { }
    }
}
