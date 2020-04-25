using System;

namespace BoringGames.Txt.Helper.Implementation
{
    /// <summary>
    /// Consoler Wrapper implementation
    /// </summary>
    public class ConsoleWrapper : IConsoleWrapper
    {
        /// <inheritdoc/>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
