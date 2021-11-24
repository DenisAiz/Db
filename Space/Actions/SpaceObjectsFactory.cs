using Space.Interface;
using Space.SpaceObjects;

namespace Space.Actions
{
    class SpaceObjectsFactory : ISpaceObjectsFactory
    {
        private ISpaceObjectTypeReader _spaceObjectConsoleReader;

        public SpaceObjectsFactory(ISpaceObjectTypeReader spaceObjectConsoleReader)
        {
            _spaceObjectConsoleReader = spaceObjectConsoleReader;
        }

        public Asteroid CreateAsteroid()
        {
            var asteroid = new Asteroid();

            _spaceObjectConsoleReader.ReadType((SpaceObject)asteroid);
            _spaceObjectConsoleReader.ReadType(asteroid);

            return asteroid;
        }

        public BlackHole CreateBlackHole()
        {
            var blackHole = new BlackHole();

            _spaceObjectConsoleReader.ReadType((SpaceObject)blackHole);
            _spaceObjectConsoleReader.ReadType(blackHole);

            return blackHole;
        }

        public Planet CreatePlanet()
        {
            var planet = new Planet();

            _spaceObjectConsoleReader.ReadType((SpaceObject)planet);
            _spaceObjectConsoleReader.ReadType(planet);

            return planet;
        }

        public Star CreateStar()
        {
            var star = new Star();

            _spaceObjectConsoleReader.ReadType((SpaceObject)star);
            _spaceObjectConsoleReader.ReadType(star);

            return star;
        }
    }
}
