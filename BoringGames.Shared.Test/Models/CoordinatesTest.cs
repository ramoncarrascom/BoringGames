﻿using BoringGames.Shared.Exceptions;
using BoringGames.Shared.Models;
using NUnit.Framework;
using System;

namespace BoringGames.Shared.Test.Models
{
    public class CoordinatesTest
    {
        private class FooClass { }

        [Test]
        public void XCoordinateAssignmentHappyPath()
        {
            // Given
            int value = 10;

            // When
            Coordinate coord = new Coordinate(value, 0);

            // Then
            Assert.AreEqual(coord.X, value, "Coordinate X value getted value must be same as setted value");
        }

        [Test]
        public void YCoordinateAssignmentHappyPath()
        {
            // Given
            int value = 10;

            // When
            Coordinate coord = new Coordinate(0, value);

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
        public void CoordinatesConstructorAssignmentXLessThanMin()
        {
            // Given
            int XValue = int.MinValue;
            int YValue = 20;

            // When / Then
            Assert.Throws<NotValidValueException>(() => new Coordinate(XValue, YValue), "Coordinate X less or equal than min must raise exception");
        }

        [Test]
        public void CoordinatesConstructorAssignmentYLessThanMin()
        {
            // Given
            int XValue = 10;
            int YValue = int.MinValue;

            // When / Then
            Assert.Throws<NotValidValueException>(() => new Coordinate(XValue, YValue), "Coordinate Y less or equal than min must raise exception");
        }

        [Test]
        public void CoordinatesConstructorAssignmentXHigherThanMax()
        {
            // Given
            int XValue = int.MaxValue;
            int YValue = 20;

            // When / Then
            Assert.Throws<NotValidValueException>(() => new Coordinate(XValue, YValue), "Coordinate X higher or equal than min must raise exception");
        }

        [Test]
        public void CoordinatesConstructorAssignmentYHigherThanMax()
        {
            // Given
            int XValue = 10;
            int YValue = int.MaxValue;

            // When / Then
            Assert.Throws<NotValidValueException>(() => new Coordinate(XValue, YValue), "Coordinate Y higher or equal than min must raise exception");
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
            Assert.IsTrue(coord1.Equals(coord2), "Two coordinates are equal if they have same X and Y values");
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
            Assert.IsFalse(coord1.Equals(coord2), "Two coordinates are different if they have different Y values");
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
            Assert.IsFalse(coord1.Equals(coord2), "Two coordinates are different if they have different X values");
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

        [Test]
        public void HashCodeCalculationMustBeOk()
        {
            // Given
            int XValue = 10;
            int YValue = 20;

            // When
            Coordinate coord = new Coordinate(XValue, YValue);

            // Then
            Assert.AreEqual(coord.GetHashCode(), HashCode.Combine(XValue, YValue), "HashCode must use HashCode Combine");
        }

        [Test]
        public void EqualsMustReturnFalseIfCheckedObjectIsNotCoordinate()
        {
            // Given
            Coordinate coord = new Coordinate(10, 20);
            FooClass foo = new FooClass();

            // When / Then
            Assert.IsFalse(coord.Equals(foo), "Equals must return false if checked object is from a different class");

        }
    }
}
