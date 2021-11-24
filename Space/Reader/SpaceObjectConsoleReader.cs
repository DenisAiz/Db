using Space.Interface;
using Space.SpaceObjects;
using System;

namespace Space.Reader
{
    public class SpaceObjectConsoleReader : ISpaceObjectTypeReader
    {
        private IConsoleReader _consoleReader;

        public SpaceObjectConsoleReader(IConsoleReader consoleReader)
        {
            _consoleReader = consoleReader;
        }

        public void ReadType(SpaceObject spaceObject)
        {
            Console.Write("Name: ");
            spaceObject.Name = _consoleReader.ReadingConsoleFromActions();

            Console.Write("Description: ");
            spaceObject.Description = _consoleReader.ReadingConsoleFromActions();
        }

        public void ReadType(Asteroid asteroid)
        {
            Console.Write("Weight: ");

            asteroid.Weight = Convert.ToString(_consoleReader.ReadingConsoleFromActions());
        }

        public void ReadType(BlackHole blackHole)
        {
            Console.Write("Diameter: ");

            blackHole.Diameter = Convert.ToString(_consoleReader.ReadingConsoleFromActions());
        }

        public void ReadType(Planet planet)
        {
            Console.Write("Distance from Earth: ");

            planet.DistanceFromEarth = Convert.ToString(_consoleReader.ReadingConsoleFromActions());
        }

        public void ReadType(Star star)
        {
            Console.Write("Number of years: ");

            star.NumberOfYears = Convert.ToString(_consoleReader.ReadingConsoleFromActions());
        }
    }
}



