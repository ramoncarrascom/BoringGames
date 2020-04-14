using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Repositories.BaseClass;
using System;
using System.Linq;
using TicTacToe.Data.Implementation;

namespace BoringGames.Core.Repositories.Implementation
{
    public class BoringToeSetRepository : SetBaseRepository<TicTacToeImpl>, IBoringToeRepository
    {
        /// <inheritdoc/>
        public long AddGame(TicTacToeImpl game)
        {
            long? resp;

            if (!_set.Any(x => x.GetId().Equals(game.GetId())))
                resp = Add(game);
            else
                throw new DuplicatedValueException("Game already exists in database", ErrorCode.VALUE_ALREADY_EXISTS_IN_DATABASE);

            if (resp != null)
                return (long)resp;
            else
                throw new RepositoryException("Repository didn't return an Id", ErrorCode.INVALID_STATE);
        }

        /// <inheritdoc/>
        public void DeleteGame(long id)
        {
            base.Delete(id);
        }

        /// <inheritdoc/>
        public TicTacToeImpl GetGameByGuid(Guid guid)
        {
            TicTacToeImpl response = _set.FirstOrDefault(x => x.GetId().Equals(guid));

            if (response != null)
                return response;
            else
                throw new NotExistingValueException("Game not found", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE);
        }

        /// <inheritdoc/>
        public TicTacToeImpl GetGameById(long id)
        {
            TicTacToeImpl response = base.Get(id);

            if (response != null)
                return response;
            else
                throw new NotExistingValueException("Game not found", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE);
        }
    }
}
