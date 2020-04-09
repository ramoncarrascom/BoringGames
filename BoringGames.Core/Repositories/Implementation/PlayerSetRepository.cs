using BoringGames.Core.Enums;
using BoringGames.Core.Exceptions;
using BoringGames.Core.Models;
using BoringGames.Core.Repositories.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoringGames.Core.Repositories.Implementation
{
    public class PlayerSetRepository : SetBaseRepository<Player>, IPlayerRepository
    {
        /// <inheritdoc/>
        public long AddPlayer(Player player)
        {
            long? resp;

            if (_set.Count(x => x.GuidId.Equals(player.GuidId)) == 0)
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
            Player response = _set.Where(x => x.GuidId.Equals(guid)).FirstOrDefault();

            if (response != null)
                return response;
            else
                throw new NotExistingValueException("Player not found", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE);
        }
    }
}
