namespace BoringGames.Core.Models.Players
{
    /// <summary>
    /// Class for new player request
    /// </summary>
    public class NewPlayerRequest
    {
        /// <summary>
        /// Player's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// No args constructor
        /// </summary>
        public NewPlayerRequest() : this("") { }

        /// <summary>
        /// Args ctor
        /// </summary>
        /// <param name="Name">Player's name</param>
        public NewPlayerRequest(string Name)
        {
            this.Name = Name;
        }
    }
}
