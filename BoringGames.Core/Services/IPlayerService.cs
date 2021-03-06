﻿using BoringGames.Core.Models.Players;

namespace BoringGames.Core.Services
{
    /// <summary>
    /// Player service contract
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Creates a new player only by its name
        /// </summary>
        /// <param name="name">Player's name</param>
        /// <returns>Player's id in repository</returns>
        long NewPlayer(NewPlayerRequest request);
    }
}
