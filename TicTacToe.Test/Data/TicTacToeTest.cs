using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;
using TicTacToe.Exceptions;

namespace TicTacToe.Test.Data
{
    public class TicTacToeTest
    {
        IGrid grid;
        Mock<IGrid> igridMock;

        [SetUp]
        public void GridStartup()
        {
            grid = new Grid();
            igridMock = new Mock<IGrid>();
        }

        [Test]
        public void TicTacToeHappyPath()
        {
            // Given
            Player playerA = new Player();
            Player playerB = new Player();
            ITicTacToe game = new TicTacToeImpl();

            // When
            game.StartGame(grid, playerA, playerB);
            game.PlayerMove(playerA, new Coordinate(0, 0));
            game.PlayerMove(playerA, new Coordinate(0, 1));

            // Then
            TicTacToeGameOverException rest = Assert.Throws<TicTacToeGameOverException>(() => game.PlayerMove(playerA, new Coordinate(0, 2)), "Winning the game throws TicTacToeGameOverException");
            Assert.AreEqual(rest.Player, playerA, "Winning player must be Player A");
            Assert.AreEqual(rest.Winner, true, "Winner flag must be set to true");
        }

        [Test]
        public void TicTacToeMoveBeforeStart()
        {
            // Given
            ITicTacToe game = new TicTacToeImpl();
            Player nextPlayer;

            // When/Then
            Assert.Throws<NotValidStateException>(() => nextPlayer = game.PlayerMove(new Player(), new Coordinate(0, 0)), "A movement before initialization must throw NotValidStateException");
        }

        [Test]
        public void StartGameAndPlayerMoveMustReturnNextPlayer()
        {
            // Given
            Player playerA = new Player();
            Player playerB = new Player();
            ITicTacToe game = new TicTacToeImpl();
            Player firstPlayer;
            Player nextPlayer;

            // When
            firstPlayer = game.StartGame(grid, playerA, playerB);
            nextPlayer = game.PlayerMove(firstPlayer, new Coordinate(0, 0));

            // Then
            Assert.IsTrue(firstPlayer.Equals(playerA) || firstPlayer.Equals(playerB), "First player must be Player A or Player B");
            Assert.IsFalse(firstPlayer.Equals(nextPlayer), "First player must be different from next player");
        }

        [Test]
        public void PlayerMoveMustActivateCorrectCoordinateInGrid()
        {
            // Given
            Player playerA = new Player();
            Player playerB = new Player();
            ITicTacToe game = new TicTacToeImpl();
            IGrid grid;

            // When
            game.StartGame(this.grid, playerA, playerB);
            game.PlayerMove(playerA, new Coordinate(0, 0));
            game.PlayerMove(playerA, new Coordinate(0, 1));
            game.PlayerMove(playerA, new Coordinate(1, 0));
            grid = game.GetGrid();

            // Then
            Assert.That(grid.GetGrid()[0, 0].GetStatus() == CellPlayer.PLAYER_A, "Cell must be assigned to Player A");
            Assert.That(grid.GetGrid()[0, 1].GetStatus() == CellPlayer.PLAYER_A, "Cell must be assigned to Player A");
            Assert.That(grid.GetGrid()[0, 2].GetStatus() == CellPlayer.NONE, "Cell must not be assigned");
            Assert.That(grid.GetGrid()[1, 0].GetStatus() == CellPlayer.PLAYER_A, "Cell must be assigned to Player A");
            Assert.That(grid.GetGrid()[1, 1].GetStatus() == CellPlayer.NONE, "Cell must not be assigned");
            Assert.That(grid.GetGrid()[1, 2].GetStatus() == CellPlayer.NONE, "Cell must not be assigned");
            Assert.That(grid.GetGrid()[2, 0].GetStatus() == CellPlayer.NONE, "Cell must not be assigned");
            Assert.That(grid.GetGrid()[2, 1].GetStatus() == CellPlayer.NONE, "Cell must not be assigned");
            Assert.That(grid.GetGrid()[2, 2].GetStatus() == CellPlayer.NONE, "Cell must not be assigned");
        }

        [Test]
        public void MovementPlayerMustMatchInitializedOnes()
        {
            // Given
            Player playerA = new Player();
            Player playerB = new Player();
            ITicTacToe game = new TicTacToeImpl();
            Player firstPlayer;

            // When
            firstPlayer = game.StartGame(grid, playerA, playerB);

            // Then
            Assert.IsTrue(firstPlayer.Equals(playerA) || firstPlayer.Equals(playerB), "First player must be Player A or Player B");
        }

