using System.Drawing;
using System.Collections.Generic;

class AnalyzeBoard
{
    private readonly char[,] board = null;
    private delegate Point[] SearchDirection(int row, int col, int limitOfSearching, char character);  

    public AnalyzeBoard(char[,] board)
    {
        this.board = board;
    }

    public Point[] Horizontal(int row, int col, int limit, char character)
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

        Point[] positions = listOfPositions.ToArray();
        return positions;
    }

    public Point[] Vertical(int row, int col, int limit, char character)
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

        Point[] positions = listOfPositions.ToArray();
        return positions;
    }

    public Point[] RightDiagonal(int row, int col, int limit, char character)
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

        Point[] positions = listOfPositions.ToArray();
        return positions;
    }

    public Point[] LeftDiagonal(int row, int col, int limit, char character)
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


        Point[] positions = listOfPositions.ToArray();
        return positions;
    }

    public Point[] GetAdjancedPositionsSplitedByElementHorizontal(Point[] position, char character)
    {
        byte limitOfSearching = 2;
        Point[] searchedPositions = null;

        for (int i = 0; i < position.Length; i++)
        {
            int currentRow = position[i].X;

            int previousCol = position[i].Y - 1;
            int nextCol = position[i].Y + 1;

            if (previousCol < 0 ||  nextCol >= board.GetLength(1))
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

    public Point[] GetAdjancedPositionsSplitedByElementVertical(Point[] position, char character)
    {
        byte limitOfSearching = 2;
        Point[] searchedPositions = null;

        for (int i = 0; i < position.Length; i++)
        {
            int currentCol = position[i].Y;

            int previousRow = position[i].X - 1;
            int nextRow = position[i].X + 1;

            if ((previousRow < 0) || (nextRow >= board.GetLength(1)))
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

    public Point[] GetAdjancedPositionsSplitedByElementLeftDiagonal(Point[] listOfPositionsOfAppearancedElements, char character)
    {
        byte limitOfSearching = 2;
        Point[] searchedPositions = null;

        for (int i = 0; i < listOfPositionsOfAppearancedElements.Length; i++)
        { 
            int previuosRow = listOfPositionsOfAppearancedElements[i].X - 1;
            int previousCol = listOfPositionsOfAppearancedElements[i].Y - 1;

            if (previuosRow < 0 || previousCol < 0)
            {
                continue;
            }
                        
            int nextRow = listOfPositionsOfAppearancedElements[i].X + 1;
            int nextCol = listOfPositionsOfAppearancedElements[i].Y + 1;

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

    public Point[] GetAdjancedPositionsSplitedByElementRightDiagonal(Point[] position, char character)
    {
        byte limitOfSearching = 2;
        Point[] searchedPositions = null;

        for (int i = 0; i < position.Length; i++)
        {
            int previousRow = position[i].X - 1;
            int nextCol = position[i].Y + 1;

            if (previousRow < 0 || nextCol >= board.GetLength(1))
            {
                continue;
            }

            int nextRow = position[i].X + 1;
            int previousCol = position[i].Y - 1;

            if (nextRow >= board.GetLength(0) || previousCol < 0)
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

    public Point[] GetPositionsOfTwoElementsSplitedBySpliter(char element, char spliter)
    {
        Point[] positionsOfAppearances = GetAllPositionsOfElement(spliter);
        if (positionsOfAppearances == null)
        {
            return null;            
        }

        Point[] foundedPositions = GetAdjancedPositionsSplitedByElementRightDiagonal(positionsOfAppearances, element);

        if (foundedPositions != null)
        {
            return foundedPositions;
        }

        foundedPositions = GetAdjancedPositionsSplitedByElementLeftDiagonal(positionsOfAppearances, element);

        if (foundedPositions != null)
        {
            return foundedPositions;
        }

        foundedPositions = GetAdjancedPositionsSplitedByElementVertical(positionsOfAppearances, element);

        if (foundedPositions != null)
        {
            return foundedPositions;
        }

        foundedPositions = GetAdjancedPositionsSplitedByElementHorizontal(positionsOfAppearances, element);

        return foundedPositions;
    }

    /// <summary>
    /// Extract all positions in board there are equal of given element.
    /// </summary>
    /// <param name="board"></param>
    /// <param name="numberOfElements"></param>
    /// <param name="element"></param>
    /// <returns></returns>
    public Point[] GetAllPositionsOfElement(char element)
    {
        List<Point> listWithPositions = new List<Point>();

        int numberOfRows = board.GetLength(0);
        int numberOfColumns = board.GetLength(1);

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                if (board[i, j] == element)
                {
                    listWithPositions.Add(new Point(i, j));
                }
            }
        }

        Point[] positions = null;

        if (listWithPositions.Count > 0)
        {
            positions = listWithPositions.ToArray();
        }

        return positions;
    }

    /// <summary>
    /// Search first appearance of element and return him position.
    /// </summary>
    /// <param name="board"></param>
    /// <param name="element"></param>
    /// <returns></returns>
    public Point GetPositionOfFirstAppearanceOfElement(char element)
    {
        Point positionOfElement = new Point(-1,-1);
        int row = board.GetLength(0);
        int col = board.GetLength(1);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (board[i, j] == element)
                {
                    positionOfElement = new Point(i, j);

                    return positionOfElement;
                }
            }
        }

        return positionOfElement;
    }

    /// <summary>
    /// Extract positions of adjacent elements.
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public Point[] ExtractPositionsOfAdjacentElements(char element, int numberOfAdjacentElements)
    {
        SearchDirection searchDirection = LeftDiagonal;
        Point[] positionsOfElements = GetPositionsOfSequence(
            this.board, numberOfAdjacentElements,
            element, searchDirection);
        bool isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = RightDiagonal;
        positionsOfElements = GetPositionsOfSequence(this.board, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = Horizontal;
        positionsOfElements = GetPositionsOfSequence(this.board, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = Vertical;
        positionsOfElements = GetPositionsOfSequence(this.board, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        return positionsOfElements;
    }

    private Point[] GetPositionsOfSequence(char[,] board, int numberOfPositions, char character, SearchDirection searchDirection)
    {
        Point[] elementsPositionsInBoard = null;

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {                
                elementsPositionsInBoard = searchDirection(i, j, numberOfPositions, character);
                bool isLengthValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(elementsPositionsInBoard.Length, numberOfPositions);

                if (isLengthValid)
                {
                    return elementsPositionsInBoard;
                }
            }
        }

        return elementsPositionsInBoard;
    }
}