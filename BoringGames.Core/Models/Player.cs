using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Models
{
    /// <summary>
    /// Player class
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Player's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Player's points
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Winner flag
        /// </summary>
        public bool Winner { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Player()
        {
            Id = Guid.NewGuid();
            Points = 0;
            Name = "";
            Winner = false;
        }

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="name">Player's name</param>
        public Player(string name) : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// ToString implementation
        /// </summary>
        /// <returns>A string with player's name</returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Equals implementation. Two players are equal if they have the same Id
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if Players are the same</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Player))
                return false;

            Player other = (Player)obj;

            if (other.Id == this.Id)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Cloning method. Returns a new player with the same data.
        /// </summary>
        /// <returns>New player with the same original data</returns>
        public Player Clone()
        {
            Player resp = new Player();

            resp.Id = Guid.Parse(this.Id.ToString());
            resp.Name = this.Name;
            resp.Points = this.Points;
            resp.Winner = this.Winner;

            return resp;
        }

        /// <summary>
        /// Get hashcode implementation
        /// </summary>
        /// <returns>Returns object's hashcode</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
