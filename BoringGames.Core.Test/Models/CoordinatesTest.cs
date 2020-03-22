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

    }
}
