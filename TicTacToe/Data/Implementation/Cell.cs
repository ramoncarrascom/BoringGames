using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;

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
        public ICell Clone()
        {
            Cell resp = new Cell();
            resp.Status = this.Status;

            return resp;
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
                throw new NotValidStateException("Cell status must be none", ErrorCode.VALUE_ALREADY_EXISTS);

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
            }

            return resp;
        }

        
    }
}
