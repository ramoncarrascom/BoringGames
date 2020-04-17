using BoringGames.Core.Repositories;
using BoringGames.Core.Repositories.Implementation;
using BoringGames.Shared.Enums;
using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using NUnit.Framework;
using System;

namespace BoringGames.Core.Test.Repositories
{
    public class PlayerSetRepositoryTest
    {
        [Test]
        public void FirstPlayerAddMustReturn1()
        {
            // Given
            Player player = new Player();
            IPlayerRepository repo = new PlayerSetRepository();
            long id;

            // When
            id = repo.AddPlayer(player);

            // Then
            Assert.IsTrue(id == 1, "First player's ID must be 1");
        }

        [Test]
        public void SecondPlayerAddMustReturn2()
        {
            // Given
            Player player1 = new Player();
            Player player2 = new Player();
            IPlayerRepository repo = new PlayerSetRepository();
            long id;

            // When
            id = repo.AddPlayer(player1);
            id = repo.AddPlayer(player2);

            // Then
            Assert.IsTrue(id == 2, "Second player's ID must be 2");
        }

        [Test]
        public void IfAPlayerAlreadyExistsItMustReturnDuplicatedValueException()
        {
            // Given
            Player player1 = new Player();
            IPlayerRepository repo = new PlayerSetRepository();
            long id;

            // When
            id = repo.AddPlayer(player1);

            // Then
            DuplicatedValueException excep = Assert.Throws<DuplicatedValueException>(() => id = repo.AddPlayer(player1), "Must raise an exception if a player already exists");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_ALREADY_EXISTS_IN_DATABASE, "Exception's error code must be VALUE_ALREADY_EXISTS_IN_DATABASE");
        }

        [Test]
        public void AddedPlayerMustNotBeNull()
        {
            // Given
            IPlayerRepository repo = new PlayerSetRepository();
            long id;

            // When / Then
            NotValidValueException excep = Assert.Throws<NotValidValueException>(() => id = repo.AddPlayer(null), "Adding null player must return NotValidValueException");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.NULL_VALUE_NOT_ALLOWED, "Exception's error code must be NULL_VALUE_NOT_ALLOWED");
        }

        [Test]
        public void AfterAddingAPlayerItMustBeAccessableById()
        {
            // Given
            IPlayerRepository repo = new PlayerSetRepository();
            long id;
            Player player = new Player("TestPlayer");
            Player testPlayer;

            // When
            id = repo.AddPlayer(player);
            testPlayer = repo.GetPlayerById(id);

            // Then
            Assert.AreEqual(player, testPlayer, "Returned player must be the same as added one");
        }

        [Test]
        public void AfterAddingAPlayerItMustBeAccessableByGuid()
        {
            // Given
            IPlayerRepository repo = new PlayerSetRepository();
            long id;
            Player player = new Player("TestPlayer");
            Player testPlayer;

            // When
            id = repo.AddPlayer(player);
            testPlayer = repo.GetPlayerByGuid(player.GuidId);

            // Then
            Assert.AreEqual(player, testPlayer, "Returned player must be the same as added one");
        }

        [Test]
        public void GettingAnInexistingPlayerIdMustRaiseException()
        {
            // Given
            IPlayerRepository repo = new PlayerSetRepository();

            // When / Then
            NotExistingValueException excep = Assert.Throws<NotExistingValueException>(() => repo.GetPlayerById(1), "Getting an inexisting player must raise an exception");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Error code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }

        [Test]
        public void GettingAnInexistingPlayerGuidMustRaiseException()
        {
            // Given
            IPlayerRepository repo = new PlayerSetRepository();

            // When / Then
            NotExistingValueException excep = Assert.Throws<NotExistingValueException>(() => repo.GetPlayerByGuid(Guid.NewGuid()), "Getting an inexisting player must raise an exception");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Error code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }

        [Test]
        public void GettingADeletedPlayerMustRaiseException()
        {
            // Given
            IPlayerRepository repo = new PlayerSetRepository();
            Player player = new Player("TestPlayer");
            long id;

            // When
            id = repo.AddPlayer(player);
            repo.DeletePlayer(id);

            // When / Then
            NotExistingValueException excep = Assert.Throws<NotExistingValueException>(() => repo.GetPlayerById(id), "Getting an inexisting player must raise an exception");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Error code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }

        [Test]
        public void DeletingAnInexistingPlayerIdMustRaiseException()
        {
            // Given
            IPlayerRepository repo = new PlayerSetRepository();

            // When / Then
            NotExistingValueException excep = Assert.Throws<NotExistingValueException>(() => repo.DeletePlayer(1), "Deleting an inexisting player must raise an exception");
            Assert.AreEqual(excep.ErrorCode, ErrorCode.VALUE_NOT_EXISTING_IN_DATABASE, "Error code must be VALUE_NOT_EXISTING_IN_DATABASE");
        }
    }
}
