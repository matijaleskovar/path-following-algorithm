using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PathFollowingAlgorithm;
using PathFollowingAlgorithm.Models;
using System.Linq;
using static PathFollowingAlgorithm.Helpers.Enums;

namespace PathFollowingAlgorithmTest
{
    [TestClass]
    public class PathSolverAlgorithmTest
    {
        [TestMethod]
        public void TestFollowPathMethod()
        {
            PathSolverAlgorithm psa = new PathSolverAlgorithm();
            PathResult expectedResult = new PathResult(){ Path = @"@---+B||E--+|E|+--F--+|C|||A--|-----K|||+--E--Ex", Letters = "BEEFCAKE" };

            string testText = "  @---+" + Environment.NewLine
                            + "      B" + Environment.NewLine
                            + "K-----|--A" + Environment.NewLine
                            + "|     |  |" + Environment.NewLine
                            + "|  +--E  |" + Environment.NewLine
                            + "|  |     |" + Environment.NewLine
                            + "+--E--Ex C" + Environment.NewLine
                            + "   |     |" + Environment.NewLine
                            + "   +--F--+";

            string[] lines = testText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            char[][] char2DArray = lines.Select(item => item.ToArray()).ToArray();

            var result = psa.FollowPath(char2DArray);

            Assert.AreEqual(expectedResult.Path, result.Path);
            Assert.AreEqual(expectedResult.Letters, result.Letters);
        }

        [TestMethod]
        public void TestSetStartPositionMethod()
        {
            PathSolverAlgorithm psa = new PathSolverAlgorithm();
            Position expectedResult = new Position() { X = 1, Y = 1, Value = '@' };

            string testText = "    A" + Environment.NewLine
                            + " @--+";

            string[] lines = testText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            char[][] char2DArray = lines.Select(item => item.ToArray()).ToArray();

            var result = psa.SetStartPosition(char2DArray);

            Assert.AreEqual(expectedResult.X, result.X);
            Assert.AreEqual(expectedResult.Y, result.Y);
            Assert.AreEqual(expectedResult.Value, result.Value);
        }

        [TestMethod]
        public void TestFindDirectionMethod()
        {
            PathSolverAlgorithm psa = new PathSolverAlgorithm();
            Direction expectedResult = Direction.Right;
            Position currentPosition = new Position() { X = 1, Y = 0, Value = '-', LastDirection = Direction.Right };
            Position lastPosition = new Position() { X = 0, Y = 0, Value = '@', LastDirection = Direction.NoDirection };

            string testText = "@--";

            string[] lines = testText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            char[][] char2DArray = lines.Select(item => item.ToArray()).ToArray();

            var result = psa.FindDirection(char2DArray, currentPosition, lastPosition);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestNextPositionMethod()
        {
            PathSolverAlgorithm psa = new PathSolverAlgorithm();
            Position expectedResult = new Position() { X = 2, Y = 0 }; ;
            Direction direction = Direction.Right;
            Position currentPosition = new Position() { X = 1, Y = 0 };

            string testText = "@--";

            string[] lines = testText.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            char[][] char2DArray = lines.Select(item => item.ToArray()).ToArray();

            var result = psa.NextPosition(direction, currentPosition, char2DArray);

            Assert.AreEqual(expectedResult.X, result.X);
            Assert.AreEqual(expectedResult.Y, result.Y);
        }
    }
}
