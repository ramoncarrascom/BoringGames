using BoringGames.Shared.Enums;
using System;
using System.Runtime.Serialization;

namespace BoringGames.Shared.Exceptions
{
    [Serializable]
    public class RepositoryException : BgException
    {
        public RepositoryException() : base() { }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, ErrorCode errorCode) : base(message, errorCode) { }

        protected RepositoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
