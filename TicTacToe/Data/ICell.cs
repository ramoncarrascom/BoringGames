using BoringGames.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Data
{
    /// <summary>
    /// Contract for grid's cell
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Gets the cell's status
        /// </summary>
        /// <returns>Cell's owner: PlayerA, PlayerB or None</returns>
        public CellPlayer GetStatus();

        /// <summary>
        /// Sets the cell's status
        /// </summary>
        /// <param name="status">Indicates the cell's ownership: PlayerA, PlayerB or None</param>
        public void SetStatus(CellPlayer status);
    }
}
