using BoringGames.Shared.Exceptions;
using System;

namespace BoringGames.Txt.Helper.Implementation
{
    /// <summary>
    /// Implementation for console helper
    /// </summary>
    public class ConsoleHelper : IConsoleHelper
    {
        private readonly IConsoleWrapper _consoleWrapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="consoleWrapper">Console wrapper</param>
        public ConsoleHelper(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        /// <inheritdoc/>
        public int GetNumber(string text, int min, int max)
        {
            bool itsOk = false;
            int resp = 0;

            while (!itsOk)
            {
                string userText = ReadLnMessage(text);

                if (userText.ToUpper().Equals("Q"))
                    throw new UserCancelException();

                itsOk = int.TryParse(userText, out resp);

                if (itsOk && !(resp >= min && resp <= max))
                    itsOk = false;

                if (!itsOk)
                    Console.WriteLine("Oops... That's not a correct answer");
            }

            return resp;
        }

        /// <inheritdoc/>
        public string ReadLnMessage(string Message)
        {
            Console.Write(Message);
            return _consoleWrapper.ReadLine();
        }
    }
}
