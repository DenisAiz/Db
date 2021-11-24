using AutoFixture;
using Moq;
using NUnit.Framework;
using Space.Add;
using Space.Interface;
using Space.SpaceObjects;

namespace Space.UnitTests.Add
{
    [TestFixture]
    class AsteroidGetterTest
    {
        private Asteroid _asteroid;

        private AsteroidPropertiesGetter _asteroidPropertiesGetter;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<ISpaceObjectsFactory> _enterMock;

        [SetUp]
        public void Setup()
        {
            _asteroid = new Fixture().Create<Asteroid>();

            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _enterMock = new Mock<ISpaceObjectsFactory>();

            _asteroidPropertiesGetter = new AsteroidPropertiesGetter(_repositoryMock.Object, _enterMock.Object);
        }

        [Test]
        public void Create_ShouldCreateAsteroid()
        {
            _enterMock.Setup(obj => obj.CreateAsteroid()).Returns(_asteroid);   // Подготовка данных

            _asteroidPropertiesGetter.Perform();    // Запускаем тестируемый метод

            _enterMock.Verify(obj => obj.CreateAsteroid(), Times.Once);    //проверка резyльтатов теста
            _repositoryMock.Verify(asteroid => asteroid.InsertObject(_asteroid), Times.Once);
            _repositoryMock.Verify(asteroid => asteroid.Save(), Times.Once);
        }
    }
}
