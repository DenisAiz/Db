using AutoFixture;
using Moq;
using NUnit.Framework;
using Space.Add;
using Space.Interface;
using Space.SpaceObjects;

namespace Space.UnitTests.Add
{
    [TestFixture]
    class PlanetGetterTest
    {
        private Planet _planet;

        private PlanetPropertiesGetter _planetPropertiesGetter;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<ISpaceObjectsFactory> _enterMock;

        [SetUp]
        public void Setup()
        {
            _planet = new Fixture().Create<Planet>();

            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _enterMock = new Mock<ISpaceObjectsFactory>();

            _planetPropertiesGetter = new PlanetPropertiesGetter(_repositoryMock.Object, _enterMock.Object);
        }

        [Test]
        public void Create_ShouldCreatePlanet()
        {
            _enterMock.Setup(obj => obj.CreatePlanet()).Returns(_planet);

            _planetPropertiesGetter.Perform();

            _enterMock.Verify(obj => obj.CreatePlanet(), Times.Once);
            _repositoryMock.Verify(planet => planet.InsertObject(_planet), Times.Once);
            _repositoryMock.Verify(planet => planet.Save(), Times.Once);
        }
    }
}
