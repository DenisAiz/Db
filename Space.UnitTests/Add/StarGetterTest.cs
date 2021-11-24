using AutoFixture;
using Moq;
using NUnit.Framework;
using Space.Add;
using Space.Interface;
using Space.SpaceObjects;

namespace Space.UnitTests.Add
{
    [TestFixture]
    class StarGetterTest
    {
        private Star _star;

        private StarPropertiesGetter _starPropertiesGetter;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<ISpaceObjectsFactory> _enterMock;

        [SetUp]
        public void Setup()
        {
            _star = new Fixture().Create<Star>();

            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _enterMock = new Mock<ISpaceObjectsFactory>();

            _starPropertiesGetter = new StarPropertiesGetter(_repositoryMock.Object, _enterMock.Object);
        }

        [Test]
        public void Create_ShouldCreateStar()
        {
            _enterMock.Setup(obj => obj.CreateStar()).Returns(_star);

            _starPropertiesGetter.Perform();

            _enterMock.Verify(obj => obj.CreateStar(), Times.Once);
            _repositoryMock.Verify(star => star.InsertObject(_star), Times.Once);
            _repositoryMock.Verify(star => star.Save(), Times.Once);
        }
    }
}
