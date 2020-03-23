using BoringGames.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Core.Test.Models
{
    public class CoordinatesTest
    {
        [Test]
        public void XCoordinateAssignmentHappyPath()
        {
            // Given
            int value = 10;
            Coordinate coord = new Coordinate();

            // When
            coord.X = value;

            // Then
            Assert.AreEqual(coord.X, value, "Coordinate X value getted value must be same as setted value");
        }

        [Test]
        public void YCoordinateAssignmentHappyPath()
        {
            // Given
            int value = 10;
            Coordinate coord = new Coordinate();

            // When
            coord.Y = value;

            // Then
            Assert.AreEqual(coord.Y, value, "Coordinate X value getted value must be same as setted value");
        }

        [Test]
        public void CoordinatesConstructorAssignmentHappyPath()
        {
            // Given
            int XValue = 10;
            int YValue = 20;

            // When
            Coordinate coord = new Coordinate(XValue, YValue);

            // Then
            Assert.AreEqual(coord.X, XValue, "Coordinate X value getted value must be same as setted value");
            Assert.AreEqual(coord.Y, YValue, "Coordinate Y value getted value must be same as setted value");
        }

        [Test]
        public void CoordinatesDefaultConstructorMustInitializeTo0()
        {
            // Given
            Coordinate coord;

            // When
            coord = new Coordinate();

            // Then
            Assert.AreEqual(coord.X, 0, "Coordinate X value getted value must be 0");
            Assert.AreEqual(coord.Y, 0, "Coordinate Y value getted value must be 0");
        }

        [Test]
        public void ToStringMustResolveCorrectFormat()
        {
            // Given
            Coordinate coord = new Coordinate(10, 20);

            // When
            string resp = coord.ToString();

            // Then
            Assert.IsTrue(resp.Equals("(10,20)"), "ToString must return the correct format");
        }

        [Test]
        public void TwoCoordinatesAreEqualIfTheyHaveTheSameXandYvalues()
        {
            // Given
            Coordinate coord1;
            Coordinate coord2;

            // When
            coord1 = new Coordinate(10, 20);
            coord2 = new Coordinate(10, 20);

            // Then
            Assert.AreEqual(coord1, coord2, "Two coordinates are equal if they have same X and Y values");
        }

        [Test]
        public void TwoCoordinatesAreNotEqualIfTheyHaveDifferentYvalues()
        {
            // Given
            Coordinate coord1;
            Coordinate coord2;

            // When
            coord1 = new Coordinate(10, 20);
            coord2 = new Coordinate(10, 10);

            // Then
            Assert.AreNotEqual(coord1, coord2, "Two coordinates are different if they have different Y values");
        }

        [Test]
        public void TwoCoordinatesAreNotEqualIfTheyHaveDifferentXvalues()
        {
            // Given
            Coordinate coord1;
            Coordinate coord2;

            // When
            coord1 = new Coordinate(20, 10);
            coord2 = new Coordinate(10, 10);

            // Then
            Assert.AreNotEqual(coord1, coord2, "Two coordinates are different if they have different X values");
        }

        [Test]
        public void ClonedCoordinateMustHaveSameXAndYThanOriginal()
        {
            // Given
            int coordX = 10;
            int coordY = 20;
            Coordinate original = new Coordinate(coordX, coordY);

            // When
            Coordinate copied = original.Clone();

            // Then
            Assert.IsTrue(original.X == coordX, "Cloned X must be same as Original X");
            Assert.IsTrue(original.Y == coordY, "Cloned Y must be same as Original Y");
        }
    }
}
