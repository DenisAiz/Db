using Space.Interface;
using Space.SpaceObjects;

namespace Space.Add
{
    public class PlanetPropertiesGetter : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private ISpaceObjectsFactory _factory;
        public PlanetPropertiesGetter(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, ISpaceObjectsFactory factory)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _factory = factory;
        }

        public void Perform()
        {
            _spaceObjectRepository.InsertObject(_factory.CreatePlanet());
            _spaceObjectRepository.Save();
        }
    }
}
