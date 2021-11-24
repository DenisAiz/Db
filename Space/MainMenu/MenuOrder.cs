using Space.Actions;
using Space.Add;
using Space.DataBase;
using Space.PrinterObject;
using Space.Reader;
using Space.Remove;
using Space.Repository;
using Space.Show;
using Space.Update;
using System;

namespace Space
{
    class MenuOrder
    {
        public void Realize(string operation)
        {
            var context = new SpaceObjectContext();

            var repository = new SpaceObjectRepository(context);

            var removeInConsole = new ConsoleReader();

            var spaceObjectConsoleReader = new SpaceObjectConsoleReader(removeInConsole);

            var remove = new SpaceObjectRemover(repository, removeInConsole);

            var factory = new SpaceObjectsFactory(spaceObjectConsoleReader);

            var printer = new Printer();

            switch (operation)
            {
                case "1":
                    var star = new ShowStars(repository, printer);
                    star.Perform();
                    break;

                case "2":
                    var planet = new ShowPlanets(repository, printer);
                    planet.Perform();
                    break;

                case "3":
                    var asteroid = new ShowAsteroids(repository, printer);
                    asteroid.Perform();
                    break;

                case "4":
                    var blackHole = new ShowBlackHoles(repository, printer);
                    blackHole.Perform();
                    break;

                case "5":
                    var addStar = new StarPropertiesGetter(repository, factory);
                    addStar.Perform();
                    break;

                case "6":
                    var addPlanet = new PlanetPropertiesGetter(repository, factory);
                    addPlanet.Perform();
                    break;

                case "7":
                    var addAsteroid = new AsteroidPropertiesGetter(repository, factory);
                    addAsteroid.Perform();
                    break;

                case "8":
                    var addBlackHole = new BlackHolePropertiesGetter(repository, factory);
                    addBlackHole.Perform();
                    break;

                case "9":
                    var updateStar = new UpdateStarProperties(repository, removeInConsole, spaceObjectConsoleReader);
                    updateStar.Perform();
                    break;

                case "10":
                    var updatePlanet = new UpdatePlanetProperties(repository, removeInConsole, spaceObjectConsoleReader);
                    updatePlanet.Perform();
                    break;

                case "11":
                    var updateAsteroid = new UpdateAsteroidProperties(repository, removeInConsole, spaceObjectConsoleReader);
                    updateAsteroid.Perform();
                    break;

                case "12":
                    var updateBlackHole = new UpdateBlackHoleProperties(repository, removeInConsole, spaceObjectConsoleReader);
                    updateBlackHole.Perform();
                    break;

                case "13":
                    remove.Perform();
                    break;

                default:
                    Console.WriteLine("Вы ввели неизвестную команду");
                    break;
            }
        }
    }
}
