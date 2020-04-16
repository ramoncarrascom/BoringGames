using BoringGames.Shared.Contracts;
using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;

namespace TicTacToe.Data.Implementation
{
    public class TicTacToeImpl : ITicTacToe, IIdentityModel, ICloneable
    {
        public long? Id { get; set; }

        private IDictionary<CellPlayer, Player> players;
        private IGrid grid;
        private readonly Guid guidId;        

        /// <summary>
        /// Constructor
        /// </summary>
        public TicTacToeImpl()
        {
            guidId = Guid.NewGuid();
        }

        /// <summary>
        /// Private constructor. Only available to assign the readonly variable Guid
        /// </summary>
        /// <param name="GuidId">Guid id</param>
        private TicTacToeImpl(Guid GuidId)
        {
            this.guidId = GuidId;
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
                    throw;
            }            

            CellPlayer checkedPlayer = grid.Check();
            if (checkedPlayer!=CellPlayer.NONE)
            {
                Player winner;
                bool winnerPlayer = players.TryGetValue(checkedPlayer, out winner);

                if (winnerPlayer)
                    throw new TicTacToeGameOverException(winner.Name + " wins", winner, true);
                else
                    throw new NotValidStateException("There was a problem with players dictionary data", ErrorCode.OUT_OF_RANGE);
            }

            if (grid.IsFull())
                throw new GameOverException("Game Over. None wins");

            return GetNextPlayer(player);
        }

        /// <inheritdoc/>
        public Player StartGame(IGrid grid, Player playerA, Player playerB)
        {
            players = new Dictionary<CellPlayer, Player>();
            this.grid = grid;
            InitTriads(grid);

            if (playerA == null || playerB == null)
                throw new NotValidValueException("Players can't be null");

            if (playerA.Equals(playerB))
                throw new NotValidValueException("Player A must be different from Player B");

            players.Add(CellPlayer.PLAYER_A, playerA);
            players.Add(CellPlayer.PLAYER_B, playerB);

            players.TryGetValue(CellPlayer.PLAYER_A, out Player resp);

            return resp;
        }

        /// <summary>
        /// Gets the CellPlayer value for given Player object
        /// </summary>
        /// <param name="player">Player to find</param>
        /// <returns>Corresponding CellPlayer value</returns>
        private CellPlayer GetCellPlayer(Player player)
        {
            return players.FirstOrDefault(x => x.Value.Equals(player)).Key;
        }

        /// <summary>
        /// Gets the next Player for given Player object
        /// </summary>
        /// <param name="player">Player to calculate next element</param>
        /// <returns>Next Player value</returns>
        private Player GetNextPlayer(Player player)
        {
            return players.FirstOrDefault(x => !x.Value.Equals(player)).Value;
        }

        /// <summary>
        /// Checks general game status
        /// </summary>
        private void CheckGameStatus()
        {
            if (players == null || grid == null)
                throw new NotValidStateException("Game is not correctly initialized");
        }

        /// <inheritdoc/>
        public Guid GetId()
        {
            return Guid.Parse(guidId.ToString());
        }

        /// <summary>
        /// Inits triad collection for TicTacToe game
        /// </summary>
        private void InitTriads(IGrid grid)
        {
            List<Triad> triads = new List<Triad>();

            triads.Add(new Triad(new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(0, 2)));
            triads.Add(new Triad(new Coordinate(1, 0), new Coordinate(1, 1), new Coordinate(1, 2)));
            triads.Add(new Triad(new Coordinate(2, 0), new Coordinate(2, 1), new Coordinate(2, 2)));
            triads.Add(new Triad(new Coordinate(0, 0), new Coordinate(1, 0), new Coordinate(2, 0)));
            triads.Add(new Triad(new Coordinate(0, 1), new Coordinate(1, 1), new Coordinate(2, 1)));
            triads.Add(new Triad(new Coordinate(0, 2), new Coordinate(1, 2), new Coordinate(2, 2)));
            triads.Add(new Triad(new Coordinate(0, 0), new Coordinate(1, 1), new Coordinate(2, 2)));
            triads.Add(new Triad(new Coordinate(1, 0), new Coordinate(1, 1), new Coordinate(1, 2)));
            triads.Add(new Triad(new Coordinate(2, 0), new Coordinate(1, 1), new Coordinate(0, 2)));

            grid.InitTriads(triads);
        }

        /// <summary>
        /// Clone implementation
        /// </summary>
        public object Clone()
        {
            TicTacToeImpl resp = new TicTacToeImpl(Guid.Parse(this.guidId.ToString()));

            resp.Id = this.Id;
            resp.players = new Dictionary<CellPlayer, Player>();

            if (players != null && players.Count>0)
                foreach (KeyValuePair<CellPlayer, Player> item in players)
                    resp.players.Add(item.Key, (Player) item.Value.Clone());

            resp.grid = this.grid;

            return resp;
        }

        /// <summary>
        /// Equals override
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>True if objects are the same</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is TicTacToeImpl))
                return false;

            TicTacToeImpl other = (TicTacToeImpl)obj;

            if (other.guidId.Equals(this.guidId))
                return true;
            else
                return false;
        }

        /// <summary>
        /// GetHashCode override
        /// </summary>
        /// <returns>Returns hashcode</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(guidId);
        }
    }
}
