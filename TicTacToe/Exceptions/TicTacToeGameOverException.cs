﻿using BoringGames.Core.Exceptions;
using BoringGames.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Exceptions
{
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
    }
}