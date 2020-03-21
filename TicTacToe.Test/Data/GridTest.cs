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
    public class GridTest
    {
        [Test]
        public void GridConstructorInitializesArray()
        {
            // Given
            IGrid grid = new Grid();

            // When
            ICell[,] gridArray = grid.GetGrid();

            // Then
            Assert.IsTrue(gridArray[0,0].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
            Assert.IsTrue(gridArray[0,1].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
            Assert.IsTrue(gridArray[0,2].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
            Assert.IsTrue(gridArray[1,0].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
            Assert.IsTrue(gridArray[1,1].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
            Assert.IsTrue(gridArray[1,2].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
            Assert.IsTrue(gridArray[2,0].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
            Assert.IsTrue(gridArray[2,1].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
            Assert.IsTrue(gridArray[2,2].GetStatus() == CellPlayer.NONE, "Grid init status must be None for all cells");
        }

        [Test]
        public void GridInitInitializesArray()
        {
            // Given
            IGrid grid = new Grid();
            grid.Set(0, 0, CellPlayer.PLAYER_A);
            grid.Set(0, 1, CellPlayer.PLAYER_A);
            grid.Set(0, 2, CellPlayer.PLAYER_A);
            grid.Set(1, 0, CellPlayer.PLAYER_A);
            grid.Set(1, 1, CellPlayer.PLAYER_A);
            grid.Set(1, 2, CellPlayer.PLAYER_A);
            grid.Set(2, 0, CellPlayer.PLAYER_A);
            grid.Set(2, 1, CellPlayer.PLAYER_A);
            grid.Set(2, 2, CellPlayer.PLAYER_A);


            // When
            grid.Init();
            ICell[,] gridArray = grid.GetGrid();

            // Then
            Assert.IsTrue(gridArray[0,0].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
            Assert.IsTrue(gridArray[0,1].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
            Assert.IsTrue(gridArray[0,2].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
            Assert.IsTrue(gridArray[1,0].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
            Assert.IsTrue(gridArray[1,1].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
            Assert.IsTrue(gridArray[1,2].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
            Assert.IsTrue(gridArray[2,0].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
            Assert.IsTrue(gridArray[2,1].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
            Assert.IsTrue(gridArray[2,2].GetStatus() == CellPlayer.NONE, "Grid cell must be set to None after init");
        }

        [Test]
        public void GridFunctionMustReturnACopyOfTheArray()
        {
            // Given
            IGrid grid = new Grid();            
            ICell[,] gridArray = grid.GetGrid();

            // When
            grid.Set(0, 0, CellPlayer.PLAYER_A);

            // Then
            Assert.IsFalse(gridArray[0,0].GetStatus() == grid.GetGrid()[0,0].GetStatus(), "Local grid array mustn't update grid's array");
        }

        [Test]
        public void GridSizeMustBe3x3()
        {
            // Given
            IGrid grid = new Grid();

            // When
            ICell[,] gridArray = grid.GetGrid();

            // Then
            Assert.IsTrue(gridArray.GetLength(0) == 3, "Max X size must be 3");
            Assert.IsTrue(gridArray.GetLength(1) == 3, "Max Y size must be 3");
            Assert.IsTrue(gridArray.Length == 9, "Total grid size must be 9");
        }

        [Test]
        public void SetTheCorrespondingCellMustUpdateItsValue()
        {
            // Given
            IGrid grid = new Grid();
            ICell[,] gridArray;

            // When
            grid.Set(1, 1, CellPlayer.PLAYER_A);
            gridArray = grid.GetGrid();

            // Then
            Assert.IsTrue(gridArray[1, 1].GetStatus() == CellPlayer.PLAYER_A, "Setted cell must have the setted value");
        }

        [Test]
        public void SetterCoordsMustBeInRange()
        {
            // Given
            IGrid grid = new Grid();

            // When / Then
            Assert.Throws<NotValidValueException>(() => grid.Set(-1, 0, CellPlayer.PLAYER_A), "X coordinate must be >= 0");
            Assert.Throws<NotValidValueException>(() => grid.Set(3, 0, CellPlayer.PLAYER_A), "X coordinate must be <= 2");
            Assert.Throws<NotValidValueException>(() => grid.Set(0, -1, CellPlayer.PLAYER_A), "Y coordinate must be >= 0");
            Assert.Throws<NotValidValueException>(() => grid.Set(0, 3, CellPlayer.PLAYER_A), "Y coordinate must be <= 2");
        }

        [Test]
        public void Col0CompletePlayerWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(0, 0, CellPlayer.PLAYER_A);
            grid.Set(0, 1, CellPlayer.PLAYER_A);
            grid.Set(0, 2, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.PLAYER_A, "Col0 with all cells for Player A -> Player A Wins");
        }

        [Test]
        public void Col1CompletePlayerWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(1, 0, CellPlayer.PLAYER_A);
            grid.Set(1, 1, CellPlayer.PLAYER_A);
            grid.Set(1, 2, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.PLAYER_A, "Col1 with all cells for Player A -> Player A Wins");
        }

        [Test]
        public void Col2CompletePlayerWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(2, 0, CellPlayer.PLAYER_A);
            grid.Set(2, 1, CellPlayer.PLAYER_A);
            grid.Set(2, 2, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.PLAYER_A, "Col2 with all cells for Player A -> Player A Wins");
        }

        [Test]
        public void Row0CompletePlayerWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(0, 0, CellPlayer.PLAYER_A);
            grid.Set(1, 0, CellPlayer.PLAYER_A);
            grid.Set(2, 0, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.PLAYER_A, "Row0 with all cells for Player A -> Player A Wins");
        }

        [Test]
        public void Row1CompletePlayerWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(0, 1, CellPlayer.PLAYER_A);
            grid.Set(1, 1, CellPlayer.PLAYER_A);
            grid.Set(2, 1, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.PLAYER_A, "Row1 with all cells for Player A -> Player A Wins");
        }

        [Test]
        public void Row2CompletePlayerWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(0, 2, CellPlayer.PLAYER_A);
            grid.Set(1, 2, CellPlayer.PLAYER_A);
            grid.Set(2, 2, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.PLAYER_A, "Row2 with all cells for Player A -> Player A Wins");
        }

        [Test]
        public void Diag0CompletePlayerWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(0, 0, CellPlayer.PLAYER_A);
            grid.Set(1, 1, CellPlayer.PLAYER_A);
            grid.Set(2, 2, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.PLAYER_A, "Diag0 with all cells for Player A -> Player A Wins");
        }

        [Test]
        public void Diag1CompletePlayerWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(0, 2, CellPlayer.PLAYER_A);
            grid.Set(1, 1, CellPlayer.PLAYER_A);
            grid.Set(2, 0, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.PLAYER_A, "Diag1 with all cells for Player A -> Player A Wins");
        }

        [Test]
        public void OtherCombinationNoneWins()
        {
            // Given
            IGrid grid = new Grid();

            // When
            grid.Set(0, 0, CellPlayer.PLAYER_A);
            grid.Set(1, 1, CellPlayer.PLAYER_A);
            grid.Set(2, 0, CellPlayer.PLAYER_A);
            CellPlayer res = grid.Check();

            // Then
            Assert.IsTrue(res == CellPlayer.NONE, "Other combinations -> None wins");
        }
    }
}
