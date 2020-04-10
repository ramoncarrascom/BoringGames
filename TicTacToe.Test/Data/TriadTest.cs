using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data.Implementation;

namespace TicTacToe.Test.Data
{
    public class TriadTest
    {        
        [Test]
        public void ATriadStores3CoordinatesConstructorHappyPath()
        {
            // Given
            Coordinate coord1 = new Coordinate(10, 20);
            Coordinate coord2 = new Coordinate(20, 30);
            Coordinate coord3 = new Coordinate(30, 40);

            // When
            Triad triad = new Triad(coord1, coord2, coord3);
            ICollection<Coordinate> resp = triad.GetCoordinates();

            // Then
            Assert.IsTrue(resp.Contains(coord1), "Coord1 must be in returned ICollection");
            Assert.IsTrue(resp.Contains(coord2), "Coord2 must be in returned ICollection");
            Assert.IsTrue(resp.Contains(coord3), "Coord3 must be in returned ICollection");
        }

        [Test]
        public void ATriadStores3CoordinatesSetterHappyPath()
        {
            // Given
            Coordinate coord1 = new Coordinate(10, 20);
            Coordinate coord2 = new Coordinate(20, 30);
            Coordinate coord3 = new Coordinate(30, 40);

            // When
            Triad triad = new Triad();
            triad.SetCoordinates(coord1, coord2, coord3);
            ICollection<Coordinate> resp = triad.GetCoordinates();

            // Then
            Assert.IsTrue(resp.Contains(coord1), "Coord1 must be in returned ICollection");
            Assert.IsTrue(resp.Contains(coord2), "Coord2 must be in returned ICollection");
            Assert.IsTrue(resp.Contains(coord3), "Coord3 must be in returned ICollection");
        }

        [Test]
        public void ATriadStoresOnly3CoordinatesHappyPath()
        {
            // Given
            Coordinate coord1 = new Coordinate(10, 20);
            Coordinate coord2 = new Coordinate(20, 30);
            Coordinate coord3 = new Coordinate(30, 40);

            // When
            Triad triad = new Triad(coord1, coord2, coord3);
            ICollection<Coordinate> resp = triad.GetCoordinates();

            // Then
            Assert.IsTrue(resp.Count == 3, "Triad getter must return exactly 3 coordinates");            
        }

        [Test]
        public void CoordinatesMustBeAllDistinct()
        {
            // Given
            Coordinate coord1 = new Coordinate(10, 20);
            Coordinate coord2 = new Coordinate(20, 30);
            Coordinate coord3 = new Coordinate(20, 30);

            // When
            Triad triad = new Triad();

            // Then
            Assert.Throws<NotValidValueException>(() => triad.SetCoordinates(coord1, coord2, coord3), "All coordinates must be distinct");
        }

        [Test]
        public void IfSettedAgainCoordsCantBeAdded()
        {
            // Given
            Coordinate coord1 = new Coordinate(10, 20);
            Coordinate coord2 = new Coordinate(20, 30);
            Coordinate coord3 = new Coordinate(30, 40);
            Triad triad = new Triad(coord1, coord2, coord3);

            // When
            Coordinate coord4 = new Coordinate(50, 20);
            Coordinate coord5 = new Coordinate(60, 30);
            Coordinate coord6 = new Coordinate(70, 40);
            triad.SetCoordinates(coord4, coord5, coord6);
            ICollection<Coordinate> resp = triad.GetCoordinates();

            // Then
            Assert.IsTrue(resp.Count == 3, "Triad getter must return exactly 3 coordinates, even if setter has been executed twice");
        }

        [Test]
        public void CantReturnAnEmptyTriad()
        {
            // Given
            Triad triad = new Triad();

            // When/Then
            Assert.Throws<NotValidStateException>(() => triad.GetCoordinates(), "Triad getter must raise an exception when list is empty");
        }
    }
}
