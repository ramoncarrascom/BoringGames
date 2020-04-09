﻿using BoringGames.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Exceptions
{
    public class RepositoryException : BgException
    {
        public RepositoryException() : base() { }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, ErrorCode errorCode) : base(message, errorCode) { }
    }
}
