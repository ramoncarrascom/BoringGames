using BoringGames.Shared.Models;
using TicTacToe.Data;

namespace BoringGames.Core.Models.BoringToe
{
    /// <summary>
    /// Data model for returning from service
    /// </summary>
    public class BoringToeMoveResponse
    {
        /// <summary>
        /// Player data
        /// </summary>
        public Player Player { get; set; }

        /// <summary>
        /// Grid representation
        /// </summary>
        public string Grid { get; set; }

        /// <summary>
        /// Winner player
        /// </summary>
        public Player Winner { get; set; }

        /// <summary>
        /// Game over flag
        /// </summary>
        public bool GameOver { get; set; }

        /// <summary>
        /// Player must repeat
        /// </summary>
        public bool Repeat { get; set; }

        /// <summary>
        /// No args constructor
        /// </summary>
        public BoringToeMoveResponse() : this(null, null) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public BoringToeMoveResponse(Player player, IGrid grid)
        {
            Player = player;
            Grid = grid.ToString();
        }
    }
}
