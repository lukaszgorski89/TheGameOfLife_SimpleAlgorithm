using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TheGameOfLife.Tests
{
    [TestClass]
    public class TheGameOfLifeTests
    {
        [TestMethod]
        public void GivenInitialStateCheckIfResultIsCorrect()
        {
            // arrange
            var height = 15;
            var width = 47;

            var expectedResult = new int[height, width];
            expectedResult[4, 4] = 1;
            expectedResult[5, 5] = 1;
            expectedResult[5, 6] = 1;
            expectedResult[6, 4] = 1;
            expectedResult[6, 5] = 1;

            var initialStateMock = Substitute.For<IInputData>();
            initialStateMock.CurrentState = new int[height, width];
            initialStateMock.CurrentState[0, 1] = 1;
            initialStateMock.CurrentState[1, 2] = 1;
            initialStateMock.CurrentState[2, 0] = 1;
            initialStateMock.CurrentState[2, 1] = 1;
            initialStateMock.CurrentState[2, 2] = 0;
            initialStateMock.MoveCount = 15;

            // act
            int[,] result = GetMovesResult(initialStateMock);

            // assert
            AssertTwoArraysAreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenNonChangeableFigureWhenMakesMoveThenThereAreNoChanges()
        {
            // arrange
            var height = 10;
            var width = 10;

            var initialStateMock = Substitute.For<IInputData>();
            initialStateMock.CurrentState = new int[height, width];
            initialStateMock.CurrentState[4, 4] = 1;
            initialStateMock.CurrentState[4, 5] = 1;
            initialStateMock.CurrentState[5, 4] = 1;
            initialStateMock.CurrentState[5, 5] = 1;
            initialStateMock.MoveCount = 1;

            // act
            int[,] result = GetMovesResult(initialStateMock);

            // assert
            AssertTwoArraysAreEqual(initialStateMock.CurrentState, result);
        }

        [TestMethod]
        public void GivenOscillatorFigureWhenMakesMovesThereAreNoChanges()
        {
            // arrange
            var height = 10;
            var width = 10;

            var initialStateMock = Substitute.For<IInputData>();
            initialStateMock.CurrentState = new int[height, width];
            initialStateMock.CurrentState[4, 3] = 1;
            initialStateMock.CurrentState[4, 4] = 1;
            initialStateMock.CurrentState[4, 5] = 1;
            initialStateMock.MoveCount = 2;

            // act
            int[,] result = GetMovesResult(initialStateMock);

            // assert
            AssertTwoArraysAreEqual(initialStateMock.CurrentState, result);
        }

        private static int[,] GetMovesResult(IInputData initialStateMock)
        {
            var executor = new MoveExecutor();
            var result = executor.MakeMoves(initialStateMock);
            return result;
        }

        private static void AssertTwoArraysAreEqual(int[,] expectedResult, int[,] result)
        {
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Assert.AreEqual(expectedResult[i, j], result[i, j]);
                }
            }
        }
    }
}
