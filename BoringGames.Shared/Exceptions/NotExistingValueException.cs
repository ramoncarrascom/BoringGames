﻿using BoringGames.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Shared.Exceptions
{
    public class NotExistingValueException : BgException
    {
        public NotExistingValueException() : base() { }

        public NotExistingValueException(string message) : base(message) { }

        public NotExistingValueException(string message, ErrorCode errorCode) : base(message, errorCode) { }
    }
}