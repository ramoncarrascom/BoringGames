using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Models.BoringToe
{
    /// <summary>
    /// Class for movement request
    /// </summary>
    public class BoringToeMoveRequest
    {
        /// <summary>
        /// Player Id
        /// </summary>
        public long PlayerId { get; set; }
        
        /// <summary>
        /// X Coordinate
        /// </summary>
        public int XCoord { get; set; }
        
        /// <summary>
        /// Y Coordinate
        /// </summary>
        public int YCoord { get; set; }

        /// <summary>
        /// NoArgs ctor
        /// </summary>
        public BoringToeMoveRequest() 
        {
            PlayerId = 0;
            XCoord = 0;
            YCoord = 0;
        }

        /// <summary>
        /// Args ctor
        /// </summary>
        /// <param name="PlayerId">Player Id</param>
        /// <param name="XCoord">X Coord</param>
        /// <param name="YCoord">Y Coord</param>
        public BoringToeMoveRequest(long PlayerId, int XCoord, int YCoord)
        {
            this.PlayerId = PlayerId;
            this.XCoord = XCoord;
            this.YCoord = YCoord;
        }
    }
}
