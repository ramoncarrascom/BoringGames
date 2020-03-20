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
    }
}
