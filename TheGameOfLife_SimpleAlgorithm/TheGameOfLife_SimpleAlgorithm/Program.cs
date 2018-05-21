using System;
using TheGameOfLife;

namespace TheGameOfLife_SimpleAlgorithm
{
    class Program
    {
        private static int moveCounter = 15;
        private const int arrayHeight = 20;
        private const int arrayWidth = 47;

        static void Main()
        {
            var initialState = PrepareInputData(arrayHeight, arrayWidth);
            var executor = new MoveExecutor();
            var result = executor.MakeNMoves(initialState, moveCounter);

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

        private static int[,] PrepareInputData(int arrayHeight, int arrayWidth)
        {
            var result = new int[arrayHeight, arrayWidth];
            result[0, 1] = 1;
            result[1, 2] = 1;
            result[2, 0] = 1;
            result[2, 1] = 1;
            result[2, 2] = 1;
            return result;
        }
    }
}
