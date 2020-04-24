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
        /// NoArgs ctor
        /// </summary>
        public NewPlayerRequest() 
        {
            this.Name = "";
        }

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
