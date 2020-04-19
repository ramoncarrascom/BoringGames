using BoringGames.Core.Models.BoringToe;
using BoringGames.Core.Repositories;
using System;

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
        public long NewGame(long PlayerA, long PlayerB)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public BoringToeMoveResponseDataModel PlayerMove(long gameId, long playerId, int xCoord, int yCoord)
        {
            throw new NotImplementedException();
        }
    }
}
