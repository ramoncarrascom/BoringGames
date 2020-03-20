using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Exceptions
{
    public class NotValidStateException : BgException
    {
        public NotValidStateException() : base() { }

        public NotValidStateException(string message) : base(message) { }
    }
}
