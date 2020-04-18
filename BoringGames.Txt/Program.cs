using BoringGames.Shared.Exceptions;
using BoringGames.Txt.Games;
using BoringGames.Txt.Games.BoringToeHelper;
using BoringGames.Txt.Games.BoringToeHelper.Implementation;
using BoringGames.Txt.Helper;
using BoringGames.Txt.Helper.Implementation;
using System;

namespace BoringGames.Txt
{
    /// <summary>
    /// Main program
    /// </summary>
    class Program
    {
        private IBoringGame game;

        /// <summary>
        /// Constructor
        /// </summary>
        protected Program() { }

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program p = new Program();

            p.Welcome();

            try
            {
                IConsoleWrapper cwrap = new ConsoleWrapper();
                IConsoleHelper chelp = new ConsoleHelper(cwrap);
                IBoringToeHelper bhelp = new BoringToeHelper(chelp);
                p.game = new BoringToe(bhelp);
                p.game.Run();
            } catch (BgException bge)
            {
                Console.WriteLine("BoringGamesException - " + bge.Message);
            } catch (Exception e)
            {
                Console.WriteLine("Exception - " + e.Message);
            }

        }

        /// <summary>
        /// Welcome message
        /// </summary>
        private void Welcome()
        {
            Console.WriteLine("Welcome to Boring Games 0.1");
            Console.WriteLine("---------------------------");
        }
    }
}
