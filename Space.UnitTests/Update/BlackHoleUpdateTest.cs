using AutoFixture;
using Moq;
using NUnit.Framework;
using Space.Interface;
using Space.SpaceObjects;
using Space.Update;
using System.Collections.Generic;

namespace Space.UnitTests.Update
{
    [TestFixture]
    class BlackHoleUpdateTest
    {
        private BlackHole _blackHole;

        private UpdateBlackHoleProperties _updateBlackHoleProperties;

        private Mock<ISpaceObjectTypeReader> _consoleReader;
        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IConsoleReader> _enterMock;

        [SetUp]
        public void Setup()
        {
            _blackHole = new Fixture().Create<BlackHole>();

            _consoleReader = new Mock<ISpaceObjectTypeReader>();
            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _enterMock = new Mock<IConsoleReader>();

            _updateBlackHoleProperties = new UpdateBlackHoleProperties(
                    _repositoryMock.Object,
                    _enterMock.Object,
                    _consoleReader.Object);
        }

        [Test]
        public void Update_ShouldUpdateBlackHoleProperties()
        {
            _enterMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(_blackHole.Name);
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _blackHole });

            _updateBlackHoleProperties.Perform();

            _consoleReader.Verify(obj => obj.ReadType(_blackHole), Times.Once);
            _consoleReader.Verify(obj => obj.ReadType((SpaceObject)_blackHole), Times.Once);
            _repositoryMock.Verify(blackHole => blackHole.UpdateObject(_blackHole), Times.Once);
        }

        [Test]
        public void Update_BlackHoleNameIsNull_ShouldNotUpdateProperties()
        {
            string name = null;
            _enterMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(name);
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _blackHole });

            _updateBlackHoleProperties.Perform();

            _consoleReader.Verify(obj => obj.ReadType(_blackHole), Times.Never);
            _consoleReader.Verify(obj => obj.ReadType((SpaceObject)_blackHole), Times.Never);
            _repositoryMock.Verify(blackHole => blackHole.UpdateObject(_blackHole), Times.Never);
        }
    }
}
