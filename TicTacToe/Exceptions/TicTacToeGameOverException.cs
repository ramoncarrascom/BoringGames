using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using System;
using System.Runtime.Serialization;

namespace TicTacToe.Exceptions
{
    [Serializable]
    public class TicTacToeGameOverException : GameOverException
    {
        public Player Player { get; private set; }

        public bool Winner { get; private set; }

        public TicTacToeGameOverException(string message) : base(message)
        {
            Player = null;
            Winner = false;
        }

        public TicTacToeGameOverException(string message, Player player, bool winner) : base(message)
        {
            Player = player;
            Winner = winner;
        }

        protected TicTacToeGameOverException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
