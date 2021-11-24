using Space.Interface;
using System.Linq;
using Space.SpaceObjects;

namespace Space.Show
{
    public class ShowPlanets : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private IPrinter _printer;

        public ShowPlanets(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, IPrinter printer)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _printer = printer;
        }

        public void Perform()
        {
            var planets = _spaceObjectRepository.GetSpaceObjects().OfType<Planet>();

            foreach (var item in planets)
            {
                _printer.Print((SpaceObject)item);
                _printer.Print(item);
            }
        }
    }
}
