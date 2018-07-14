using System;
using TheGameOfLife;

namespace TheGameOfLife_SimpleAlgorithm
{
    class Program
    {
        static void Main()
        {
            ci pipeline check
            var inputReader = new InputOutput.ConsoleInputReader();
            var input = inputReader.GetInputData();

            var executor = new MoveExecutor();
            var result = executor.MakeNMoves(input.InitialStateArray, input.MoveCounter);

            for (int i = 0; i <= result.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= result.GetUpperBound(1); j++)
                {
                    Console.Write(result[i,j] + " ");
                }

                Console.Write(Environment.NewLine);
            }

            Console.ReadLine();
        }
    }
}
