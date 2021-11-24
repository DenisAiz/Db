using Space.SpaceObjects;

namespace Space.Interface
{
    public interface ISpaceObjectsFactory
    {
        public Asteroid CreateAsteroid();

        public BlackHole CreateBlackHole();

        public Planet CreatePlanet();

        public Star CreateStar();
    }
}
