using BoringGames.Core.Models.BoringToe;
using BoringGames.Core.Repositories;
using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;
using TicTacToe.Exceptions;

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
            BoringToeMoveResponseDataModel resp = null;
            Player responsePlayer = null;

            Player player = FindPlayerInDatabase(playerId, ErrorCode.PLAYER_NOT_EXISTS);
            ITicTacToe game = FindGameInDatabase(gameId, ErrorCode.GAME_NOT_EXISTS);

            try
            {
                responsePlayer = game.PlayerMove(player, new Coordinate(xCoord, yCoord));
            }
            catch (TicTacToeGameOverException)
            {
                return GenerateGameOverWinnerResponseData(tttgoe.Player, game.GetGrid());
            }
            catch (PlayerMovementException)
            {
                return GenerateRepeatUserResponseData(player, game.GetGrid());
            }
            catch (GameOverException)
            {
                return GenerateGameOverNoWinnerResponseData(game.GetGrid());
            }

            return GenerateOkNextPlayerResponseData(responsePlayer, game.GetGrid());
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
                    throw new NotValidValueException("Player not existing in database", notExistingErrorCode);
                else
                    throw;
            }

            return resp;
        }

        /// <summary>
        /// Wrapper function for player database get
        /// </summary>
        /// <param name="id">Id to find</param>
        /// <param name="notExistingErrorCode">Error code to add in NotExistingValueException</param>
        /// <returns>Player data</returns>
        private ITicTacToe FindGameInDatabase(long id, ErrorCode notExistingErrorCode)
        {
            ITicTacToe resp = null;

            try
            {
                resp = _boringToeRepository.GetGameById(id);
            }
            catch (NotExistingValueException neve)
            {
                if (neve.ErrorCode == ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE)
                    throw new NotValidValueException("Game not existing in database", notExistingErrorCode);
                else
                    throw;
            }

            return resp;
        }

        /// <summary>
        /// Generates Ok response data object
        /// </summary>
        /// <param name="player">Next player</param>
        /// <param name="grid">Grid</param>
        /// <returns>Service response data</returns>
        private BoringToeMoveResponseDataModel GenerateOkNextPlayerResponseData(Player player, IGrid grid)
        {
            BoringToeMoveResponseDataModel resp = new BoringToeMoveResponseDataModel(player, grid);
            resp.GameOver = false;
            resp.Repeat = false;
            resp.Winner = null;
            resp.Grid = grid.ToString();

            return resp;
        }

        /// <summary>
        /// Generates Ok Game Over Winner response data object
        /// </summary>
        /// <param name="player">Winner player</param>
        /// <param name="grid">Grid</param>
        /// <returns>Service response data</returns>
        private BoringToeMoveResponseDataModel GenerateGameOverWinnerResponseData(Player player, IGrid grid)
        {
            BoringToeMoveResponseDataModel resp = new BoringToeMoveResponseDataModel(player, grid);
            resp.GameOver = true;
            resp.Repeat = false;
            resp.Winner = player;
            resp.Grid = grid.ToString();

            return resp;
        }

        /// <summary>
        /// Generates Game Over no winner response data object
        /// </summary>
        /// <param name="grid">Grid</param>
        /// <returns>Service response data</returns>
        private BoringToeMoveResponseDataModel GenerateGameOverNoWinnerResponseData(IGrid grid)
        {
            BoringToeMoveResponseDataModel resp = new BoringToeMoveResponseDataModel(null, grid);
            resp.GameOver = true;
            resp.Repeat = false;
            resp.Winner = null;
            resp.Grid = grid.ToString();

            return resp;
        }

        /// <summary>
        /// Generates user repeat response data object
        /// </summary>
        /// <param name="player">Player info</param>
        /// <param name="grid">Grid</param>
        /// <returns>Service response data</returns>
        private BoringToeMoveResponseDataModel GenerateRepeatUserResponseData(Player player, IGrid grid)
        {
            BoringToeMoveResponseDataModel resp = new BoringToeMoveResponseDataModel(player, grid);
            resp.GameOver = false;
            resp.Repeat = true;
            resp.Winner = null;
            resp.Grid = grid.ToString();

            return resp;
        }
    }
}
