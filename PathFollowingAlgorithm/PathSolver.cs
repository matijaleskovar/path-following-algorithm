using PathFollowingAlgorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PathFollowingAlgorithm.Helpers.Enums;
using static PathFollowingAlgorithm.Helpers.PathFollowingUtilities;
using static PathFollowingAlgorithm.Helpers.Constants;

namespace PathFollowingAlgorithm
{
    public class PathSolver
    {
        public PathResult FollowPath(char[][] char2DArray)
        {
            Position currentPosition;
            Position previousPosition;
            PathResult pathResult = new PathResult();
            StringBuilder path = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            List<Position> previousPositions = new List<Position>();

            //Initial set up
            currentPosition = SetStartPosition(char2DArray);

            if (currentPosition == null)
            {
                return null;
            }

            Direction direction = FindDirection(char2DArray, currentPosition);

            path.Append(currentPosition.Value);

            while (currentPosition.Value != END_CHAR && direction != Direction.NoDirection)
            {
                previousPosition = CopyPosition(currentPosition);

                currentPosition = NextPosition(direction, currentPosition, char2DArray);

                path.Append(currentPosition.Value);
                previousPositions.Add(CopyPosition(currentPosition));

                if (currentPosition.Value == CROSS_CHAR)
                {
                    direction = FindDirection(char2DArray, currentPosition, previousPosition);
                }
                else if (IsCapitalLetter(currentPosition.Value))
                {
                    if (previousPositions.Count(item => item.X == currentPosition.X && item.Y == currentPosition.Y) < 2)
                    {
                        letters.Append(currentPosition.Value);
                    }

                    direction = FindDirection(char2DArray, currentPosition, previousPosition);
                }
            }

            pathResult.Path = path.ToString();
            pathResult.Letters = letters.ToString();

            return pathResult;
        }

        public Position SetStartPosition(char[][] char2DArray)
        {
            Position startPosition = new Position();

            for (int i = 0; i < char2DArray.Length; i++)
            {
                for (int j = 0; j < char2DArray[i].Length; j++)
                {
                    if (char2DArray[i][j] == START_CHAR)
                    {
                        startPosition.X = j;
                        startPosition.Y = i;
                        startPosition.Value = START_CHAR;

                        return startPosition;
                    }
                }
            }
            return null;
        }

        public Direction FindDirection(char[][] char2DArray, Position currentPosition, Position previousPosition = null)
        {
            Position xAdd1 = new Position() { X = currentPosition.X + 1, Y = currentPosition.Y };
            Position xSub1 = new Position() { X = currentPosition.X - 1, Y = currentPosition.Y };
            Position yAdd1 = new Position() { X = currentPosition.X, Y = currentPosition.Y + 1 };
            Position ySub1 = new Position() { X = currentPosition.X, Y = currentPosition.Y - 1 };
            var newDirection = Direction.NoDirection;
            int possibleDirectionsCount = 0;

            if (previousPosition == null)
            {
                previousPosition = currentPosition;
            }

            //Find possible directions:
            //Down
            if (ValidArrayPosition(char2DArray, yAdd1.Y, yAdd1.X)
                && char2DArray[yAdd1.Y][yAdd1.X] != ' '
                && !IsSamePositionCoordinates(previousPosition, yAdd1))
            {
                newDirection = Direction.Down;
                possibleDirectionsCount++;
            }
            //Up
            if (ValidArrayPosition(char2DArray, ySub1.Y, ySub1.X)
                && char2DArray[ySub1.Y][ySub1.X] != ' '
                && !IsSamePositionCoordinates(previousPosition, ySub1))
            {
                newDirection = Direction.Up;
                possibleDirectionsCount++;
            }
            //Right
            if (ValidArrayPosition(char2DArray, xAdd1.Y, xAdd1.X)
                && char2DArray[xAdd1.Y][xAdd1.X] != ' '
                && !IsSamePositionCoordinates(previousPosition, xAdd1))
            {
                newDirection = Direction.Right;
                possibleDirectionsCount++;
            }
            //Left
            if (ValidArrayPosition(char2DArray, xSub1.Y, xSub1.X)
                && char2DArray[xSub1.Y][xSub1.X] != ' '
                && !IsSamePositionCoordinates(previousPosition, xSub1))
            {
                newDirection = Direction.Left;
                possibleDirectionsCount++;
            }
            //If there are multiple directions, keep the last direction
            if (possibleDirectionsCount > 1)
            {
                return currentPosition.LastDirection;
            }

            currentPosition.LastDirection = newDirection;

            return newDirection;
        }

        public Position NextPosition(Direction direction, Position currentPosition, char[][] char2DArray)
        {
            switch (direction)
            {
                case Direction.Right:
                    currentPosition.X += 1;
                    break;
                case Direction.Left:
                    currentPosition.X -= 1;
                    break;
                case Direction.Down:
                    currentPosition.Y += 1;
                    break;
                case Direction.Up:
                    currentPosition.Y -= 1;
                    break;
            }

            currentPosition.Value = char2DArray[currentPosition.Y][currentPosition.X];

            return currentPosition;
        }
    }
}
