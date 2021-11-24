using System;
using Space.Interface;
using Space.SpaceObjects;

namespace Space.PrinterObject
{
    public class Printer : IPrinter
    {
        public void Print(SpaceObject spaceObjects)
        {
            Console.WriteLine($"Name: {spaceObjects.Name}");

            Console.WriteLine($"Description: {spaceObjects.Description}");
        }

        public void Print(Asteroid asteroid)
        {
            Console.WriteLine($"Weight: {asteroid.Weight}\n");
        }

        public void Print(BlackHole blackHoles)
        {
            Console.WriteLine($"Diameter: {blackHoles.Diameter}\n");
        }

        public void Print(Planet planets)
        {
            Console.WriteLine($"Distance from Earth: {planets.DistanceFromEarth}\n");
        }

        public void Print(Star stars)
        {
            Console.WriteLine($"Number of years: {stars.NumberOfYears}\n");
        }
    }
}
