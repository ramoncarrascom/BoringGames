namespace BoringGames.Txt.Games.BoringToeHelper
{
    /// <summary>
    /// Contract for Boring Toe Helper
    /// </summary>
    public interface IBoringToeHelper
    {
        /// <summary>
        /// Gets player A name
        /// </summary>
        /// <returns></returns>
        string GetPlayerAName();

        /// <summary>
        /// Gets player B name
        /// </summary>
        /// <returns></returns>
        string GetPlayerBName();

        /// <summary>
        /// Gets X Coordinate
        /// </summary>
        /// <returns>Int containing coordinate</returns>
        int GetXCoordinate(string playerName);

        /// <summary>
        /// Gets Y Coordinate
        /// </summary>
        /// <returns>Int containing coordinate</returns>
        int GetYCoordinate(string playerName);
    }
}
