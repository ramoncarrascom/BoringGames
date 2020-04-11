using BoringGames.Shared.Enums;

namespace TicTacToe.Data
{
    /// <summary>
    /// Contract for grid
    /// </summary>
    public interface IGrid
    {
        /// <summary>
        /// Sets the value for a Grid's position
        /// </summary>
        /// <param name="xCoord">X coordinate (horizontal position) from 0 to 2</param>
        /// <param name="yCoord">Y coordinate (vertical position) from 0 to 2</param>
        /// <param name="player">Player making the movement</param>
        /// <returns>Next suggested player</returns>
        public void Set(int xCoord, int yCoord, CellPlayer player);

        /// <summary>
        /// Initializes grid
        /// </summary>
        public void InitGrid();

        /// <summary>
        /// Gets the current grid
        /// </summary>
        /// <returns>Returns a copy of the current grid</returns>
        public ICell[,] GetGrid();

        /// <summary>
        /// Checks if a player has won the game
        /// </summary>
        /// <returns>Value of the winner. Returns CellPlayer.NONE if there's still no winner.</returns>
        /// <exception cref="GameOverException">Raised when all movements have been made</exception>
        public CellPlayer Check();

        /// <summary>
        /// Checks if the grid has no NONE cells
        /// </summary>
        /// <returns>True if the grid has no NONE cells, which means that all cells have a player set</returns>
        public bool IsFull();

        /// <summary>
        /// Gets a string representation of the grid
        /// </summary>
        /// <returns>Returns a string containing a graphic representation of the grid un text mode</returns>
        public string StringGrid();
    }
}
