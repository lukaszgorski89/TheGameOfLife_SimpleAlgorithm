using System.Linq;

namespace InputOutput
{
    public class InputData
    {
        public InputData(InputStringData inputStringData)
        {
            int.TryParse(inputStringData.Height, out var height);
            int.TryParse(inputStringData.Width, out var width);
            InitialStateArray = new int[height, width];

            int.TryParse(inputStringData.MoveCounter, out var moves);
            MoveCounter = moves;

            foreach (var cell in inputStringData.Cells)
            {
                var coordinates = cell.Split(' ').Select(x => int.Parse(x ?? "0")).ToArray();
                InitialStateArray[coordinates[0], coordinates[1]] = 1;
            }
        }

        public int MoveCounter { get; set; }

        public int[,] InitialStateArray { get; set; }
    }
}
