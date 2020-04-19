﻿using BoringGames.Shared.Models;
using TicTacToe.Data;

namespace BoringGames.Core.Models.BoringToe
{
    /// <summary>
    /// Data model for returning from service
    /// </summary>
    public class BoringToeMoveResponseDataModel
    {
        /// <summary>
        /// Player data
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// Grid data
        /// </summary>
        public IGrid Grid { get; set; }

        /// <summary>
        /// Winner player
        /// </summary>
        public Player Winner { get; set; }

        /// <summary>
        /// Game over flag
        /// </summary>
        public bool GameOver { get; set; }

        /// <summary>
        /// Canceled flag
        /// </summary>
        public bool Canceled { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BoringToeMoveResponseDataModel(Player player, IGrid grid)
        {
            Player = player;
            Grid = grid;
        }
    }
}
