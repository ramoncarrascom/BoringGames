using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using BoringGames.Shared.Repositories.BaseClass;
using System;
using System.Linq;

namespace BoringGames.Core.Repositories.Implementation
{
    public class PlayerSetRepository : SetBaseRepository<Player>, IPlayerRepository
    {
        /// <inheritdoc/>
        public long AddPlayer(Player player)
        {
            long? resp;

            if (!_set.Any(x => x.GuidId.Equals(player.GuidId)))
                resp = Add(player);
            else
                throw new DuplicatedValueException("Player already exists in database", ErrorCode.VALUE_ALREADY_EXISTS_IN_DATABASE);

            if (resp != null)
                return (long)resp;
            else
                throw new RepositoryException("Repository didn't return an Id", ErrorCode.INVALID_STATE);
        }

        /// <inheritdoc/>
        public void DeletePlayer(long id)
        {
            base.Delete(id);
        }

        /// <inheritdoc/>
        public Player GetPlayerById(long id)
        {
            Player response = base.Get(id);

            if (response != null)
                return response;
            else
                throw new NotExistingValueException("Player not found", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE);
        }

        /// <inheritdoc/>
        public Player GetPlayerByGuid(Guid guid)
        {
            Player response = _set.FirstOrDefault(x => x.GuidId.Equals(guid));

            if (response != null)
                return response;
            else
                throw new NotExistingValueException("Player not found", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE);
        }
    }
}
