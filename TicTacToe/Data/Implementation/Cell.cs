﻿using BoringGames.Core.Enums;
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
                throw new NotValidStateException("Cell status must be none");

            if (newStatus != CellPlayer.PLAYER_A && newStatus != CellPlayer.PLAYER_B)
                throw new NotValidValueException("Only Player A or Player B can set values");

            this.Status = newStatus;
        }

        /// <summary>
        /// Cell's ToString
        /// </summary>
        /// <returns>Returns player's letter, or space if the cell isn't assigned</returns>
        public override string ToString()
        {
            string resp = "";

            switch (Status)
            {
                case CellPlayer.PLAYER_A: resp = "A";
                    break;
                case CellPlayer.PLAYER_B: resp = "B";
                    break;
                case CellPlayer.NONE: resp = " ";
                    break;
                default: throw new IndexOutOfRangeException("Current cell's status isn't supported");
            }

            return resp;
        }
    }
}
