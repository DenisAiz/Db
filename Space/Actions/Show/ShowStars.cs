using Space.Interface;
using System.Linq;
using Space.SpaceObjects;

namespace Space.Show
{
    public class ShowStars : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private IPrinter _printer;

        public ShowStars(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, IPrinter printer)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _printer = printer;
        }

        public void Perform()
        {
            var stars = _spaceObjectRepository.GetSpaceObjects().OfType<Star>();

            foreach (var item in stars)
            {
                _printer.Print((SpaceObject)item);
                _printer.Print(item);
            }
        }
    }
}
