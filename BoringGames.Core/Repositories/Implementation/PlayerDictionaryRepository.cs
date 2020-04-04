using BoringGames.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Repositories.Implementation
{
    public class PlayerDictionaryRepository : IPlayerRepository
    {
        private readonly Dictionary<int, Player> _dictionary;

        public PlayerDictionaryRepository()
        {
            _dictionary = new Dictionary<int, Player>();
        }

        public long AddPlayer(Player name)
        {
            throw new NotImplementedException();
        }

        public void DeletePlayer(long id)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayerBiId(long id)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayerByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
