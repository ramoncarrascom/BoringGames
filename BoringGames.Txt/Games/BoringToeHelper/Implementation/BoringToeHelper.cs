using BoringGames.Txt.Helper;

namespace BoringGames.Txt.Games.BoringToeHelper.Implementation
{
    /// <summary>
    /// Boring Toe Helper class implementation
    /// </summary>
    public class BoringToeHelper : IBoringToeHelper
    {
        private readonly IConsoleHelper _console;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="console"></param>
        public BoringToeHelper(IConsoleHelper console)
        {
            _console = console;
        }

        /// <inheritdoc/>
        public string GetPlayerAName()
        {
            string resp = _console.ReadLnMessage("Please insert Player 1 name (Default: 'Player 1'): ");
            if (resp.Length == 0)
                resp = "Player 1";

            return resp;
        }

        /// <inheritdoc/>
        public string GetPlayerBName()
        {
            string resp = _console.ReadLnMessage("And now insert Player 2 name (Default: 'Player 2'): ");
            if (resp.Length == 0)
                resp = "Player 2";

            return resp;
        }

        /// <inheritdoc/>
        public int GetXCoordinate(string playerName)
        {
            return _console.GetNumber(playerName + " set horizontal coordinate (0..2) ", 0, 2);
        }

        /// <inheritdoc/>
        public int GetYCoordinate(string playerName)
        {
            return _console.GetNumber(playerName + " set vertical coordinate (0..2) ", 0, 2);
        }
    }
}
