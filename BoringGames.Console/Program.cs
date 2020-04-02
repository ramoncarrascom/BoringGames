using BoringGames.Core.Exceptions;
using BoringGames.Txt.Games;
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
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program p = new Program();

            p.Welcome();

            try
            {
                p.game = new BoringToe();
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
