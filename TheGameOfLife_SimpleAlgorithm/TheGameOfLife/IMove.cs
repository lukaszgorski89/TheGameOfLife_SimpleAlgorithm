namespace TheGameOfLife
{
    public interface IMove
    {
        int[,] MakeMoves(int[,] currentState, int moveCount);
    }
}
