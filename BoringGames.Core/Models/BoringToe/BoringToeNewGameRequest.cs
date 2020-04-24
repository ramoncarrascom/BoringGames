﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Models.BoringToe
{
    /// <summary>
    /// Model for Boring Toe New Game Request
    /// </summary>
    public class BoringToeNewGameRequest
    {
        /// <summary>
        /// Player A identification in repo
        /// </summary>
        public long PlayerAId { get; set; }

        /// <summary>
        /// Player B identification in repo
        /// </summary>
        public long PlayerBId { get; set; }

        /// <summary>
        /// NoArgs ctor
        /// </summary>
        public BoringToeNewGameRequest() 
        {
            PlayerAId = 0;
            PlayerBId = 0;
        }

        /// <summary>
        /// Arguments ctor
        /// </summary>
        /// <param name="PlayerAId">Player A Id</param>
        /// <param name="PlayerBId">Player B Id</param>
        public BoringToeNewGameRequest(long PlayerAId, long PlayerBId)
        {
            this.PlayerAId = PlayerAId;
            this.PlayerBId = PlayerBId;
        }
    }
}
