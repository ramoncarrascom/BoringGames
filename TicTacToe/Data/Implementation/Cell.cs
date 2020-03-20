using BoringGames.Core.Enums;
using BoringGames.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Data.Implementation
{
    /// <summary>
    /// Class for grid's cell
    /// </summary>
    public class Cell : ICell
    {
        /// <summary>
        /// Stores cell status: PlayerA, PlayerB or None
        /// </summary>
        private CellPlayer Status;

        /// <summary>
        /// Constructor
        /// </summary>
        public Cell()
        {
            this.Status = CellPlayer.NONE;
        }

        /// <inheritdoc/>
        public CellPlayer GetStatus()
        {
            return Status;
        }

        /// <inheritdoc/>
        public void SetStatus(CellPlayer newStatus)
        {
            if (Status != CellPlayer.NONE)
                throw new NotValidStateException();

            if (newStatus != CellPlayer.PLAYER_A && newStatus != CellPlayer.PLAYER_B)
                throw new NotValidValueException();

            this.Status = newStatus;
        }
    }
}
