using BoringGames.Core.Models.Players;
using BoringGames.Core.Repositories;
using BoringGames.Core.Services;
using BoringGames.Core.Services.Implementation;
using BoringGames.Shared.Models;
using Moq;
using NUnit.Framework;

namespace BoringGames.Core.Test.Services
{
    public class PlayerServiceTest
    {
        private Mock<IPlayerRepository> mock;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IPlayerRepository>();
        }

        [Test]
        public void AddPlayerMustReturnNewGeneratedPlayersIdInRepository()
        {
            // Given
            long mockResp = 10;
            mock.Setup(m => m.AddPlayer(It.IsAny<Player>())).Returns(mockResp);
            IPlayerService testService = new PlayerService(mock.Object);

            // When
            long resp = testService.NewPlayer(new NewPlayerRequest(""));

            // Then
            Assert.AreEqual(mockResp, resp, "Returned value must match mocked one");
        }
    }
}
