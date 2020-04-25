namespace BoringGames.Txt.Helper
{
    /// <summary>
    /// Contract for Console Helper class
    /// </summary>
    public interface IConsoleHelper
    {
        /// <summary>
        /// Gets user input from console showing a message
        /// </summary>
        /// <param name="Message">Message to display</param>
        /// <returns>String containing user's input</returns>
        string ReadLnMessage(string Message);

        /// <summary>
        /// Shows a prompt and asks for a number between min and max
        /// </summary>
        /// <param name="text">Prompt text</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <returns>int number of user's input</returns>
        /// <exception cref="UserCancelException">Thrown when user answers Q</exception>
        int GetNumber(string text, int min, int max);
    }
}
