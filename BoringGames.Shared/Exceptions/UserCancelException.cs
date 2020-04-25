using System;
using System.Runtime.Serialization;

namespace BoringGames.Shared.Exceptions
{
    [Serializable]
    public class UserCancelException : BgException
    {
        public UserCancelException() : base() { }

        protected UserCancelException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
