using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using BoringGames.Txt.Games.BoringToeHelper;
using System;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;
using TicTacToe.Exceptions;

namespace BoringGames.Txt.Games
{
    /// <summary>
    /// BoringToe main _game
    /// </summary>
    public class BoringToe : IBoringGame
    {
        private readonly ITicTacToe _game;
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly IGrid _grid;
        private readonly IBoringToeHelper _boringToeHelper;
        private Player currentPlayer;

        /// <summary>
        /// Constructor
        /// </summary>
        public BoringToe(IBoringToeHelper boringToeHelper)
        {
            _game = new TicTacToeImpl();
            _player1 = new Player();
            _player2 = new Player();
            _grid = new Grid();
            _boringToeHelper = boringToeHelper;
        }

        /// <summary>
        /// Executes main thread
        /// </summary>
        public void Run()
        {

            ShowWelcome();
            ConfigurePlayers();

            try
            {
                while (true)
                {
                    Console.WriteLine(_game.GetGrid().StringGrid() + "\n");
                    try
                    {

                        currentPlayer = _game.PlayerMove(currentPlayer, GetPlayersCoordinates(currentPlayer));

                    } catch (PlayerMovementException pme)
                    {
                        if (pme.ErrorCode == ErrorCode.MOVEMENT_ERROR_MUST_RETRY)
                            Console.WriteLine(pme.Message);
                        else
                            throw;
                    }                    
                }
            } catch (UserCancelException)
            {
                Console.WriteLine("User Quits");
            } catch (TicTacToeGameOverException tttgoe)
            {
                Console.WriteLine(tttgoe.Message);
            } catch (GameOverException goe)
            {
                Console.WriteLine(goe.Message);
            }
        }


        /// <summary>
        /// Shows welcome messages
        /// </summary>
        protected void ShowWelcome()
        {
            Console.WriteLine("Welcome to BoringToe");
            Console.WriteLine("--------------------");
        }

        /// <summary>
        /// Configures players
        /// </summary>
        protected void ConfigurePlayers()
        {
            _player1.Name = _boringToeHelper.GetPlayerAName();
            _player2.Name = _boringToeHelper.GetPlayerBName();

            currentPlayer = _game.StartGame(_grid, _player1, _player2);
        }

        /// <summary>
        /// Gets Player's coordinates
        /// </summary>
        /// <param name="player">Current player</param>
        /// <returns>New Coordinate object with player's coordinates</returns>
        protected Coordinate GetPlayersCoordinates(Player player)
        {
            int X = _boringToeHelper.GetXCoordinate(player.Name);
            int Y = _boringToeHelper.GetYCoordinate(player.Name);

            return new Coordinate(X, Y);
        } 
 
    }
}
