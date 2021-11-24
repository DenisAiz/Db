using Space.Interface;
using System.Linq;
using Space.SpaceObjects;

namespace Space.Show
{
    public class ShowBlackHoles : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private IPrinter _printer;

        public ShowBlackHoles(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, IPrinter printer)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _printer = printer;
        }

        public void Perform()
        {
            var blackHoles = _spaceObjectRepository.GetSpaceObjects().OfType<BlackHole>();

            foreach (var item in blackHoles)
            {
                _printer.Print((SpaceObject)item);
                _printer.Print(item);
            }
        }
    }
}
