﻿using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Exceptions
{
    public class PlayerMovementException : BgException
    {
        public PlayerMovementException(string message) : base(message) { }

        public PlayerMovementException(string message, ErrorCode errorCode) : base(message, errorCode) { }
    }
}
