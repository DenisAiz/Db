using AutoFixture;
using Moq;
using NUnit.Framework;
using Space.Interface;
using Space.Remove;
using Space.SpaceObjects;
using System.Collections.Generic;

namespace Space.UnitTests.Remove
{
    [TestFixture]
    class SpaceObjectRemoverTest
    {
        private SpaceObjectRemover _spaceObjectRemover;

        private Asteroid _asteroid;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IConsoleReader> _consoleReaderMock;

        [SetUp]
        public void Setup()
        {
            _asteroid = new Fixture().Create<Asteroid>();

            _consoleReaderMock = new Mock<IConsoleReader>();
            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();

            _spaceObjectRemover = new SpaceObjectRemover(_repositoryMock.Object, _consoleReaderMock.Object);
        }

        [Test]
        public void Remove_ShouldRemoveAsteroid()
        {
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _asteroid });  //подготавливаем данные
            _consoleReaderMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(_asteroid.Name);

            _spaceObjectRemover.Perform();  // Запускаем тестируемый метод

            _repositoryMock.Verify(asteroid => asteroid.DeleteObject(_asteroid.Id), Times.Once);    //проверка результатов теста
            _repositoryMock.Verify(asteroid => asteroid.Save(), Times.Once);
        }

        [Test]
        public void Remove_AsteroidIsNull_ShouldThrowArgumentNullException()
        {
            string name = null;
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _asteroid });
            _consoleReaderMock.Setup(obj => obj.ReadingConsoleFromActions()).Returns(name);

            _spaceObjectRemover.Perform();

            _repositoryMock.Verify(asteroid => asteroid.DeleteObject(_asteroid.Id), Times.Never);
            _repositoryMock.Verify(asteroid => asteroid.Save(), Times.Never);
        }
    }
}
