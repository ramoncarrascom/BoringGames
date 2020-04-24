using BoringGames.Core.Models.BoringToe;

namespace BoringGames.Core.Services
{
    /// <summary>
    /// BoringToe contract service
    /// </summary>
    public interface IBoringToeService
    {
        /// <summary>
        /// Begins a new game with referenced players
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns></returns>
        long NewGame(BoringToeNewGameRequest request);

        /// <summary>
        /// Makes a move in the selected game for selected player
        /// </summary>
        /// <param name="gameId">Game's identification</param>
        /// <param name="request">Request data</param>
        /// <returns>Returns next player and current grid</returns>
        BoringToeMoveResponse PlayerMove(long gameId, BoringToeMoveRequest request);
    }
}
