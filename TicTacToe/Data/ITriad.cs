using BoringGames.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Data
{
    /// <summary>
    /// Sets a triad (group of 3 coordinates) 
    /// </summary>
    public interface ITriad
    {
        /// <summary>
        /// Gets the coordinates list
        /// </summary>
        /// <returns>Returns a list with the 3 coordinates</returns>
        public ICollection<Coordinate> GetCoordinates();

        /// <summary>
        /// Sets the 3 coordinates in the triad
        /// </summary>
        /// <param name="coord1">1st coordinate</param>
        /// <param name="coord2">2nd coordinate</param>
        /// <param name="coord3">3rd coordinate</param>
        public void SetCoordinates(Coordinate coord1, Coordinate coord2, Coordinate coord3);
    }
}
