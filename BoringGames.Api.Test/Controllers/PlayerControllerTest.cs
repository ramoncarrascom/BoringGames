
using BoringGames.API.Controllers;
using BoringGames.Core.Models.Players;
using BoringGames.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BoringGames.Api.Test.Controllers
{
    /// <summary>
    /// Player controller test
    /// </summary>
    public class PlayerControllerTest
    {
        Mock<IPlayerService> playerMock;

        [SetUp]
        public void TestSetup()
        {
            playerMock = new Mock<IPlayerService>();
        }

        [Test]
        public void PlayerPostMustReturnCreated()
        {
            // Given
            long respData = 100;
            playerMock.Setup(m => m.NewPlayer(It.IsAny<NewPlayerRequest>()))
                .Returns(respData);
            PlayerController controller = new PlayerController(playerMock.Object);

            // When
            ActionResult resp = controller.Post(new NewPlayerRequest(""));

            // Then
            Assert.IsInstanceOf<CreatedResult>(resp, "Value must be if type Created");
        }

        [Test]
        public void PlayerPostMustReturnNewPlayersIdInRepo()
        {
            // Given
            long respData = 100;
            playerMock.Setup(m => m.NewPlayer(It.IsAny<NewPlayerRequest>()))
                .Returns(respData);
            PlayerController controller = new PlayerController(playerMock.Object);

            // When
            CreatedResult resp = controller.Post(new NewPlayerRequest("")) as CreatedResult;

            // Then
            Assert.AreEqual(respData, resp.Value, "Response value must be mocked one");
            Assert.IsInstanceOf<long>(resp.Value, "Value must be if type long");
            playerMock.Verify(v => v.NewPlayer(It.IsAny<NewPlayerRequest>()), Times.Once, "Service's New Player must be called 1 time");
        }
    }
}
