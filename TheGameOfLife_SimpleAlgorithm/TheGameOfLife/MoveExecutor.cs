namespace TheGameOfLife
{
    public class MoveExecutor
    {
        public int[,] MakeMoves(IInputData inputData)
        {
            var result = inputData.CurrentState;
            for (int i = 0; i < inputData.MoveCount; i++)
            {
                result = MakeMove(result);
            }

            return result;
        }

        private int[,] MakeMove(int[,] currentState)
        {
            var heightIndex = currentState.GetUpperBound(0) + 1;
            var widthIndex = currentState.GetUpperBound(1) + 1;
            var result = new int[heightIndex, widthIndex];

            for (int i = 0; i < heightIndex; i++)
            {
                for (int j = 0; j < widthIndex; j++)
                {
                    var neighbourCounter = GetNeighbourCounter(i, j, currentState);
                    if (currentState[i, j] == 0)
                    {
                        if (neighbourCounter == 3)
                        {
                            result[i, j] = 1;
                        }
                    }
                    else
                    {
                        if (neighbourCounter == 2 || neighbourCounter == 3)
                        {
                            result[i, j] = 1;
                        }
                    }
                }
            }

            return result;
        }

        private int GetNeighbourCounter(int i, int j, int[,] currentState)
        {
            var arrayHeight = currentState.GetUpperBound(0);
            var arrayWidth = currentState.GetUpperBound(1);

            var result = 0;

            if (i > 0)
            {
                if (j > 0) result += currentState[i - 1, j - 1];
                result += currentState[i - 1, j];
                if(j < arrayWidth) result += currentState[i - 1, j + 1];
            }

            if (j > 0) result += currentState[i, j - 1];
            if (j < arrayWidth) result += currentState[i, j + 1];

            if (i < arrayHeight)
            {
                if (j > 0) result += currentState[i + 1, j - 1];
                result += currentState[i + 1, j];
                if (j < arrayWidth) result += currentState[i + 1, j + 1];
            }

            return result;
        }
    }
}
