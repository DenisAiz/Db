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
    class AsteroidUpdateTest
    {
        private Asteroid _asteroid;

        private UpdateAsteroidProperties _updateAsteroidProperties;

        private Mock<ISpaceObjectTypeReader> _consoleReader;
        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IConsoleReader> _enterMock;

        [SetUp]
        public void Setup()
        {
            _asteroid = new Fixture().Create<Asteroid>();

            _consoleReader = new Mock<ISpaceObjectTypeReader>();
            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _enterMock = new Mock<IConsoleReader>();

            _updateAsteroidProperties = new UpdateAsteroidProperties(
                    _repositoryMock.Object,
                    _enterMock.Object,
                    _consoleReader.Object);
        }

        [Test]
        public void Update_ShouldUpdateAsteroidsProperties()
        {
            _enterMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(_asteroid.Name);       // Подготовка данных
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _asteroid });

            _updateAsteroidProperties.Perform();    // Запускаем тестируемый метод

            _consoleReader.Verify(obj => obj.ReadType(_asteroid), Times.Once);      //проверка результатов теста
            _consoleReader.Verify(obj => obj.ReadType((SpaceObject)_asteroid), Times.Once);
            _repositoryMock.Verify(asteroid => asteroid.UpdateObject(_asteroid), Times.Once);
        }

        [Test]
        public void Update_AsteroidNameIsNull_ShouldNotUpdateProperties()
        {
            string name = null;
            _enterMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(name);
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _asteroid });

            _updateAsteroidProperties.Perform();

            _consoleReader.Verify(obj => obj.ReadType(_asteroid), Times.Never);
            _consoleReader.Verify(obj => obj.ReadType((SpaceObject)_asteroid), Times.Never);
            _repositoryMock.Verify(asteroid => asteroid.UpdateObject(_asteroid), Times.Never);
        }
    }
}
