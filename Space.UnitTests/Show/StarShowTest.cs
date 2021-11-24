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
    class StarShowTest
    {
        private Star _star;

        private ShowStars _showStar;

        private Mock<ISpaceObjectRepository<SpaceObject>> _repositoryMock;
        private Mock<IPrinter> _printerMock;

        [SetUp]
        public void Setup()
        {
            _star = new Fixture().Create<Star>();

            _repositoryMock = new Mock<ISpaceObjectRepository<SpaceObject>>();
            _printerMock = new Mock<IPrinter>();

            _showStar = new ShowStars(_repositoryMock.Object, _printerMock.Object);
        }

        [Test]
        public void Show_ShouldShowPropertiesStar()
        {
            _repositoryMock.Setup(obj => obj.GetSpaceObjects()).Returns(new List<SpaceObject>() { _star });

            _showStar.Perform();

            _printerMock.Verify(star => star.Print(_star), Times.Once);
            _printerMock.Verify(star => star.Print((SpaceObject)_star), Times.Once);
        }
    }
}
