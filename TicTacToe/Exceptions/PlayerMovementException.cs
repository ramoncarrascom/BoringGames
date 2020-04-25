using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace TicTacToe.Exceptions
{
    [Serializable]
    public class PlayerMovementException : BgException
    {
        public PlayerMovementException(string message) : base(message) { }

        public PlayerMovementException(string message, ErrorCode errorCode) : base(message, errorCode) { }

        protected PlayerMovementException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
