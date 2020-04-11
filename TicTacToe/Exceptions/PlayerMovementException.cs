using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;

namespace TicTacToe.Exceptions
{
    public class PlayerMovementException : BgException
    {
        public PlayerMovementException(string message) : base(message) { }

        public PlayerMovementException(string message, ErrorCode errorCode) : base(message, errorCode) { }
    }
}
