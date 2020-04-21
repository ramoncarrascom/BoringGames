
using BoringGames.Core.Models.BoringToe;
using BoringGames.Core.Repositories;
using BoringGames.Core.Services;
using BoringGames.Core.Services.Implementation;
using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using Moq;
using NUnit.Framework;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;
using TicTacToe.Exceptions;

namespace BoringGames.Core.Test.Services
{
    public class BoringToeServiceTest
    {
        private Mock<IPlayerRepository> playerMock;
        private Mock<IBoringToeRepository> gameMock;
        private Mock<TicTacToeImpl> tictacMock;

        [SetUp]
        public void SetUp()
        {
            playerMock = new Mock<IPlayerRepository>();
            gameMock = new Mock<IBoringToeRepository>();
            tictacMock = new Mock<TicTacToeImpl>();
        }

        [Test]
        [Ignore("Implementation pending", Until ="Tomorrow")]
        public void NewGameMustReturnGameIdInRepo()
        {
            // Given
            long mockedGameId = 1;
            playerMock.SetupSequence(m => m.GetPlayerById(It.IsAny<long>()))
                .Returns(new Player(""))
                .Returns(new Player(""));
            gameMock.Setup(m => m.AddGame(It.IsAny<TicTacToeImpl>()))
                .Returns(mockedGameId);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            long resp = service.NewGame(10, 20);

            // Then
            Assert.AreEqual(mockedGameId, resp, "Added game Id must be mocked one");
            playerMock.Verify(m => m.GetPlayerById(It.IsAny<long>()), Times.Exactly(2), "Must call 2 times to player repository get");
            gameMock.Verify(m => m.AddGame(It.IsAny<TicTacToeImpl>()), Times.Once, "Must call game repository add game once");
        }

        [Test]
        [Ignore("Implementation pending", Until = "Tomorrow")]
        public void PlayerMoveMustReturnNextPlayer()
        {
            // Given
            Player respPlayer = new Player();
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Returns(respPlayer);
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            BoringToeMoveResponseDataModel resp = service.PlayerMove(1,1,1,1);

            // Then
            Assert.AreEqual(respPlayer, resp.Player, "Response's player must be mocked one");
            Assert.AreEqual(false, resp.GameOver, "Response's game over flag must be false");
            Assert.AreEqual(false, resp.Winner, "Response's winner flag must be false");
            Assert.AreEqual(false, resp.Repeat, "Response's repeat flag must be false");
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        [Ignore("Implementation pending", Until = "Tomorrow")]
        public void PlayerMoveMustRetryIfPlayerMovementExceptionIsRaised()
        {
            // Given
            Player respPlayer = new Player();
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Throws(new PlayerMovementException("", ErrorCode.MOVEMENT_ERROR_MUST_RETRY));
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            BoringToeMoveResponseDataModel resp = service.PlayerMove(1, 1, 1, 1);

            // Then
            Assert.AreEqual(respPlayer, resp.Player, "Response's player must be mocked one");
            Assert.AreEqual(false, resp.GameOver, "Response's game over flag must be false");
            Assert.AreEqual(false, resp.Winner, "Response's winner flag must be false");
            Assert.AreEqual(true, resp.Repeat, "Response's repeat flag must be true");
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        [Ignore("Implementation pending", Until = "Tomorrow")]
        public void PlayerWinsIfGameOverWinConditionIsRaised()
        {
            // Given
            Player respPlayer = new Player();
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Throws(new TicTacToeGameOverException("", respPlayer, true));
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            BoringToeMoveResponseDataModel resp = service.PlayerMove(1, 1, 1, 1);

            // Then
            Assert.AreEqual(respPlayer, resp.Player, "Response's player must be mocked one");
            Assert.AreEqual(true, resp.GameOver, "Response's game over flag must be true");
            Assert.AreEqual(true, resp.Winner, "Response's winner flag must be true");
            Assert.AreEqual(false, resp.Repeat, "Response's repeat flag must be false");
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        [Ignore("Implementation pending", Until = "Tomorrow")]
        public void NoneWinsIfGameOverConditionIsRaised()
        {
            // Given
            Player respPlayer = new Player();
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Throws(new GameOverException(""));
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            BoringToeMoveResponseDataModel resp = service.PlayerMove(1, 1, 1, 1);

            // Then
            Assert.IsNull(resp.Player, "Response's player must be mocked one");
            Assert.AreEqual(true, resp.GameOver, "Response's game over flag must be true");
            Assert.AreEqual(false, resp.Winner, "Response's winner flag must be false");
            Assert.AreEqual(false, resp.Repeat, "Response's repeat flag must be false");
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

    }
}
