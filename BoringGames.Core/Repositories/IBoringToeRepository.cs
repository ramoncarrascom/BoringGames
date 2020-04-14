using System;
using TicTacToe.Data.Implementation;

namespace BoringGames.Core.Repositories
{
    public interface IBoringToeRepository
    {
        /// <summary>
        /// Adds a new game to the repository
        /// </summary>
        /// <param name="game">Game's data</param>
        /// <returns>New game's Id in repository</returns>
        long AddGame(TicTacToeImpl game);

        /// <summary>
        /// Removes a game from the repository
        /// </summary>
        /// <param name="id">Game to remove</param>
        void DeleteGame(long id);

        /// <summary>
        /// Gets referenced game info
        /// </summary>
        /// <param name="guid">Game's guid identification</param>
        /// <returns>Returns game's info</returns>
        TicTacToeImpl GetGameByGuid(Guid guid);

        /// <summary>
        /// Gets referenced game info
        /// </summary>
        /// <param name="id">Game's id identification in repository</param>
        /// <returns>Returns game's info</returns>
        TicTacToeImpl GetGameById(long id);
    }
}
