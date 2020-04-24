using BoringGames.Core.Models.Players;
using BoringGames.Core.Repositories;
using BoringGames.Shared.Models;

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
        public long NewPlayer(NewPlayerRequest request)
        {
            Player player = new Player(request.Name);

            return _playerRepository.AddPlayer(player);
        }
    }
}
