using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using System;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;
using TicTacToe.Exceptions;

namespace BoringGames.Txt.Games
{
    /// <summary>
    /// BoringToe main game
    /// </summary>
    public class BoringToe : IBoringGame
    {
        private readonly ITicTacToe game;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        /// <summary>
        /// Constructor
        /// </summary>
        public BoringToe()
        {
            this.game = new TicTacToeImpl();
            this.player1 = new Player();
            this.player2 = new Player();
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
                    Console.WriteLine(game.GetGrid().StringGrid() + "\n");
                    try
                    {

                        currentPlayer = game.PlayerMove(currentPlayer, GetPlayersCoordinates(currentPlayer));

                    } catch (PlayerMovementException pme)
                    {
                        if (pme.ErrorCode == ErrorCode.MOVEMENT_ERROR_MUST_RETRY)
                            Console.WriteLine(pme.Message);
                        else
                            throw pme;
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
        private void ShowWelcome()
        {
            Console.WriteLine("Welcome to BoringToe");
            Console.WriteLine("--------------------");
        }

        /// <summary>
        /// Configures players
        /// </summary>
        private void ConfigurePlayers()
        {
            Console.Write("Please insert Player 1 name (Default: 'Player 1'): ");
            player1.Name = Console.ReadLine();
            if (player1.Name.Length == 0)
                player1.Name = "Player 1";

            Console.Write("And now insert Player 2 name (Default: 'Player 2'): ");
            player2.Name = Console.ReadLine();
            if (player2.Name.Length == 0)
                player2.Name = "Player 2";

            Console.WriteLine("Anytime you can use q to quit");

            currentPlayer = game.StartGame(player1, player2);
        }

        /// <summary>
        /// Gets Player's coordinates
        /// </summary>
        /// <param name="player">Current player</param>
        /// <returns>New Coordinate object with player's coordinates</returns>
        private Coordinate GetPlayersCoordinates(Player player)
        {
            int X = GetNumber(player.Name + " set horizontal coordinate (0..2) ", 0, 2);
            int Y = GetNumber(player.Name + " set vertical coordinate (0..2) ", 0, 2);

            return new Coordinate(X, Y);
        }

        /// <summary>
        /// Shows a prompt and asks for a number between min and max
        /// </summary>
        /// <param name="text">Prompt text</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns>int number of user's input</returns>
        /// <exception cref="UserCancelException">Thrown when user answers Q</exception>
        private int GetNumber(string text, int min, int max)
        {
            bool itsOk = false;
            int resp = 0;

            while (!itsOk)
            {
                Console.Write(text);
                string userText = Console.ReadLine();

                if (userText.ToUpper().Equals("Q"))
                    throw new UserCancelException();

                itsOk = int.TryParse(userText, out resp);

                if (itsOk)
                    if (!(resp >= min && resp <= max))
                        itsOk = false;

                if (!itsOk)
                    Console.WriteLine("Oops... That's not a correct answer");
            }

            return resp;
        }
    }
}
