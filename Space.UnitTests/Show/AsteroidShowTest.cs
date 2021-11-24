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
    class AsteroidShowTest
    {
        private Asteroid _asteroid;

        private ShowAsteroids _showAsteroids;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IPrinter> _printerMock;

        [SetUp]
        public void Setup()
        {
            _asteroid = new Fixture().Create<Asteroid>();

            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _printerMock = new Mock<IPrinter>();

            _showAsteroids = new ShowAsteroids(_repositoryMock.Object, _printerMock.Object);
        }

        [Test]
        public void Show_ShouldShowPropertiesAsteroid()
        {
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _asteroid });     //подготавливаем данные

            _showAsteroids.Perform();   // Запускаем тестируемый метод

            _printerMock.Verify(asteroid => asteroid.Print(_asteroid), Times.Once);    //проверка результатов теста
            _printerMock.Verify(asteroid => asteroid.Print((SpaceObject)_asteroid), Times.Once);
        }
    }
}
