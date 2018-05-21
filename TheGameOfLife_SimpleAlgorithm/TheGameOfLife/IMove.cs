namespace TheGameOfLife
{
    public interface IMove
    {
        int[,] MakeOneMove(int[,] currentState);

        int[,] MakeNMoves(int[,] currentState, int moveCount);
    }
}
