using BoringGames.Core.Models.Players;
using BoringGames.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoringGames.API.Controllers
{
    /// <summary>
    /// Player controller
    /// </summary>
    [Route("api/v1/[controller]")]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        /// <summary>
        /// Adds a new player
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Long containing new player's Id</returns>
        [HttpPost]
        public ActionResult Post([FromBody] NewPlayerRequest request)
        {
            long resp = _playerService.NewPlayer(request);

            return Created("api/v1/Player/" + resp, resp);
        }
    }
}
