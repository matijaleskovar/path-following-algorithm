using PathFollowingAlgorithm.Constants;
using PathFollowingAlgorithm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PathFollowingAlgorithm.Enum.Enumeration;

namespace PathFollowingAlgorithm
{
    public partial class MainForm : Form
    {
        private string _fileString = string.Empty;
        private const char _startChar = '@';
        private const char _endChar = 'x';
        private const char _crossChar = '+';

        public MainForm()
        {
            InitializeComponent();
        }

        //Events
        private void btnAddASCIIMap_Click(object sender, EventArgs e)
        {
            int size = -1;
            Position currentPosition = new Position();

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                tbFilePath.Text = file;
                try
                {
                    _fileString = File.ReadAllText(file);
                    size = _fileString.Length;
                }
                catch (IOException)
                {
                    MessageBox.Show("There was a file upload error", "File upload error");
                }

                ClearResultLbl();
            }

        }

        private void btnProcessMap_Click(object sender, EventArgs e)
        {
            char[][] char2DArray = ConvertStringTo2DCharArray(_fileString);

            var result = FollowPath(char2DArray);

            if (result != null)
            {
                ShowResultLbl(result);
            }
            else
            {
                MessageBox.Show("Error ocurred", "Error");
            }
        }

        //Algorithm methods
        public PathResult FollowPath(char[][] char2DArray)
        {
            Position currentPosition;
            Position previousPosition;
            PathResult pathResult = new PathResult();
            StringBuilder path = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            List<Position> previousPositions = new List<Position>();

            //Initial set up
            currentPosition = setStartPosition(char2DArray);
            
            if (currentPosition == null)
            {
                return null;
            }

            Direction direction = FindDirection(char2DArray, currentPosition);

            path.Append(currentPosition.Value);

            while (currentPosition.Value != _endChar && direction != Direction.NoDirection)
            {
                previousPosition = CopyPosition(currentPosition);

                currentPosition = NextPosition(direction, currentPosition, char2DArray);

                path.Append(currentPosition.Value);
                previousPositions.Add(CopyPosition(currentPosition));

                if (currentPosition.Value == _crossChar)
                {
                    direction = FindDirection(char2DArray, currentPosition, previousPosition);
                }

                else if (IsCapitalLetter(currentPosition.Value))
                {
                    if (previousPositions.Where(item => item.X == currentPosition.X && item.Y == currentPosition.Y).ToList().Count < 2)
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

        public Position setStartPosition(char[][] char2DArray)
        {
            Position startPosition = new Position();

            for (int i = 0; i < char2DArray.Length; i++)
            {
                for (int j = 0; j < char2DArray[i].Length; j++)
                {
                    if (char2DArray[i][j] == _startChar)
                    {
                        startPosition.X = j;
                        startPosition.Y = i;
                        startPosition.Value = _startChar;

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
            if (ValidArrayPosition(char2DArray, yAdd1.Y, yAdd1.X) && char2DArray[yAdd1.Y][yAdd1.X] != ' ' && !IsSamePositionCoordinates(previousPosition, yAdd1))
            {
                newDirection = Direction.Down;
                possibleDirectionsCount++;
            }
            //Up
            if (ValidArrayPosition(char2DArray, ySub1.Y, ySub1.X) && char2DArray[ySub1.Y][ySub1.X] != ' ' && !IsSamePositionCoordinates(previousPosition, ySub1))
            {
                newDirection = Direction.Up;
                possibleDirectionsCount++;
            }
            //Right
            if (ValidArrayPosition(char2DArray, xAdd1.Y, xAdd1.X) && char2DArray[xAdd1.Y][xAdd1.X] != ' ' && !IsSamePositionCoordinates(previousPosition, xAdd1))
            {
                newDirection = Direction.Right;
                possibleDirectionsCount++;
            }
            //Left
            if (ValidArrayPosition(char2DArray, xSub1.Y, xSub1.X) && char2DArray[xSub1.Y][xSub1.X] != ' ' && !IsSamePositionCoordinates(previousPosition, xSub1))
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
        //Support methods
        public Position CopyPosition(Position currentPosition)
        {
            return new Position() { X = currentPosition.X, Y = currentPosition.Y, Value = currentPosition.Value, LastDirection = currentPosition.LastDirection };
        }

        public bool IsCapitalLetter(char c)
        {
            return (c >= 'A' && c <= 'Z');
        }

        public char[][] ConvertStringTo2DCharArray(string text)
        {
            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            return lines.Select(item => item.ToArray()).ToArray();
        }

        public bool ValidArrayPosition(char[][] char2DArray, int yAxis, int xAxis)
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

        public bool IsSamePositionCoordinates(Position a, Position b)
        {
            return (a.Y == b.Y && a.X == b.X);
        }

        //UI methods
        public void ShowResultLbl(PathResult result)
        {
            tbPath.Text = result.Path;
            tbLetters.Text = result.Letters;
        }

        public void ClearResultLbl()
        {
            tbPath.Text = string.Empty;
            tbLetters.Text = string.Empty;
        }
    }
}
