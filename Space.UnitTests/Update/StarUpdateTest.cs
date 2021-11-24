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
    class StarUpdateTest
    {
        private Star _star;

        private UpdateStarProperties _updateStarProperties;

        private Mock<ISpaceObjectTypeReader> _consoleReader;
        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IConsoleReader> _enterMock;

        [SetUp]
        public void Setup()
        {
            _star = new Fixture().Create<Star>();

            _consoleReader = new Mock<ISpaceObjectTypeReader>();
            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _enterMock = new Mock<IConsoleReader>();

            _updateStarProperties = new UpdateStarProperties(
                    _repositoryMock.Object,
                    _enterMock.Object,
                    _consoleReader.Object);
        }

        [Test]
        public void Update_ShouldUpdateStarProperties()
        {
            _enterMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(_star.Name);
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _star });

            _updateStarProperties.Perform();

            _consoleReader.Verify(obj => obj.ReadType(_star), Times.Once);
            _consoleReader.Verify(obj => obj.ReadType((SpaceObject)_star), Times.Once);
            _repositoryMock.Verify(star => star.UpdateObject(_star), Times.Once);
        }

        [Test]
        public void Update_StarNameIsNull_ShouldNotUpdateProperties()
        {
            string name = null;
            _enterMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(name);
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _star });

            _updateStarProperties.Perform();

            _consoleReader.Verify(obj => obj.ReadType(_star), Times.Never);
            _consoleReader.Verify(obj => obj.ReadType((SpaceObject)_star), Times.Never);
            _repositoryMock.Verify(star => star.UpdateObject(_star), Times.Never);
        }
    }
}
