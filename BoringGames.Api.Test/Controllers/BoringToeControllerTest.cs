using BoringGames.API.Controllers;
using BoringGames.Core.Models.BoringToe;
using BoringGames.Core.Services;
using BoringGames.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TicTacToe.Data;

namespace BoringGames.Api.Test.Controllers
{
    /// <summary>
    /// BoringToe controller test
    /// </summary>
    public class BoringToeControllerTest
    {
        Mock<IBoringToeService> serviceMock;
        Mock<IGrid> gridMock;

        [SetUp]
        public void TestSetup()
        {
            serviceMock = new Mock<IBoringToeService>();
            gridMock = new Mock<IGrid>();
        }

        [Test]
        public void GamePostMustReturnCreated()
        {
            // Given
            long respData = 100;
            serviceMock.Setup(m => m.NewGame(It.IsAny<BoringToeNewGameRequest>()))
                .Returns(respData);
            BoringToeController controller = new BoringToeController(serviceMock.Object);

            // When
            ActionResult resp = controller.Post(new BoringToeNewGameRequest(1,2));

            // Then
            Assert.IsInstanceOf<CreatedResult>(resp, "Value must be if type Created");
        }

        [Test]
        public void GamePostMustReturnNewGamesIdInRepo()
        {
            // Given
            long respData = 100;
            serviceMock.Setup(m => m.NewGame(It.IsAny<BoringToeNewGameRequest>()))
                .Returns(respData);
            BoringToeController controller = new BoringToeController(serviceMock.Object);

            // When
            CreatedResult resp = controller.Post(new BoringToeNewGameRequest(1, 2)) as CreatedResult;

            // Then
            Assert.AreEqual(respData, resp.Value, "Response value must be mocked one");
            Assert.IsInstanceOf<long>(resp.Value, "Value must be if type long");
            serviceMock.Verify(v => v.NewGame(It.IsAny<BoringToeNewGameRequest>()), Times.Once, "Service's New Game must be called 1 time");
        }

        [Test]
        public void GamePutMustReturnOk()
        {
            // Given
            Player player = new Player();
            BoringToeMoveResponse respData = new BoringToeMoveResponse(player, gridMock.Object);
            respData.GameOver = true;
            respData.Repeat = false;
            respData.Winner = player;

            serviceMock.Setup(m => m.PlayerMove(It.IsAny<long>(), It.IsAny<BoringToeMoveRequest>()))
                .Returns(respData);
            BoringToeController controller = new BoringToeController(serviceMock.Object);

            // When
            ActionResult resp = controller.Put(100, new BoringToeMoveRequest(1,1,1));

            // Then
            Assert.IsInstanceOf<OkObjectResult>(resp, "Value must be if type OkObjectResult");
        }

        [Test]
        public void GamePutMustReturnGameStatus()
        {
            // Given
            Player player = new Player();
            BoringToeMoveResponse returnData = new BoringToeMoveResponse(player, gridMock.Object);
            returnData.GameOver = true;
            returnData.Repeat = false;
            returnData.Winner = player;

            serviceMock.Setup(m => m.PlayerMove(It.IsAny<long>(), It.IsAny<BoringToeMoveRequest>()))
                .Returns(returnData);
            BoringToeController controller = new BoringToeController(serviceMock.Object);

            // When
            OkObjectResult resp = controller.Put(100, new BoringToeMoveRequest(1, 1, 1)) as OkObjectResult;
            BoringToeMoveResponse respData = resp.Value as BoringToeMoveResponse;

            // Then
            Assert.IsInstanceOf<BoringToeMoveResponse>(resp.Value, "Value must be if type BoringToeMoveResponse");
            Assert.AreEqual(returnData.GameOver, respData.GameOver, "Responses GameOver flag must be mocked one");
            Assert.AreEqual(returnData.Repeat, respData.Repeat, "Responses Repeat flag must be mocked one");
            Assert.AreEqual(player, respData.Winner, "Responses Winner must be mocked player");
            Assert.AreEqual(player, respData.Player, "Responses Winner must be mocked player");
            serviceMock.Verify(v => v.PlayerMove(It.IsAny<long>(), It.IsAny<BoringToeMoveRequest>()), Times.Once, "Service's Player Move must be called 1 time");
        }
    }
}