        [Test]
        public void PlayerAMustBeDifferentFromPlayerB()
        {
            // Given
            Player player = new Player();
            ITicTacToe game = new TicTacToeImpl();

            // When/Then
            Assert.Throws<NotValidValueException>(() => game.StartGame(grid, player, player), "Initializing with same player must return exception");
        }

        [Test]
        public void PlayersMustNotBeNull()
        {
            // Given
            Player player = new Player();
            ITicTacToe game = new TicTacToeImpl();

            // When/Then
            Assert.Throws<NotValidValueException>(() => game.StartGame(grid, null, player), "If a player is null on initialization, must return exception");
            Assert.Throws<NotValidValueException>(() => game.StartGame(grid, player, null), "If a player is null on initialization, must return exception");
        }

        [Test]
        public void InexistingPlayerMustThrowException()
        {
            // Given
            Player playerA = new Player();
            Player playerB = new Player();
            Player other = new Player();
            ITicTacToe game = new TicTacToeImpl();

            // When
            game.StartGame(grid, playerA, playerB);

            // Then
            Assert.Throws<NotValidValueException>(() => game.PlayerMove(other, new Coordinate(0, 0)), "Move must return an exception is player is not in initialization");
        }

        [Test]
        public void SameMovementMustThrowPlayerMovementExceptionWithMustRetry()
        {
            // Given
            Player playerA = new Player();
            Player playerB = new Player();
            Player other = new Player();
            ITicTacToe game = new TicTacToeImpl();

            // When
            game.StartGame(grid, playerA, playerB);
            game.PlayerMove(playerA, new Coordinate(0, 0));

            // Then
            PlayerMovementException pme = Assert.Throws<PlayerMovementException>(() => game.PlayerMove(playerB, new Coordinate(0, 0)), "If the movement has been already made, must raise an exception");
            Assert.AreEqual(pme.ErrorCode, ErrorCode.MOVEMENT_ERROR_MUST_RETRY, "Exception must have MOVEMENT_ERROR_MUST_RETRY");
        }

        [Test]
        public void TicTacToeImplMustHaveGuidId()
        {
            // Given
            ITicTacToe game = new TicTacToeImpl();

            // When / Then
            Assert.DoesNotThrow(() => Guid.Parse(game.GetId().ToString()), "Game's GuidId must be a Guid");
        }

        [Test]
        public void PlayerMoveMustSpreadExceptionWhenGridSetReturnsNotValidStateExceptionWithUnknownErrorCode()
        {
            // Given
            ITicTacToe game = new TicTacToeImpl();
            Player playerA = new Player();
            Player playerB = new Player();
            igridMock.Setup(m => m.Set(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CellPlayer>())).Throws(new NotValidStateException("", ErrorCode.UNKNOWN));

            // When
            game.StartGame(igridMock.Object, playerA, playerB);

            // Then
            NotValidStateException exc = Assert.Throws<NotValidStateException>(() => game.PlayerMove(playerA, new Coordinate(0, 0)), "PlayerMove must raise NotValidStateException");
            Assert.AreEqual(exc.ErrorCode, ErrorCode.UNKNOWN, "Exception must have UNKNOWN error code");
        }

        [Test]
        public void PlayerMoveMustReturnAnExceptionIfGridCheckReturnsNotValidPlayerValue()
        {
            // Given
            ITicTacToe game = new TicTacToeImpl();
            Player playerA = new Player();
            Player playerB = new Player();
            igridMock.Setup(m => m.Check()).Returns(CellPlayer.TEST_OTHER_PLAYER);

            // When
            game.StartGame(igridMock.Object, playerA, playerB);

            // Then
            NotValidStateException exc = Assert.Throws<NotValidStateException>(() => game.PlayerMove(playerA, new Coordinate(0, 0)), "PlayerMove must raise NotValidStateException");
            Assert.AreEqual(exc.ErrorCode, ErrorCode.OUT_OF_RANGE, "Exception must have OUT_OF_RANGE error code");
        }
        
        [Test]
        public void GridIsFullMustRaiseAGameOverException()
        {
            // Given
            ITicTacToe game = new TicTacToeImpl();
            Player playerA = new Player();
            Player playerB = new Player();
            igridMock.Setup(m => m.IsFull()).Returns(true);
            igridMock.Setup(m => m.Check()).Returns(CellPlayer.NONE);

            // When
            game.StartGame(igridMock.Object, playerA, playerB);

            // Then
            Assert.Throws<GameOverException>(() => game.PlayerMove(playerA, new Coordinate(0, 0)), "PlayerMove must raise GameOverException");
        }
    }
}
