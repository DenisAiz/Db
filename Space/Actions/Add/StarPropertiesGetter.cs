using Space.Interface;
using Space.SpaceObjects;

namespace Space.Add
{
    public class StarPropertiesGetter : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private ISpaceObjectsFactory _factory;

        public StarPropertiesGetter(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, ISpaceObjectsFactory factory)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _factory = factory;
        }

        public void Perform()
        {
            _spaceObjectRepository.InsertObject(_factory.CreateStar());
            _spaceObjectRepository.Save();
        }
    }
}
