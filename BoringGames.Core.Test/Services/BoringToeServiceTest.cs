
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
        private Mock<ITicTacToe> tictacMock;
        private Mock<IGrid> gridMock;

        [SetUp]
        public void SetUp()
        {
            playerMock = new Mock<IPlayerRepository>();
            gameMock = new Mock<IBoringToeRepository>();
            tictacMock = new Mock<ITicTacToe>();
            gridMock = new Mock<IGrid>();
        }

        [Test]
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
        public void NewGameExceptionMustBeThrownWhenPlayerANotExistsInDatabase()
        {
            // Given
            playerMock.SetupSequence(m => m.GetPlayerById(It.IsAny<long>()))
                .Throws(new NotExistingValueException("",ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE))
                .Returns(new Player(""));

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);

            // Then
            NotValidValueException resp = Assert.Throws<NotValidValueException>(() => service.NewGame(10, 20), "New game must raise an exception");
            Assert.AreEqual(ErrorCode.PLAYER_A_NOT_EXISTING, resp.ErrorCode, "Exception's error code must be PLAYER_A_NOT_EXISTING");
            playerMock.Verify(m => m.GetPlayerById(It.IsAny<long>()), Times.Exactly(1), "Must call 1 time to player repository get");
        }

        [Test]
        public void NewGameExceptionMustBeThrownWhenPlayerBNotExistsInDatabase()
        {
            // Given
            playerMock.SetupSequence(m => m.GetPlayerById(It.IsAny<long>()))
                .Returns(new Player(""))
                .Throws(new NotExistingValueException("", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE));

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);

            // Then
            NotValidValueException resp = Assert.Throws<NotValidValueException>(() => service.NewGame(10, 20), "New game must raise an exception");
            Assert.AreEqual(ErrorCode.PLAYER_B_NOT_EXISTING, resp.ErrorCode, "Exception's error code must be PLAYER_B_NOT_EXISTING");
            playerMock.Verify(m => m.GetPlayerById(It.IsAny<long>()), Times.Exactly(2), "Must call 2 times to player repository get");
        }

        [Test]
        public void PlayerMoveMustReturnNextPlayer()
        {
            // Given
            string gridString = "AAABBBAAA";
            gridMock.Setup(m => m.ToString())
                .Returns(gridString);
            Player respPlayer = new Player();
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Returns(respPlayer);
            tictacMock.Setup(m => m.GetGrid())
                .Returns(gridMock.Object);
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);
            playerMock.Setup(m => m.GetPlayerById(It.IsAny<long>()))
                .Returns(respPlayer);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            BoringToeMoveResponseDataModel resp = service.PlayerMove(1,1,1,1);

            // Then
            Assert.AreEqual(respPlayer, resp.Player, "Response's player must be mocked one");
            Assert.AreEqual(false, resp.GameOver, "Response's game over flag must be false");
            Assert.IsNull(resp.Winner, "Response's winner data must be null");
            Assert.AreEqual(false, resp.Repeat, "Response's repeat flag must be false");
            Assert.AreEqual(gridString, resp.Grid, "Response's grid must be mocked one");
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        public void PlayerMoveMustRetryIfPlayerMovementExceptionIsRaised()
        {
            // Given
            Player respPlayer = new Player();
            string gridString = "AAABBBAAA";
            gridMock.Setup(m => m.ToString())
                .Returns(gridString);
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Throws(new PlayerMovementException("", ErrorCode.MOVEMENT_ERROR_MUST_RETRY));
            tictacMock.Setup(m => m.GetGrid())
                .Returns(gridMock.Object);
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);
            playerMock.Setup(m => m.GetPlayerById(It.IsAny<long>()))
                .Returns(respPlayer);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            BoringToeMoveResponseDataModel resp = service.PlayerMove(1, 1, 1, 1);

            // Then
            Assert.AreEqual(respPlayer, resp.Player, "Response's player must be mocked one");
            Assert.AreEqual(false, resp.GameOver, "Response's game over flag must be false");
            Assert.IsNull(resp.Winner, "Response's winner info must be null");
            Assert.AreEqual(true, resp.Repeat, "Response's repeat flag must be true");
            Assert.AreEqual(gridString, resp.Grid, "Response's grid must be mocked one");
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        public void PlayerWinsIfGameOverWinConditionIsRaised()
        {
            // Given
            string gridString = "AAABBBAAA";
            gridMock.Setup(m => m.ToString())
                .Returns(gridString);
            Player respPlayer = new Player();
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Throws(new TicTacToeGameOverException("", respPlayer, true));
            tictacMock.Setup(m => m.GetGrid())
                .Returns(gridMock.Object);
            playerMock.SetupSequence(m => m.GetPlayerById(It.IsAny<long>()))
                .Returns(respPlayer);
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            BoringToeMoveResponseDataModel resp = service.PlayerMove(1, 1, 1, 1);

            // Then
            Assert.AreEqual(respPlayer, resp.Player, "Response's player must be mocked one");
            Assert.AreEqual(true, resp.GameOver, "Response's game over flag must be true");
            Assert.AreEqual(respPlayer, resp.Winner, "Response's winner player must be mocked one");
            Assert.AreEqual(false, resp.Repeat, "Response's repeat flag must be false");
            Assert.AreEqual(gridString, resp.Grid, "Response's grid must be mocked one");
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        public void NoneWinsIfGameOverConditionIsRaised()
        {
            // Given
            Player respPlayer = new Player();
            string gridString = "AAABBBAAA";
            gridMock.Setup(m => m.ToString())
                .Returns(gridString);
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Throws(new GameOverException(""));
            tictacMock.Setup(m => m.GetGrid())
                .Returns(gridMock.Object);
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);
            BoringToeMoveResponseDataModel resp = service.PlayerMove(1, 1, 1, 1);

            // Then
            Assert.IsNull(resp.Player, "Response's player must be null");
            Assert.AreEqual(true, resp.GameOver, "Response's game over flag must be true");
            Assert.IsNull(resp.Winner, "Response's winner must be null");
            Assert.AreEqual(false, resp.Repeat, "Response's repeat flag must be false");
            Assert.AreEqual(gridString, resp.Grid, "Response's grid must be mocked one");
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        public void IfPlayerDoesntExistInGameExceptionMustBeRethrown()
        {
            // Given            
            tictacMock.Setup(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()))
                .Throws(new NotValidValueException("",ErrorCode.PLAYER_NOT_EXISTS));
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);

            // Then
            NotValidValueException exc = Assert.Throws<NotValidValueException>(() => service.PlayerMove(1, 1, 1, 1), "Player move must raise NotValidValueException");
            Assert.AreEqual(ErrorCode.PLAYER_NOT_EXISTS, exc.ErrorCode, "Exception's code must be PLAYER_NOT_EXISTS");            
            tictacMock.Verify(m => m.PlayerMove(It.IsAny<Player>(), It.IsAny<Coordinate>()), Times.Once, "Must call game's playermove once");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        public void IfGameDoesntExistInRepoExceptionMustBeThrown()
        {
            // Given            
            playerMock.Setup(m => m.GetPlayerById(It.IsAny<long>()))
                .Returns(new Player(""));
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Throws(new NotExistingValueException("",ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE));

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);

            // Then
            NotValidValueException exc = Assert.Throws<NotValidValueException>(() => service.PlayerMove(1, 1, 1, 1), "Player move must raise NotValidValueException");
            Assert.AreEqual(ErrorCode.GAME_NOT_EXISTS, exc.ErrorCode, "Exception's code must be GAME_NOT_EXISTS");
            gameMock.Verify(m => m.GetGameById(It.IsAny<long>()), Times.Once, "Must call game repository get game once");
        }

        [Test]
        public void IfPlayerDoesntExistInRepoExceptionMustBeThrown()
        {
            // Given            
            playerMock.Setup(m => m.GetPlayerById(It.IsAny<long>()))
                .Throws(new NotExistingValueException("", ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE));
            gameMock.Setup(m => m.GetGameById(It.IsAny<long>()))
                .Returns(tictacMock.Object);

            // When
            IBoringToeService service = new BoringToeService(gameMock.Object, playerMock.Object);

            // Then
            NotValidValueException exc = Assert.Throws<NotValidValueException>(() => service.PlayerMove(1, 1, 1, 1), "Player move must raise NotValidValueException");
            Assert.AreEqual(ErrorCode.PLAYER_NOT_EXISTS, exc.ErrorCode, "Exception's code must be PLAYER_NOT_EXISTS");
        }


    }
}
