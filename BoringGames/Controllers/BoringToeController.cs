using BoringGames.Core.Models.BoringToe;
using BoringGames.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoringGames.API.Controllers
{
    /// <summary>
    /// BoringToe controller
    /// </summary>
    [Route("api/v1/[controller]")]
    public class BoringToeController : Controller
    {
        private readonly IBoringToeService _boringToeService;

        /// <summary>
        /// Constructor
        /// </summary>
        public BoringToeController(IBoringToeService boringToeService)
        {
            _boringToeService = boringToeService;
        }

        /// <summary>
        /// Adds a new game for requested players
        /// </summary>
        /// <param name="request">Request data</param>
        /// <returns>Returns new game's Id</returns>
        [HttpPost]
        public ActionResult Post([FromBody] BoringToeNewGameRequest request)
        {
            long resp = _boringToeService.NewGame(request);

            return Created("api/v1/BoringToe/" + resp, resp);
        }

        /// <summary>
        /// Makes a movement in selected game
        /// </summary>
        /// <param name="id">Game's Id</param>
        /// <param name="request">Request data</param>
        /// <returns>Game movement result</returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] BoringToeMoveRequest request)
        {
            return Ok(_boringToeService.PlayerMove(id, request));
        }
    }
}
