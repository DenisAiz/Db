using Space.Interface;
using System.Linq;
using Space.SpaceObjects;

namespace Space.Show
{
    public class ShowAsteroids : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private IPrinter _printer;

        public ShowAsteroids(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, IPrinter printer)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _printer = printer;
        }

        public void Perform()
        {
            var asteroids = _spaceObjectRepository.GetSpaceObjects().OfType<Asteroid>();

            foreach (var item in asteroids)
            {
                _printer.Print((SpaceObject)item);
                _printer.Print(item);
            }
        }
    }
}
