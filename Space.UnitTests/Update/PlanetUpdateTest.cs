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
    class PlanetUpdateTest
    {
        private Planet _planet;

        private UpdatePlanetProperties _updatePlanetProperties;

        private Mock<ISpaceObjectTypeReader> _consoleReader;
        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IConsoleReader> _enterMock;

        [SetUp]
        public void Setup()
        {
            _planet = new Fixture().Create<Planet>();

            _consoleReader = new Mock<ISpaceObjectTypeReader>();
            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _enterMock = new Mock<IConsoleReader>();

            _updatePlanetProperties = new UpdatePlanetProperties(
                    _repositoryMock.Object,
                    _enterMock.Object,
                    _consoleReader.Object);
        }

        [Test]
        public void Update_ShouldUpdatePlanetProperties()
        {
            _enterMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(_planet.Name);
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _planet });

            _updatePlanetProperties.Perform();

            _consoleReader.Verify(obj => obj.ReadType(_planet), Times.Once);
            _consoleReader.Verify(obj => obj.ReadType((SpaceObject)_planet), Times.Once);
            _repositoryMock.Verify(planet => planet.UpdateObject(_planet), Times.Once);
        }

        [Test]
        public void Update_PlanetNameIsNull_ShouldNotUpdateProperties()
        {
            string name = null;
            _enterMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(name);
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _planet });

            _updatePlanetProperties.Perform();

            _consoleReader.Verify(obj => obj.ReadType(_planet), Times.Never);
            _consoleReader.Verify(obj => obj.ReadType((SpaceObject)_planet), Times.Never);
            _repositoryMock.Verify(planet => planet.UpdateObject(_planet), Times.Never);
        }
    }
}
