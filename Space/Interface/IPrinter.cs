using Space.SpaceObjects;

namespace Space.Interface
{
    public interface IPrinter
    {
        void Print(SpaceObject spaceObject);

        void Print(Asteroid asteroid);

        void Print(BlackHole blackhole);

        void Print(Star star);

        void Print(Planet planet);
    }
}
