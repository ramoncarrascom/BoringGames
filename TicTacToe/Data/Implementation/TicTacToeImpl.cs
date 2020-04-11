using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe.Data.Implementation
{
    public class TicTacToeImpl : ITicTacToe
    {
        private IDictionary<CellPlayer, Player> players;
        private IGrid grid;
        private Guid id;

        /// <summary>
        /// Constructor
        /// </summary>
        public TicTacToeImpl()
        {
            id = Guid.NewGuid();
        }

        /// <inheritdoc/>        
        public IGrid GetGrid()
        {
            return grid;
        }

        /// <inheritdoc/>
        public Player PlayerMove(Player player, Coordinate coordinate)
        {
            CheckGameStatus();

            if (!players.Values.Contains(player))
                throw new NotValidValueException("Player " + player + " wasn't in initialization");

            try
            {
                grid.Set(coordinate.X, coordinate.Y, GetCellPlayer(player));
            } catch (NotValidStateException nvse)
            {
                if (nvse.ErrorCode == ErrorCode.VALUE_ALREADY_EXISTS)
                    throw new PlayerMovementException("This cell is already in use", ErrorCode.MOVEMENT_ERROR_MUST_RETRY);
                else
                    throw nvse;
            }            

            CellPlayer checkedPlayer = grid.Check();
            if (checkedPlayer!=CellPlayer.NONE)
            {
                Player winner;
                bool winnerPlayer = players.TryGetValue(checkedPlayer, out winner);

                if (winnerPlayer)
                    throw new TicTacToeGameOverException(winner.Name + " wins", winner, true);
                else
                    throw new NotValidStateException("There was a problem with players dictionary data");
            }

            if (grid.IsFull())
                throw new GameOverException("Game Over. None wins");

            return GetNextPlayer(player);
        }

        /// <inheritdoc/>
        public Player StartGame(Player playerA, Player playerB)
        {
            players = new Dictionary<CellPlayer, Player>();
            grid = new Grid();

            if (playerA == null || playerB == null)
                throw new NotValidValueException("Players can't be null");

            if (playerA.Equals(playerB))
                throw new NotValidValueException("Player A must be different from Player B");

            players.Add(CellPlayer.PLAYER_A, playerA);
            players.Add(CellPlayer.PLAYER_B, playerB);

            bool result = players.TryGetValue(CellPlayer.PLAYER_A, out Player resp);
            if (!result)
                throw new NotValidStateException("Player's dictionary is not in a valid state. There was a problem retrieving player value");

            return resp;
        }

        /// <summary>
        /// Gets the CellPlayer value for given Player object
        /// </summary>
        /// <param name="player">Player to find</param>
        /// <returns>Corresponding CellPlayer value</returns>
        private CellPlayer GetCellPlayer(Player player)
        {
            return players.Where(x => x.Value.Equals(player)).FirstOrDefault().Key;
        }

        /// <summary>
        /// Gets the next Player for given Player object
        /// </summary>
        /// <param name="player">Player to calculate next element</param>
        /// <returns>Next Player value</returns>
        private Player GetNextPlayer(Player player)
        {
            return players.Where(x => !x.Value.Equals(player)).FirstOrDefault().Value;
        }

        /// <summary>
        /// Checks general game status
        /// </summary>
        private void CheckGameStatus()
        {
            if (players == null || grid == null)
                throw new NotValidStateException("Game is not correctly initialized");

            if (!players.ContainsKey(CellPlayer.PLAYER_A) || !players.ContainsKey(CellPlayer.PLAYER_B))
                throw new NotValidStateException("Players dictionary is not correctly initialized");
        }

        /// <inheritdoc/>
        public Guid GetId()
        {
            return Guid.Parse(id.ToString());
        }
    }
}
