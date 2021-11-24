using Space.Interface;
using System;

namespace Space.Actions
{
    public class ConsoleReader : IConsoleReader
    {
        public string ReadingConsoleFromActions()
        {
            return Console.ReadLine();
        }
    }
}
