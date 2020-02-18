using PathFollowingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFollowingAlgorithm.Helpers
{
    public static class PathFollowingUtilities
    {
        public static Position CopyPosition(Position currentPosition)
        {
            return new Position() { X = currentPosition.X, Y = currentPosition.Y, Value = currentPosition.Value, LastDirection = currentPosition.LastDirection };
        }

        public static bool IsCapitalLetter(char c)
        {
            return (c >= 'A' && c <= 'Z');
        }

        public static char[][] ConvertStringTo2DCharArray(string text)
        {
            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return lines.Select(item => item.ToArray()).ToArray();
        }

        public static bool ValidArrayPosition(char[][] char2DArray, int yAxis, int xAxis)
        {
            try
            {
                char value = char2DArray[yAxis][xAxis];
            }

            catch (IndexOutOfRangeException)
            {
                return false;
            }

            return true;
        }

        public static bool IsSamePositionCoordinates(Position a, Position b)
        {
            return (a.Y == b.Y && a.X == b.X);
        }
    }
}
