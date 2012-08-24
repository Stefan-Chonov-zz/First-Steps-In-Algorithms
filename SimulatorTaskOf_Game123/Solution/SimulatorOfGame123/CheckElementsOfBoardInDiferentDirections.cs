using System.Collections.Generic;
using System.Windows;

class CheckElementsOfBoardInDiferentDirections
{
    private readonly char[,] board = null;

    public CheckElementsOfBoardInDiferentDirections(char[,] board)
    {
        this.board = board;
    }

    public List<Point> Horizontal(int row, int col, int limit, char character)
    {
        List<Point> listOfPositions = new List<Point>();
        Point position = new Point();
        
        while (limit > 0)
        {
            if (col == this.board.GetLength(1))
            {
                break;
            }

            if (this.board[row, col] != character)
            {
                break;
            }

            position = new Point();
            position.X = row;
            position.Y = col;

            // Add new position in list
            listOfPositions.Add(position);

            limit--;
            col++;
        }

        return listOfPositions;
    }

    public List<Point> Vertical(int row, int col, int limit, char character)
    {
        List<Point> listOfPositions = new List<Point>();
        Point position;

        while (limit > 0)
        {
            if (row == this.board.GetLength(0))
            {
                break;
            }

            if (this.board[row, col] != character)
            {
                break;
            }

            position = new Point();
            position.X = row;
            position.Y = col;

            // Add new position in list
            listOfPositions.Add(position);

            limit--;
            row++;
        }

        return listOfPositions;
    }

    public List<Point> RightDiagonal(int row, int col, int limit, char character)
    {
        List<Point> listOfPositions = new List<Point>();
        Point position;

        while (limit > 0)
        {
            if ((row == this.board.GetLength(0)) || 
                (col == this.board.GetLength(1)))
            {
                break;
            }

            if (this.board[row, col] != character)
            {
                break;
            }

            position = new Point();
            position.X = row;
            position.Y = col;
            
            // Add new position in list
            listOfPositions.Add(position);

            limit--;
            row++;
            col++;
        }

        return listOfPositions;
    }

    public List<Point> LeftDiagonal(int row, int col, int limit, char character)
    {
        List<Point> listOfPositions = new List<Point>();
        Point position;        

        while (limit > 0)
        {
            if ((row >= this.board.GetLength(0)) || (col < 0))
            {
                break;
            }

            if (this.board[row, col] != character)
            {
                break;
            }

            position = new Point();
            position.X = row;
            position.Y = col;

            // Add new position in list
            listOfPositions.Add(position);

            limit--;
            row++;
            col--;
        }

        return listOfPositions;
    }

    public Point[] GetTwoPositionsSplitedByElementHorizontal(Point[] position, char character, int limitOfSearching)
    {
        Point[] searchedPositions = null;

        for (int i = 0; i < position.Length; i++)
        {
            int currentRow = (int)position[i].X;

            int previousCol = (int)position[i].Y - 1;
            int nextCol = (int)position[i].Y + 1;

            if (previousCol < 0 ||  nextCol > board.GetLength(1))
            {
                continue;
            }

            if ((this.board[currentRow, previousCol] == character) &&
                (this.board[currentRow,  nextCol] == character))
            {
                searchedPositions = new Point[limitOfSearching];

                for (int j = 0; j < limitOfSearching; j++)
                {
                    searchedPositions[j] = new Point();
                }

                searchedPositions[0].X = currentRow;
                searchedPositions[0].Y = previousCol;

                searchedPositions[1].X = currentRow;
                searchedPositions[1].Y =  nextCol;

                break;
            }
        }

        return searchedPositions;
    }

    public Point[] GetTwoPositionsSplitedByElementVertical(Point[] position, char character, int limitOfSearching)
    {
        Point[] searchedPositions = null;

        for (int i = 0; i < position.Length; i++)
        {
            int currentCol = (int)position[i].Y;

            int previousRow = (int)position[i].X - 1;
            int nextRow = (int)position[i].X + 1;

            if ((previousRow < 0) || (nextRow > board.GetLength(1)))
            {
                continue;
            }

            if ((this.board[previousRow, currentCol] == character) &&
                (this.board[nextRow, currentCol] == character))
            {
                searchedPositions = new Point[limitOfSearching];

                for (int j = 0; j < limitOfSearching; j++)
                {
                    searchedPositions[j] = new Point();
                }

                searchedPositions[0].X = previousRow;
                searchedPositions[0].Y = currentCol;

                searchedPositions[1].X = nextRow;
                searchedPositions[1].Y = currentCol;

                break;
            }
        }

        return searchedPositions;
    }

    public Point[] GetTwoPositionsSplitedByElementLeftDiagonal(Point[] listOfPositionsOfAppearancedElements, char character, int limitOfSearching)
    {
        Point[] searchedPositions = null;

        for (int i = 0; i < listOfPositionsOfAppearancedElements.Length; i++)
        { 
            int previuosRow = (int)listOfPositionsOfAppearancedElements[i].X - 1;
            int previousCol = (int)listOfPositionsOfAppearancedElements[i].Y - 1;

            if (previuosRow < 0 || previousCol < 0)
            {
                continue;
            }
                        
            int nextRow = (int)listOfPositionsOfAppearancedElements[i].X + 1;
            int nextCol = (int)listOfPositionsOfAppearancedElements[i].Y + 1;

            if (nextRow >= board.GetLength(0) ||
                nextCol >= board.GetLength(1))
            {
                continue;
            }

            if ((this.board[previuosRow, previousCol] == character) &&
                (this.board[nextRow, nextCol] == character))
            {
                searchedPositions = new Point[limitOfSearching];

                for (int j = 0; j < limitOfSearching; j++)
                {
                    searchedPositions[j] = new Point();
                }

                searchedPositions[0].X = previuosRow;
                searchedPositions[0].Y = previousCol;

                searchedPositions[1].X = nextRow;
                searchedPositions[1].Y = nextCol;

                break;
            }
        }

        return searchedPositions;
    }

    public Point[] GetTwoPositionsSplitedByElementRightDiagonal(Point[] position, char character, int limitOfSearching)
    {
        Point[] searchedPositions = null;

        for (int i = 0; i < position.Length; i++)
        {
            int previousRow = (int)position[i].X - 1;
            int nextCol = (int)position[i].Y + 1;

            if (previousRow < 0 || nextCol >= board.GetLength(1))
            {
                continue;
            }

            int nextRow = (int)position[i].X + 1;
            int previousCol = (int)position[i].Y - 1;

            if (nextRow > board.GetLength(0) || previousCol < 0)
            {
                continue;
            }

            if ((this.board[previousRow, nextCol] == character) &&
                (this.board[nextRow, previousCol] == character))
            {
                searchedPositions = new Point[limitOfSearching];

                for (int j = 0; j < limitOfSearching; j++)
                {
                    searchedPositions[j] = new Point();
                }

                searchedPositions[0].X = previousRow;
                searchedPositions[0].Y = nextCol;

                searchedPositions[1].X = nextRow;
                searchedPositions[1].Y = previousCol;

                break;
            }
        }

        return searchedPositions;
    }
}