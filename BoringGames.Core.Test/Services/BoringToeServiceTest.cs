
using BoringGames.Core.Repositories;
using BoringGames.Core.Services;
using BoringGames.Core.Services.Implementation;
using BoringGames.Shared.Models;
using Moq;
using NUnit.Framework;
using TicTacToe.Data.Implementation;

namespace BoringGames.Core.Test.Services
{
    public class BoringToeServiceTest
    {
        private Mock<IPlayerRepository> playerMock;
        private Mock<IBoringToeRepository> gameMock;

        [SetUp]
        public void SetUp()
        {
            playerMock = new Mock<IPlayerRepository>();
            gameMock = new Mock<IBoringToeRepository>();
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
        [Ignore("Test development pending", Until = "Tomorrow")]
        public void PlayerMoveMustReturnNextPlayer()
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
    }
}
