using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// List with all possible triads which make a player win
        /// </summary>
        private IEnumerable<ITriad> triads;

        /// <summary>
        /// Constructor
        /// </summary>
        public Grid()
        {
            InitGrid();
            triads = new List<Triad>();
        }

        /// <inheritdoc/>
        public CellPlayer Check()
        {
            if (triads.ToList().Count == 0)
                throw new NotValidStateException("There are no triads for check");

            CellPlayer resp = CellPlayer.NONE;

            foreach(ITriad triad in triads)
            {

                foreach(Coordinate coord in triad.GetCoordinates())
                {
                    CellPlayer current = gridArray[coord.X, coord.Y].GetStatus();

                    if (current == CellPlayer.NONE)
                    {
                        resp = CellPlayer.NONE;
                        break;
                    }

                    if (resp != CellPlayer.NONE && current != resp)
                    {                        
                        resp = CellPlayer.NONE;
                        break;
                    }                        
                    else
                    {
                        resp = current;
                    }
                }

                if (resp != CellPlayer.NONE)
                    break;

            }

            return resp;
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
        public void InitGrid()
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
                throw new NotValidValueException(String.Format("xCoord must be between 0 and {0}", MAX_X - 1), ErrorCode.OUT_OF_RANGE);

            if (yCoord > (MAX_Y - 1) || yCoord < 0)
                throw new NotValidValueException(String.Format("yCoord must be between 0 and {0}", MAX_Y - 1), ErrorCode.OUT_OF_RANGE);

            gridArray[xCoord, yCoord].SetStatus(player);
        }

        /// <summary>
        /// Returns the string representation of the grid
        /// </summary>
        public override string ToString()
        {
            StringBuilder resp = new StringBuilder();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    resp.Append(gridArray[i, j]);

            return resp.ToString();
        }

        /// <inheritdoc/>
        public string StringGrid()
        {
            StringBuilder resp = new StringBuilder();
            resp.Append(String.Format("  {0}  |  {1}  |  {2}  \n", gridArray[0, 0], gridArray[1, 0], gridArray[2, 0]));
            resp.Append("-----+-----+-----\n");
            resp.Append(String.Format("  {0}  |  {1}  |  {2}  \n", gridArray[0, 1], gridArray[1, 1], gridArray[2, 1]));
            resp.Append("-----+-----+-----\n");
            resp.Append(String.Format("  {0}  |  {1}  |  {2}  \n", gridArray[0, 2], gridArray[1, 2], gridArray[2, 2]));

            return resp.ToString();
        }

        /// <inheritdoc/>
        public void InitTriads(IEnumerable<ITriad> triads)
        {
            this.triads = triads;
        }

        /// <inheritdoc/>
        public bool IsFull()
        {
            for (int i = 0; i < MAX_X; i++)
                for (int j = 0; j < MAX_Y; j++)
                    if (gridArray[i, j].GetStatus() == CellPlayer.NONE)
                        return false;

            return true;
        }
    }
}
