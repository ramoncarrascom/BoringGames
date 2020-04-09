using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Enums
{
    public enum ErrorCode
    {
        NOT_AVAILABLE,
        VALUE_ALREADY_EXISTS,
        OUT_OF_RANGE,
        MOVEMENT_ERROR_MUST_RETRY,
        VALUE_ALREADY_EXISTS_IN_DATABASE,
        NULL_VALUE_NOT_ALLOWED,
        VALUE_NOT_EXISTING_IN_DATABASE,
        INVALID_STATE
    }
}
