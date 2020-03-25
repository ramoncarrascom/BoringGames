using BoringGames.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Test.Models
{
    public class PlayerTest
    {
        [Test]
        public void NewPlayerMustHaveGuidId()
        {
            // Given
            Player player;

            // When
            player = new Player();

            // Then
            Assert.IsNotNull(player.Id, "Player Id can't be null");
            Assert.DoesNotThrow(() => Guid.Parse(player.Id.ToString()), "Player Id must be a valid Guid");
        }

        [Test]
        public void PlayersPointsMustBe0()
        {
            // Given
            Player player;

            // When
            player = new Player();

            // Then
            Assert.IsTrue(player.Points == 0, "Player's points must be Zero in the begining");
        }

        [Test]
        public void ConstructorFirstParameterMustBePlayersName()
        {
            // Given
            string name = "MyName";
            Player player;

            // When
            player = new Player(name);

            // Then
            Assert.AreEqual(player.Name, name, "Player's name must match the first constructor's parameter");
        }

        [Test]
        public void ToStringMustMatchPlayersName()
        {
            // Given
            string name = "MyName";
            Player player;

            // When
            player = new Player(name);

            // Then
            Assert.AreEqual(player.ToString(), name, "Player's ToString must match player's name");
        }

        [Test]
        public void EqualsMustFailIfTwoPlayersHaveDifferentId()
        {
            // Given/When
            Player player1 = new Player();
            Player player2 = new Player();

            // Then
            Assert.AreNotEqual(player1.Id.ToString(), player2.Id.ToString(), "Player Ids must be different");
            Assert.IsFalse(player1.Equals(player2), "Players with different Id can't be Equal");
        }

        [Test]
        public void ClonedPlayersMustHaveSameIdSamePointsAndSameName()
        {
            // Given
            string name = "MyName";
            int points = 100;
            Player player1 = new Player(name);
            player1.Points = points;

            // When
            Player player2 = player1.Clone();

            // Then
            Assert.AreEqual(player1.Id.ToString(), player2.Id.ToString(), "Cloned player Ids must be same");
            Assert.AreEqual(player2.Name, name, "Cloned player Name must be same");
            Assert.AreEqual(player2.Points, points, "Cloned player Points must be same");
        }

        [Test]
        public void ClonedPlayersMustBeEqual()
        {
            // Given
            Player player1 = new Player();

            // When
            Player player2 = player1.Clone();

            // Then
            Assert.IsTrue(player1.Equals(player2), "Cloned player must be Equal to original player");
        }
    }
}
