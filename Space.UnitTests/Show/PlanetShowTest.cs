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
    class PlanetShowTest
    {
        private Planet _planet;

        private ShowPlanets _showPlanet;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IPrinter> _printerMock;

        [SetUp]
        public void Setup()
        {
            _planet = new Fixture().Create<Planet>();

            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _printerMock = new Mock<IPrinter>();

            _showPlanet = new ShowPlanets(_repositoryMock.Object, _printerMock.Object);
        }

        [Test]
        public void Show_ShouldShowPropertiesPlanet()
        {
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _planet });

            _showPlanet.Perform();

            _printerMock.Verify(planet => planet.Print(_planet), Times.Once);
            _printerMock.Verify(planet => planet.Print((SpaceObject)_planet), Times.Once);
        }
    }
}
