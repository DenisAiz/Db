using Space.Interface;
using Space.SpaceObjects;

namespace Space.Add
{
    public class BlackHolePropertiesGetter : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private ISpaceObjectsFactory _factory;

        public BlackHolePropertiesGetter(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, ISpaceObjectsFactory factory)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _factory = factory;
        }

        public void Perform()
        {
            _spaceObjectRepository.InsertObject(_factory.CreateBlackHole());
            _spaceObjectRepository.Save();
        }
    }
}
