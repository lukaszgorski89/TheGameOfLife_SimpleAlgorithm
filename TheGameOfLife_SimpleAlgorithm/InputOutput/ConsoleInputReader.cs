using System;
using System.Linq;

namespace InputOutput
{
    public class ConsoleInputReader : IInputReader
    {
        public InputData GetInputData()
        {
            var inputStringData = new InputStringData();

            Console.WriteLine("What is array height?");
            inputStringData.Height = Console.ReadLine();

            Console.WriteLine("What is array width?");
            inputStringData.Width = Console.ReadLine();

            Console.WriteLine("How many moves?");
            inputStringData.MoveCounter = Console.ReadLine();

            Console.WriteLine("How many alive cells are there in initial state?");
            int.TryParse(Console.ReadLine(), out var aliveCounter);


            if (aliveCounter > 0)
            {
                Console.WriteLine("Write alive cells coordinates. Input format: heightIndex widthIndex");
                for (int i = 0; i < aliveCounter; i++)
                {
                    inputStringData.Cells.Add(Console.ReadLine());
                }
            }

            var result = new InputData(inputStringData);
            return result;
        }
    }
}
