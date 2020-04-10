using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Data.Implementation
{
    /// <summary>
    /// Implementation for Triad. Allows storing 3 coordinates.
    /// </summary>
    public class Triad : ITriad
    {
        /// <summary>
        /// Triad list
        /// </summary>
        private ICollection<Coordinate> triadList;

        /// <summary>
        /// Max number of items
        /// </summary>
        private readonly int MAX_ITEMS = 3;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Triad() 
        {
            triadList = new List<Coordinate>();
        }

        /// <summary>
        /// Constructor with all necessary params
        /// </summary>
        /// <param name="coord1">1st coordinate</param>
        /// <param name="coord2">2nd coordinate</param>
        /// <param name="coord3">3rd coordinate</param>
        public Triad(Coordinate coord1, Coordinate coord2, Coordinate coord3)
        {
            SetCoordinates(coord1, coord2, coord3);
        }

        /// <inheritdoc/>
        public ICollection<Coordinate> GetCoordinates()
        {
            if (triadList.Count < MAX_ITEMS)
                throw new NotValidStateException("Triad has less than " + MAX_ITEMS + " items");

            List<Coordinate> resp = new List<Coordinate>();
            foreach(Coordinate coord in triadList)
            {
                resp.Add(coord.Clone());
            }

            return resp;
        }

        /// <inheritdoc/>
        public void SetCoordinates(Coordinate coord1, Coordinate coord2, Coordinate coord3)
        {
            triadList = new List<Coordinate>();
            ListAddHelper(coord1);
            ListAddHelper(coord2);
            ListAddHelper(coord3);
        }

        /// <summary>
        /// Adds a new Coordinate item to the list
        /// </summary>
        /// <param name="item">Item to add</param>
        private void ListAddHelper(Coordinate item)
        {
            if (triadList.Contains(item))
                throw new NotValidValueException("Coordinate " + item + " already exists");

            if (triadList.Count == MAX_ITEMS)
                throw new NotValidStateException("Triad already has 3 items");

            triadList.Add(item);
        }
    }
}
