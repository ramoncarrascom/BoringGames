using BoringGames.Core.Enums;
using BoringGames.Core.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data;
using TicTacToe.Data.Implementation;

namespace TicTacToe.Test.Data
{
    /// <summary>
    /// Cell unit tests
    /// </summary>
    public class CellTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenANewCellIsCreatedStatusIsNone()
        {
            // Given
            ICell testCell;
            
            // When
            testCell = new Cell();

            // Then
            Assert.IsTrue(testCell.GetStatus() == CellPlayer.NONE, "Initial cell status must be None");
        }

        [Test]
        public void WhenACellHasOwnerYouCantChangeIt()
        {
            // Given
            ICell testCell = new Cell();
            testCell.SetStatus(CellPlayer.PLAYER_A);

            // Then
            Assert.Throws<NotValidStateException>(() => testCell.SetStatus(CellPlayer.PLAYER_B), "Once a player is set, you can't change it");
        }

        [Test]
        public void CantSetValueToNone()
        {
            // Given
            ICell testCell = new Cell();
 
            // Then
            Assert.Throws<NotValidValueException>(() => testCell.SetStatus(CellPlayer.NONE), "You can only set a player, you can't set none");
        }

        [Test]
        public void CellSetStatusHappyPath()
        {
            // Given
            ICell testCell = new Cell();

            // When
            testCell.SetStatus(CellPlayer.PLAYER_A);

            // Then
            Assert.IsTrue(testCell.GetStatus() == CellPlayer.PLAYER_A, "Cell's status must be cell's setted status");
        }

        [Test]
        public void CellToStringPlayerA()
        {
            // Given
            ICell testCell = new Cell();
            testCell.SetStatus(CellPlayer.PLAYER_A);

            // When
            string data = testCell.ToString();

            // Then
            Assert.IsTrue(data.Equals("A"), "When cell's value is Player A, ToString must return A");          
        }

        [Test]
        public void CellToStringPlayerB()
        {
            // Given
            ICell testCell = new Cell();
            testCell.SetStatus(CellPlayer.PLAYER_B);

            // When
            string data = testCell.ToString();

            // Then
            Assert.IsTrue(data.Equals("B"), "When cell's value is Player A, ToString must return B");
        }

        [Test]
        public void CellToStringNoPlayer()
        {
            // Given
            ICell testCell = new Cell();
 
            // When
            string data = testCell.ToString();

            // Then
            Assert.IsTrue(data.Equals(" "), "When cell's value is None, ToString must return a space");
        }

    }
}
