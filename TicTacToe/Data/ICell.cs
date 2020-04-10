using BoringGames.Shared.Enums;
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
        /// <exception cref="NotValidStateException">The current status of the cell isn't consistent with the made request</exception>
        /// <exception cref="NotValidValueException">Requested status isn't valid for the current status of the cell</exception>
        public void SetStatus(CellPlayer status);

        /// <summary>
        /// Gets an exact copy of the Cell in a new object
        /// </summary>
        /// <returns>New ICell created</returns>
        public ICell Clone();
    }
}
