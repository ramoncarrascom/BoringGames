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
        /// <param name="PlayerA">Player A's id</param>
        /// <param name="PlayerB">Player B's id</param>
        /// <returns></returns>
        long NewGame(long PlayerA, long PlayerB);

        /// <summary>
        /// Makes a move in the selected game for selected player
        /// </summary>
        /// <param name="gameId">Game's identification</param>
        /// <param name="playerId">Player's identification</param>
        /// <param name="xCoord">X Coordinate</param>
        /// <param name="yCoord">Y Coordinate</param>
        /// <returns>Returns next player and current grid</returns>
        BoringToeMoveResponseDataModel PlayerMove(long gameId, long playerId, int xCoord, int yCoord);
    }
}
