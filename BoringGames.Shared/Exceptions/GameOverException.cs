using System;
using System.Runtime.Serialization;

namespace BoringGames.Shared.Exceptions
{
    [Serializable]
    public class GameOverException : BgException
    {
        public GameOverException() : base() { }

        public GameOverException(string message) : base(message) { }

        protected GameOverException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
