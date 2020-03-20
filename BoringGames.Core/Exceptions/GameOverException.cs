using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Exceptions
{
    public class GameOverException : BgException
    {
        public GameOverException() : base() { }

        public GameOverException(string message) : base(message) { }
    }
}
