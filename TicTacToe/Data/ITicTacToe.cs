﻿using BoringGames.Shared.Contracts;
using BoringGames.Shared.Models;
using System;

namespace TicTacToe.Data
{
    /// <summary>
    /// Contract for TicTacToe game
    /// </summary>
    public interface ITicTacToe: IIdentityModel, ICloneable
    {
        /// <summary>
        /// Starts a new game
        /// </summary>
        /// <param name="grid">Grid</param>
        /// <param name="playerA">Player A data</param>
        /// <param name="playerB">Player B data</param>
        /// <returns>First player to play</returns>
        public Player StartGame(IGrid grid, Player playerA, Player playerB);

        /// <summary>
        /// Sets the move for player
        /// </summary>
        /// <param name="player">Player who makes the move</param>
        /// <param name="coordinate">Coordinates for the move</param>
        /// <returns>Next suggested player</returns>
        /// <exception cref="TicTacToeGameOverException">Thrown when the game finishes, either when a player wins or the grid is full</exception>
        public Player PlayerMove(Player player, Coordinate coordinate);

        /// <summary>
        /// Returns the current game's grid
        /// </summary>
        /// <returns>Current grid</returns>
        public IGrid GetGrid();

        /// <summary>
        /// Returns the current game's GuidId
        /// </summary>
        /// <returns>Current game's guid</returns>
        public Guid GetId();
    }
}
