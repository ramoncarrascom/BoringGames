namespace BoringGames.Txt.Helper
{
    /// <summary>
    /// Console Wrapper class contract
    /// </summary>
    public interface IConsoleWrapper
    {
        /// <summary>
        /// Wraps ReadLine console function
        /// </summary>
        /// <returns>String containing ReadLine result</returns>
        string ReadLine();
    }
}
