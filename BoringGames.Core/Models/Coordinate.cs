using BoringGames.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Models
{
    /// <summary>
    /// Coordinate model. Allows storage of X/Y coordinates
    /// </summary>
    public class Coordinate
    {
        private int _X;
        private int _Y;

        /// <summary>
        /// X component of coordinate
        /// </summary>
        public int X {
            get 
            {
                return _X;
            } 
            set
            {
                if (value < int.MinValue)
                    throw new NotValidValueException("X coordinate can't be smaller than " + int.MinValue);
                if (value > int.MaxValue)
                    throw new NotValidValueException("X coordinate can't be higher than " + int.MaxValue);

                _X = value;
            }
        }

        /// <summary>
        /// Y component of coordinate
        /// </summary>
        public int Y
        {
            get
            {
                return _Y;
            }
            set
            {
                if (value < int.MinValue)
                    throw new NotValidValueException("Y coordinate can't be smaller than " + int.MinValue);
                if (value > int.MaxValue)
                    throw new NotValidValueException("Y coordinate can't be higher than " + int.MaxValue);

                _Y = value;
            }
        }

        /// <summary>
        /// Initializes coordinate with X and Y components
        /// </summary>
        /// <param name="xCoord">X component</param>
        /// <param name="yCoord">Y component</param>
        public Coordinate(int xCoord, int yCoord)
        {
            _X = xCoord;
            _Y = yCoord;
        }

        /// <summary>
        /// Initializes coordinate to (0,0)
        /// </summary>
        public Coordinate() : this(0, 0) { }

        /// <summary>
        /// ToString implementation
        /// </summary>
        /// <returns>String representation of coordinate</returns>
        public override string ToString()
        {
            return String.Format("({0},{1})", _X, _Y);
        }

        /// <summary>
        /// Equals implementation. Two coordinates are equal if they have same X and same Y values
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if coordinates are equal</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Coordinate))
                return false;

            Coordinate compare = (Coordinate)obj;

            if (compare._X == this._X && compare._Y == this._Y)
                return true;

            return false;            
        }

        /// <summary>
        /// Clones current coordinate item
        /// </summary>
        /// <returns>Returns a new Coordinate with same X and Y</returns>
        public Coordinate Clone()
        {
            return new Coordinate(_X, _Y);
        }
    }
}
