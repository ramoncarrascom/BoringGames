using BoringGames.Shared.Exceptions;
using System;

namespace BoringGames.Shared.Models
{
    /// <summary>
    /// Coordinate model. Allows storage of X/Y coordinates
    /// </summary>
    public class Coordinate
    {
        private readonly int _X;
        private readonly int _Y;

        /// <summary>
        /// X component of coordinate
        /// </summary>
        public int X {
            get 
            {
                return _X;
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
        }

        /// <summary>
        /// Initializes coordinate with X and Y components
        /// </summary>
        /// <param name="xCoord">X component</param>
        /// <param name="yCoord">Y component</param>
        public Coordinate(int xCoord, int yCoord)
        {
            if (xCoord <= int.MinValue)
                throw new NotValidValueException("X coordinate can't be smaller than " + int.MinValue);
            if (xCoord >= int.MaxValue)
                throw new NotValidValueException("X coordinate can't be higher than " + int.MaxValue);
            if (yCoord <= int.MinValue)
                throw new NotValidValueException("Y coordinate can't be smaller than " + int.MinValue);
            if (yCoord >= int.MaxValue)
                throw new NotValidValueException("Y coordinate can't be higher than " + int.MaxValue);

            _X = xCoord;
            _Y = yCoord;
        }

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

        /// <summary>
        /// Hashcode override
        /// </summary>
        /// <returns>Returns coordinate hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(_X, _Y);
        }
    }
}
