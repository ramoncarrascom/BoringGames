using BoringGames.Core.Enums;
using BoringGames.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Data.Implementation
{
    /// <summary>
    /// Grid implementation
    /// </summary>
    public class Grid : IGrid
    {
        /// <summary>
        /// Internal grid array
        /// </summary>
        private ICell[,] gridArray;

        /// <summary>
        /// Max X size
        /// </summary>
        private readonly int MAX_X = 3;

        /// <summary>
        /// Max Y size
        /// </summary>
        private readonly int MAX_Y = 3;

        /// <summary>
        /// Constructor
        /// </summary>
        public Grid()
        {
            Init();
        }

        /// <inheritdoc/>
        public CellPlayer Check()
        {
            // Row0 check
            if (gridArray[0, 0].GetStatus() == gridArray[1, 0].GetStatus() &&
                gridArray[0, 0].GetStatus() == gridArray[2, 0].GetStatus() &&
                (gridArray[0, 0].GetStatus() == CellPlayer.PLAYER_A || gridArray[0, 0].GetStatus() == CellPlayer.PLAYER_B))
                return gridArray[0, 0].GetStatus();

            // Row1 check
            if (gridArray[0, 1].GetStatus() == gridArray[1, 1].GetStatus() &&
                gridArray[0, 1].GetStatus() == gridArray[2, 1].GetStatus() &&
                (gridArray[0, 1].GetStatus() == CellPlayer.PLAYER_A || gridArray[0, 1].GetStatus() == CellPlayer.PLAYER_B))
                return gridArray[0, 1].GetStatus();

            // Row2 check
            if (gridArray[0, 2].GetStatus() == gridArray[1, 2].GetStatus() &&
                gridArray[0, 2].GetStatus() == gridArray[2, 2].GetStatus() &&
                (gridArray[0, 2].GetStatus() == CellPlayer.PLAYER_A || gridArray[0, 2].GetStatus() == CellPlayer.PLAYER_B))
                return gridArray[0, 2].GetStatus();

            // Col0 check
            if (gridArray[0, 0].GetStatus() == gridArray[0, 1].GetStatus() &&
                gridArray[0, 0].GetStatus() == gridArray[0, 2].GetStatus() &&
                (gridArray[0, 0].GetStatus() == CellPlayer.PLAYER_A || gridArray[0, 0].GetStatus() == CellPlayer.PLAYER_B))
                return gridArray[0, 0].GetStatus();

            // Col1 check
            if (gridArray[1, 0].GetStatus() == gridArray[1, 1].GetStatus() &&
                gridArray[1, 0].GetStatus() == gridArray[1, 2].GetStatus() &&
                (gridArray[1, 0].GetStatus() == CellPlayer.PLAYER_A || gridArray[1, 0].GetStatus() == CellPlayer.PLAYER_B))
                return gridArray[1, 0].GetStatus();

            // Col2 check
            if (gridArray[2, 0].GetStatus() == gridArray[2, 1].GetStatus() &&
                gridArray[2, 0].GetStatus() == gridArray[2, 2].GetStatus() &&
                (gridArray[2, 0].GetStatus() == CellPlayer.PLAYER_A || gridArray[2, 0].GetStatus() == CellPlayer.PLAYER_B))
                return gridArray[2, 0].GetStatus();

            // Diag0 check
            if (gridArray[0, 0].GetStatus() == gridArray[1, 1].GetStatus() &&
                gridArray[0, 0].GetStatus() == gridArray[2, 2].GetStatus() &&
                (gridArray[0, 0].GetStatus() == CellPlayer.PLAYER_A || gridArray[0, 0].GetStatus() == CellPlayer.PLAYER_B))
                return gridArray[0, 0].GetStatus();

            // Diag1 check
            if (gridArray[2, 0].GetStatus() == gridArray[1, 1].GetStatus() &&
                gridArray[2, 0].GetStatus() == gridArray[0, 2].GetStatus() &&
                (gridArray[2, 0].GetStatus() == CellPlayer.PLAYER_A || gridArray[2, 0].GetStatus() == CellPlayer.PLAYER_B))
                return gridArray[2, 0].GetStatus();

            return CellPlayer.NONE;

        }

        /// <inheritdoc/>
        public ICell[,] GetGrid()
        {
            ICell[,] resp = new ICell[MAX_X,MAX_Y];

            for (int i = 0; i < MAX_X; i++)
            {
                for (int j = 0; j < MAX_Y; j++)
                {
                    resp[i, j] = gridArray[i, j].Clone();
                }
            }

            return resp;
        }

        /// <inheritdoc/>
        public void Init()
        {
            gridArray = new Cell[MAX_X,MAX_Y];

            for (int i = 0; i < MAX_X; i++)
            {
                for (int j = 0; j < MAX_Y; j++)
                {
                    gridArray[i, j] = new Cell();
                }
            }
        }

        /// <inheritdoc/>
        public void Set(int xCoord, int yCoord, CellPlayer player)
        {
            if (xCoord > (MAX_X - 1) || xCoord < 0)
                throw new NotValidValueException(String.Format("xCoord must be between 0 and {0}", MAX_X - 1));

            if (yCoord > (MAX_Y - 1) || yCoord < 0)
                throw new NotValidValueException(String.Format("yCoord must be between 0 and {0}", MAX_Y - 1));

            gridArray[xCoord, yCoord].SetStatus(player);
        }
    }
}
