using BoringGames.Txt.Games.Helper;
using BoringGames.Txt.Games.Helper.Implementation;
using BoringGames.Txt.Helper;
using Moq;
using NUnit.Framework;

namespace BoringGames.Txt.Test.Games
{
    public class BoringToeHelperTest
    {
        private Mock<IConsoleHelper> wrapperMock;

        [SetUp]
        public void Setup()
        {
            wrapperMock = new Mock<IConsoleHelper>();
        }

        [Test]
        public void GetPlayerANameDefault()
        {
            // Given
            wrapperMock.Setup(m => m.ReadLnMessage(It.IsAny<string>())).Returns("");
            IBoringToeHelper consoleHelper = new BoringToeHelper(wrapperMock.Object);

            // When
            string resp = consoleHelper.GetPlayerAName();

            // Then
            Assert.AreEqual(resp, "Player 1", "Default returned data must be Player 1");
        }

        [Test]
        public void GetPlayerBNameDefault()
        {
            // Given
            wrapperMock.Setup(m => m.ReadLnMessage(It.IsAny<string>())).Returns("");
            IBoringToeHelper consoleHelper = new BoringToeHelper(wrapperMock.Object);

            // When
            string resp = consoleHelper.GetPlayerBName();

            // Then
            Assert.AreEqual(resp, "Player 2", "Default returned data must be Player 2");
        }

        [Test]
        public void GetPlayerANameMocked()
        {
            // Given
            string mockData = "TestData";
            wrapperMock.Setup(m => m.ReadLnMessage(It.IsAny<string>())).Returns(mockData);
            IBoringToeHelper consoleHelper = new BoringToeHelper(wrapperMock.Object);

            // When
            string resp = consoleHelper.GetPlayerAName();

            // Then
            Assert.AreEqual(resp, mockData, "Default returned data must be mocked data");
        }

        [Test]
        public void GetPlayerBNameMocked()
        {
            // Given
            string mockData = "TestData";
            wrapperMock.Setup(m => m.ReadLnMessage(It.IsAny<string>())).Returns(mockData);
            IBoringToeHelper consoleHelper = new BoringToeHelper(wrapperMock.Object);

            // When
            string resp = consoleHelper.GetPlayerBName();

            // Then
            Assert.AreEqual(resp, mockData, "Default returned data must be mocked data");
        }

        [Test]
        public void GetXCoordinateMustReturnMockedValue()
        {
            // Given
            int mockData = 1;
            wrapperMock.Setup(m => m.GetNumber(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(mockData);
            IBoringToeHelper consoleHelper = new BoringToeHelper(wrapperMock.Object);

            // When
            int resp = consoleHelper.GetXCoordinate("");

            // Then
            Assert.AreEqual(resp, mockData, "Default returned data must be mocked data");
        }

        [Test]
        public void GetYCoordinateMustReturnMockedValue()
        {
            // Given
            int mockData = 1;
            wrapperMock.Setup(m => m.GetNumber(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).Returns(mockData);
            IBoringToeHelper consoleHelper = new BoringToeHelper(wrapperMock.Object);

            // When
            int resp = consoleHelper.GetYCoordinate("");

            // Then
            Assert.AreEqual(resp, mockData, "Default returned data must be mocked data");
        }
    }
}
