using BoringGames.Shared.Exceptions;
using BoringGames.Txt.Games;
using BoringGames.Txt.Games.Helper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoringGames.Txt.Test.Games
{
    public class BoringToeTest
    {
        private Mock<IBoringToeHelper> helperMock;

        [SetUp]
        public void Setup()
        {
            helperMock = new Mock<IBoringToeHelper>();
        }

        [Test]
        public void BoringToeRunHappyPath()
        {
            // Given
            helperMock.Setup(m => m.GetPlayerAName()).Returns("");
            helperMock.Setup(m => m.GetPlayerBName()).Returns("");
            helperMock.SetupSequence(m => m.GetXCoordinate(It.IsAny<string>()))
                .Returns(0)
                .Returns(1)
                .Returns(0)
                .Returns(1)
                .Returns(0)
                .Returns(1);
            helperMock.SetupSequence(m => m.GetYCoordinate(It.IsAny<string>()))
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(2)
                .Returns(2);
            BoringToe game = new BoringToe(helperMock.Object);

            // When
            game.Run();

            // Then
            helperMock.Verify(v => v.GetPlayerAName(), Times.Once, "GetPlayerAName must be run exactly 1 time");
            helperMock.Verify(v => v.GetPlayerBName(), Times.Once, "GetPlayerBName must be run exactly 1 time");
            helperMock.Verify(v => v.GetXCoordinate(It.IsAny<string>()), Times.Exactly(5), "GetXCoordinate must be run exactly 5 times");
            helperMock.Verify(v => v.GetYCoordinate(It.IsAny<string>()), Times.Exactly(5), "GetYCoordinate must be run exactly 5 times");
        }

        [Test]
        public void BoringToePlayerRetry()
        {
            // Given
            helperMock.Setup(m => m.GetPlayerAName()).Returns("");
            helperMock.Setup(m => m.GetPlayerBName()).Returns("");
            helperMock.SetupSequence(m => m.GetXCoordinate(It.IsAny<string>()))
                .Returns(0)
                .Returns(1)
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(0)
                .Returns(1);
            helperMock.SetupSequence(m => m.GetYCoordinate(It.IsAny<string>()))
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(1)
                .Returns(2)
                .Returns(2);
            BoringToe game = new BoringToe(helperMock.Object);

            // When
            game.Run();

            // Then
            helperMock.Verify(v => v.GetPlayerAName(), Times.Once, "GetPlayerAName must be run exactly 1 time");
            helperMock.Verify(v => v.GetPlayerBName(), Times.Once, "GetPlayerBName must be run exactly 1 time");
            helperMock.Verify(v => v.GetXCoordinate(It.IsAny<string>()), Times.Exactly(6), "GetXCoordinate must be run exactly 6 times");
            helperMock.Verify(v => v.GetYCoordinate(It.IsAny<string>()), Times.Exactly(6), "GetYCoordinate must be run exactly 6 times");
        }

        [Test]
        public void BoringToeUserCancels()
        {
            // Given
            helperMock.Setup(m => m.GetPlayerAName()).Returns("");
            helperMock.Setup(m => m.GetPlayerBName()).Returns("");
            helperMock.SetupSequence(m => m.GetXCoordinate(It.IsAny<string>()))
                .Returns(0)
                .Returns(1)
                .Throws<UserCancelException>()
                .Returns(0)
                .Returns(1)
                .Returns(0)
                .Returns(1);
            helperMock.SetupSequence(m => m.GetYCoordinate(It.IsAny<string>()))
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(1)
                .Returns(2)
                .Returns(2);
            BoringToe game = new BoringToe(helperMock.Object);

            // When
            game.Run();

            // Then
            helperMock.Verify(v => v.GetPlayerAName(), Times.Once, "GetPlayerAName must be run exactly 1 time");
            helperMock.Verify(v => v.GetPlayerBName(), Times.Once, "GetPlayerBName must be run exactly 1 time");
            helperMock.Verify(v => v.GetXCoordinate(It.IsAny<string>()), Times.Exactly(3), "GetXCoordinate must be run exactly 3 times");
            helperMock.Verify(v => v.GetYCoordinate(It.IsAny<string>()), Times.Exactly(2), "GetYCoordinate must be run exactly 2 times");
        }

        [Test]
        public void BoringToeNoneWins()
        {
            // Given
            helperMock.Setup(m => m.GetPlayerAName()).Returns("");
            helperMock.Setup(m => m.GetPlayerBName()).Returns("");
            helperMock.SetupSequence(m => m.GetXCoordinate(It.IsAny<string>()))
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(2)
                .Returns(2)
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(2);
            helperMock.SetupSequence(m => m.GetYCoordinate(It.IsAny<string>()))
                .Returns(0)
                .Returns(0)
                .Returns(1)
                .Returns(0)
                .Returns(1)
                .Returns(1)
                .Returns(2)
                .Returns(2)
                .Returns(2);

            BoringToe game = new BoringToe(helperMock.Object);

            // When
            game.Run();

            // Then
            helperMock.Verify(v => v.GetPlayerAName(), Times.Once, "GetPlayerAName must be run exactly 1 time");
            helperMock.Verify(v => v.GetPlayerBName(), Times.Once, "GetPlayerBName must be run exactly 1 time");
            helperMock.Verify(v => v.GetXCoordinate(It.IsAny<string>()), Times.Exactly(9), "GetXCoordinate must be run exactly 9 times");
            helperMock.Verify(v => v.GetYCoordinate(It.IsAny<string>()), Times.Exactly(9), "GetYCoordinate must be run exactly 9 times");
        }
    }
}
