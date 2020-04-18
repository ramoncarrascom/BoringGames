using BoringGames.Shared.Exceptions;
using BoringGames.Txt.Helper;
using BoringGames.Txt.Helper.Implementation;
using Moq;
using NUnit.Framework;

namespace BoringGames.Txt.Test.Helper
{
    public class ConsoleHelperTest
    {
        private Mock<IConsoleWrapper> wrapperMock;

        [SetUp]
        public void Setup()
        {
            wrapperMock = new Mock<IConsoleWrapper>();
        }

        [Test]
        public void ReadLnMessageReturnsDataFromConsoleWrapper()
        {
            // Given
            string dataTest = "DataTest";
            wrapperMock.Setup(m => m.ReadLine()).Returns(dataTest);
            IConsoleHelper helper = new ConsoleHelper(wrapperMock.Object);

            // When
            string resp = helper.ReadLnMessage("");

            // Then
            Assert.AreEqual(resp, dataTest, "Helper returned data must match mocked data");
        }

        [Test]
        public void GetNumberHappyPath()
        {
            // Given
            wrapperMock.Setup(m => m.ReadLine()).Returns("1");
            IConsoleHelper helper = new ConsoleHelper(wrapperMock.Object);

            // When
            int resp = helper.GetNumber("", 0, 2);

            // Then
            Assert.AreEqual(resp, 1, "Helper returned data must match mocked data");
        }

        [Test]
        public void UserQPressMustRaiseException()
        {
            // Given
            wrapperMock.Setup(m => m.ReadLine()).Returns("q");
            IConsoleHelper helper = new ConsoleHelper(wrapperMock.Object);

            // When / Then
            UserCancelException exc = Assert.Throws<UserCancelException>(() => helper.GetNumber("", 0, 2), "Helper must raise UserCancelException when user presses Q");
        }

        [Test]
        public void GetNumberFirstUnderMinThenCorrect()
        {
            // Given
            wrapperMock.SetupSequence(m => m.ReadLine())
                            .Returns("0")
                            .Returns("2");
            IConsoleHelper helper = new ConsoleHelper(wrapperMock.Object);

            // When
            int resp = helper.GetNumber("", 1, 3);

            // Then
            Assert.AreEqual(resp, 2, "Helper returned data must match mocked data");
        }

        [Test]
        public void GetNumberFirstOverMaxThenCorrect()
        {
            // Given
            wrapperMock.SetupSequence(m => m.ReadLine())
                            .Returns("3")
                            .Returns("1");
            IConsoleHelper helper = new ConsoleHelper(wrapperMock.Object);

            // When
            int resp = helper.GetNumber("", 0, 2);

            // Then
            Assert.AreEqual(resp, 1, "Helper returned data must match mocked data");
        }
    }
}
