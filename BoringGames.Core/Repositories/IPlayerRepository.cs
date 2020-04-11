using BoringGames.Shared.Models;
using System;

namespace BoringGames.Core.Repositories
{
    /// <summary>
    /// Player repository contract
    /// </summary>
    public interface IPlayerRepository
    {
        /// <summary>
        /// Adds a new player to the repository
        /// </summary>
        /// <param name="name">Player's data</param>
        /// <returns>New player's Id in repository</returns>
        long AddPlayer(Player player);

        /// <summary>
        /// Removes a player from the repository
        /// </summary>
        /// <param name="id">Player Id to remove</param>
        void DeletePlayer(long id);

        /// <summary>
        /// Gets referenced player info
        /// </summary>
        /// <param name="guid">Player's guid identification</param>
        /// <returns>Returns player's info</returns>
        Player GetPlayerByGuid(Guid guid);

        /// <summary>
        /// Gets referenced player info
        /// </summary>
        /// <param name="id">Player's id identification in repository</param>
        /// <returns>Returns player's info</returns>
        Player GetPlayerById(long id);
    }
}
