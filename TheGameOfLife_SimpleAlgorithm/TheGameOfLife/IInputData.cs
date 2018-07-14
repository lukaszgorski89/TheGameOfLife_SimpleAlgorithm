namespace TheGameOfLife
{
    public interface IInputData
    {
        int[,] CurrentState { get; set; }
        int MoveCount { get; set; }
    }
}
