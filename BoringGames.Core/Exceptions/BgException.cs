using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Exceptions
{
    public class BgException : Exception
    {
        public BgException() : base() { }

        public BgException(string message) : base(message) { }
    }
}
