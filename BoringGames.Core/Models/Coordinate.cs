﻿using BoringGames.Core.Exceptions;
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
    }
}
