using AutoFixture;
using Moq;
using NUnit.Framework;
using Space.Interface;
using Space.Show;
using Space.SpaceObjects;
using System.Collections.Generic;

namespace Space.UnitTests.Show
{
    [TestFixture]
    class BlackHoleShowTest
    {
        private BlackHole _blackHole;

        private ShowBlackHoles _showBlackHole;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IPrinter> _printerMock;

        [SetUp]
        public void Setup()
        {
            _blackHole = new Fixture().Create<BlackHole>();

            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _printerMock = new Mock<IPrinter>();

            _showBlackHole = new ShowBlackHoles(_repositoryMock.Object, _printerMock.Object);
        }

        [Test]
        public void Show_ShouldShowPropertiesBlackHole()
        {
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _blackHole });

            _showBlackHole.Perform();

            _printerMock.Verify(blackHole => blackHole.Print(_blackHole), Times.Once);
            _printerMock.Verify(blackHole => blackHole.Print((SpaceObject)_blackHole), Times.Once);
        }
    }
}
