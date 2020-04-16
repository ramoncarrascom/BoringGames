using BoringGames.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        /// Constructor
        /// </summary>
        public BoringToeMoveResponseDataModel(Player player, IGrid grid)
        {
            Player = player;
            Grid = grid;
        }
    }
}
