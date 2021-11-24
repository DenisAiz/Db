using Space.Interface;
using System;
using System.Linq;
using Space.SpaceObjects;

namespace Space.Remove
{
    public class SpaceObjectRemover : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private IConsoleReader _consoleReader;

        public SpaceObjectRemover(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, IConsoleReader consoleReader)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _consoleReader = consoleReader;
        }

        public void Perform()
        {
            Console.Write("Enter the name: ");

            string nameObject = _consoleReader.ReadingConsoleFromActions();

            var space = _spaceObjectRepository.GetSpaceObjects().
                                            ToList().
                                            Find(spaceObject => spaceObject.Name == nameObject);

            if (nameObject != null)
            {
                _spaceObjectRepository.DeleteObject(space.Id);
                _spaceObjectRepository.Save();
            }
            else
            {
                Console.WriteLine("Wrong name");
            }
        }
    }
}
