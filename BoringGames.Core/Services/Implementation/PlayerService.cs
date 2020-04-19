using BoringGames.Core.Repositories;
using BoringGames.Shared.Models;
using System;

namespace BoringGames.Core.Services.Implementation
{
    /// <summary>
    /// Player Service implementation
    /// </summary>
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        /// <summary>
        /// Constructor
        /// </summary>        
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        /// <inheritdoc/>
        public long NewPlayer(string name)
        {
            Player player = new Player(name);

            return _playerRepository.AddPlayer(player);
        }
    }
}
