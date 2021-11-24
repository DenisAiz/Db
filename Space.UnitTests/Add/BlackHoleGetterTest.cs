using AutoFixture;
using Moq;
using NUnit.Framework;
using Space.Add;
using Space.Interface;
using Space.SpaceObjects;

namespace Space.UnitTests.Add
{
    [TestFixture]
    class BlackHoleGetterTest
    {
        private BlackHole _blackHole;

        private BlackHolePropertiesGetter _blackHolePropertiesGetter;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<ISpaceObjectsFactory> _enterMock;

        [SetUp]
        public void Setup()
        {
            _blackHole = new Fixture().Create<BlackHole>();

            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _enterMock = new Mock<ISpaceObjectsFactory>();

            _blackHolePropertiesGetter = new BlackHolePropertiesGetter(_repositoryMock.Object, _enterMock.Object);
        }

        [Test]
        public void Create_ShouldCreateBlackHole()
        {
            _enterMock.Setup(obj => obj.CreateBlackHole()).Returns(_blackHole);

            _blackHolePropertiesGetter.Perform();

            _enterMock.Verify(obj => obj.CreateBlackHole(), Times.Once);
            _repositoryMock.Verify(blackHole => blackHole.InsertObject(_blackHole), Times.Once);
            _repositoryMock.Verify(blackHole => blackHole.Save(), Times.Once);
        }
    }
}
