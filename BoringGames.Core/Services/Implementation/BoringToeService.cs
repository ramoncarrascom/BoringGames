using BoringGames.Core.Models.BoringToe;
using BoringGames.Core.Repositories;
using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using System;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;

namespace BoringGames.Core.Services.Implementation
{
    /// <summary>
    /// Boring Toe Service implementation
    /// </summary>
    public class BoringToeService : IBoringToeService
    {
        private readonly IBoringToeRepository _boringToeRepository;
        private readonly IPlayerRepository _playerRepository;
        
        /// <summary>
        /// Constructor
        /// </summary>        
        public BoringToeService(IBoringToeRepository boringToeRepository, IPlayerRepository playerRepository)
        {
            _boringToeRepository = boringToeRepository;
            _playerRepository = playerRepository;
        }

        /// <inheritdoc/>
        public long NewGame(long playerAId, long playerBId)
        {
            Player playerA = FindPlayerInDatabase(playerAId, ErrorCode.PLAYER_A_NOT_EXISTING);
            Player playerB = FindPlayerInDatabase(playerBId, ErrorCode.PLAYER_B_NOT_EXISTING);
            ITicTacToe game = new TicTacToeImpl();
            IGrid grid = new Grid();

            game.StartGame(grid, playerA, playerB);
            return _boringToeRepository.AddGame((TicTacToeImpl) game);            
        }

        /// <inheritdoc/>
        public BoringToeMoveResponseDataModel PlayerMove(long gameId, long playerId, int xCoord, int yCoord)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wrapper function for player database get
        /// </summary>
        /// <param name="id">Id to find</param>
        /// <param name="notExistingErrorCode">Error code to add in NotExistingValueException</param>
        /// <returns>Player data</returns>
        private Player FindPlayerInDatabase(long id, ErrorCode notExistingErrorCode)
        {
            Player resp = null;

            try
            {
                resp = _playerRepository.GetPlayerById(id);
            }
            catch (NotExistingValueException neve)
            {
                if (neve.ErrorCode == ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE)
                    throw new NotExistingValueException("Player not existing in database", notExistingErrorCode);
                else
                    throw;
            }

            return resp;
        }
    }
}
