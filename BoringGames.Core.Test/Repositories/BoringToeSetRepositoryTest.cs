using BoringGames.Core.Repositories;
using BoringGames.Core.Repositories.Implementation;
using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using NUnit.Framework;
using System;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;

namespace BoringGames.Core.Test.Repositories
{
    public class BoringToeSetRepositoryTest
    {
        [Test]
        public void FirstGameAddMustReturn1()
        {
            // Given
            ITicTacToe game = new TicTacToeImpl();
            IBoringToeRepository repo = new BoringToeSetRepository();
            long id;

            // When
            id = repo.AddGame(game);

            // Then
            Assert.IsTrue(id == 1, "First game's ID must be 1");
        }

        [Test]
        public void SecondGameAddMustReturn2()
        {
            // Given
            ITicTacToe game1 = new TicTacToeImpl();
            ITicTacToe game2 = new TicTacToeImpl();
            IBoringToeRepository repo = new BoringToeSetRepository();
            long id;

            // When
            id = repo.AddGame(game1);
            id = repo.AddGame(game2);

            // Then
            Assert.IsTrue(id == 2, "Second game's ID must be 2");
        }

        [Test]
        public void IfAGameAlreadyExistsItMustReturnDuplicatedValueException()
        {
            // Given
            ITicTacToe game1 = new TicTacToeImpl();
            IBoringToeRepository repo = new BoringToeSetRepository();
            long id;

            // When
            id = repo.AddGame(game1);

            // Then
            DuplicatedValueException excep = Assert.Throws<DuplicatedValueException>(() => id = repo.AddGame(game1), "Must raise an exception if a game already exists");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_ALREADY_EXISTS_IN_DATABASE, "Exception's error code must be VALUE_ALREADY_EXISTS_IN_DATABASE");
        }

        [Test]
        public void AddedGameMustNotBeNull()
        {
            // Given
            IBoringToeRepository repo = new BoringToeSetRepository();
            long id;

            // When / Then
            NotValidValueException excep = Assert.Throws<NotValidValueException>(() => id = repo.AddGame(null), "Adding null game must return NotValidValueException");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.NULL_VALUE_NOT_ALLOWED, "Exception's error code must be NULL_VALUE_NOT_ALLOWED");
        }

        [Test]
        public void AfterAddingAGameItMustBeAccessable()
        {
            // Given
            IBoringToeRepository repo = new BoringToeSetRepository();
            long id;
            ITicTacToe game = new TicTacToeImpl();
            ITicTacToe testGame;

            // When
            id = repo.AddGame(game);
            testGame = repo.GetGameById(id);

            // Then
            Assert.AreEqual(game, testGame, "Returned game must be the same as added one");
        }

        [Test]
        public void GettingAnInexistingGameIdMustRaiseException()
        {
            // Given
            IBoringToeRepository repo = new BoringToeSetRepository();

            // When / Then
            NotExistingValueException excep = Assert.Throws<NotExistingValueException>(() => repo.GetGameById(1), "Getting an inexisting game must raise an exception");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Error code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }

        [Test]
        public void GettingAnInexistingGameGuidMustRaiseException()
        {
            // Given
            IBoringToeRepository repo = new BoringToeSetRepository();

            // When / Then
            NotExistingValueException excep = Assert.Throws<NotExistingValueException>(() => repo.GetGameByGuid(Guid.NewGuid()), "Getting an inexisting game must raise an exception");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Error code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }

        [Test]
        public void GettingADeletedGameMustRaiseException()
        {
            // Given
            IBoringToeRepository repo = new BoringToeSetRepository();
            ITicTacToe TicTacToe = new TicTacToeImpl();
            long id;

            // When
            id = repo.AddGame(TicTacToe);
            repo.DeleteGame(id);

            // When / Then
            NotExistingValueException excep = Assert.Throws<NotExistingValueException>(() => repo.GetGameById(id), "Getting an inexisting game must raise an exception");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Error code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }

        [Test]
        public void DeletingAnInexistingGameIdMustRaiseException()
        {
            // Given
            IBoringToeRepository repo = new BoringToeSetRepository();

            // When / Then
            NotExistingValueException excep = Assert.Throws<NotExistingValueException>(() => repo.DeleteGame(1), "Deleting an inexisting game must raise an exception");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Error code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }
    }
}
