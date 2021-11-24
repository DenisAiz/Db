using Space.SpaceObjects;

namespace Space.Interface
{
    public interface ISpaceObjectTypeReader
    {
        void ReadType(SpaceObject spaceObject);

        void ReadType(Asteroid asteroid);

        void ReadType(BlackHole blackhole);

        void ReadType(Star star);

        void ReadType(Planet planet);
    }
}