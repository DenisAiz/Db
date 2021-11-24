using Space.Interface;
using System;
using System.Linq;
using Space.SpaceObjects;

namespace Space.Update
{
    public class UpdateStarProperties : IPerformingActions
    {
        private ISpaceObjectRepository<SpaceObject> _spaceObjectRepository;
        private IConsoleReader _consoleReader;
        private ISpaceObjectTypeReader _spaceObjectConsoleReader;

        public UpdateStarProperties(ISpaceObjectRepository<SpaceObject> spaceObjectRepository, IConsoleReader consoleReader, ISpaceObjectTypeReader spaceObjectConsoleReader)
        {
            _spaceObjectRepository = spaceObjectRepository;
            _consoleReader = consoleReader;
            _spaceObjectConsoleReader = spaceObjectConsoleReader;
        }

        public void Perform()
        {
            Console.WriteLine("Enter a name to change the object: ");
            string name = _consoleReader.ReadingConsoleFromActions();

            var item = _spaceObjectRepository.GetSpaceObjects().ToList().Find(item => item.Name == name);

            if (name != null)
            {
                _spaceObjectConsoleReader.ReadType(item);
                _spaceObjectConsoleReader.ReadType((Star)item);

                _spaceObjectRepository.UpdateObject(item);
                _spaceObjectRepository.Save();
            }
            else
            {
                Console.WriteLine("Wrong name");
            }
        }
    }
}
