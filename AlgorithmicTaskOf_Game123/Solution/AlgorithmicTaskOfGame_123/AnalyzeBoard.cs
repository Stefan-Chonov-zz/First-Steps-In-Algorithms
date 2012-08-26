using System.Drawing;
using System.Collections.Generic;
using System;

class AnalyzeBoard
{
    private readonly char[,] board = null;
    private delegate List<Point> SearchDirection(int row, int col, int limitOfSearching, char character);  

    public AnalyzeBoard(char[,] board)
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

    public Point[] GetAdjancedPositionsSplitedByElementHorizontal(Point[] position, char character)
    {
        byte limitOfSearching = 2;
        Point[] searchedPositions = null;

        for (int i = 0; i < position.Length; i++)
        {
            int currentRow = position[i].X;

            int previousCol = position[i].Y - 1;
            int nextCol = position[i].Y + 1;

            if (previousCol < 0 || nextCol >= board.GetLength(1))
            {
                continue;
            }

            if ((this.board[currentRow, previousCol] == character) &&
                (this.board[currentRow, nextCol] == character))
            {
                searchedPositions = new Point[limitOfSearching];

                for (int j = 0; j < limitOfSearching; j++)
                {
                    searchedPositions[j] = new Point();
                }

                searchedPositions[0].X = currentRow;
                searchedPositions[0].Y = previousCol;

                searchedPositions[1].X = currentRow;
                searchedPositions[1].Y = nextCol;

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

            if ((previousRow < 0) || (nextRow >= board.GetLength(0)))
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
    public Point[] ExtractPositionsOfAdjacentElementsVariant1(char element, int numberOfAdjacentElements)
    {
        Point[] allPositionsThatContainElement = GetAllPositionsOfElement(this.board, element);
        Point[] mixingPositions = MixPositions(allPositionsThatContainElement);

        SearchDirection searchDirection = LeftDiagonal;
        Point[] positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        bool isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = RightDiagonal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = Horizontal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = Vertical;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        return positionsOfElements;
    }

    public Point[] ExtractPositionsOfAdjacentElementsVariant2(char element, int numberOfAdjacentElements)
    {
        Point[] allPositionsThatContainElement = GetAllPositionsOfElement(this.board, element);
        Point[] mixingPositions = MixPositions(allPositionsThatContainElement);

        SearchDirection searchDirection = RightDiagonal;
        Point[] positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        bool isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = LeftDiagonal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = Horizontal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = Vertical;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        return positionsOfElements;
    }

    public Point[] ExtractPositionsOfAdjacentElementsVariant3(char element, int numberOfAdjacentElements)
    {
        Point[] allPositionsThatContainElement = GetAllPositionsOfElement(this.board, element);
        Point[] mixingPositions = MixPositions(allPositionsThatContainElement);

        SearchDirection searchDirection = Horizontal;
        Point[] positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        bool isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = Vertical;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = LeftDiagonal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = RightDiagonal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        return positionsOfElements;
    }

    public Point[] ExtractPositionsOfAdjacentElementsVariant4(char element, int numberOfAdjacentElements)
    {
        Point[] allPositionsThatContainElement = GetAllPositionsOfElement(this.board, element);
        Point[] mixingPositions = MixPositions(allPositionsThatContainElement);

        SearchDirection searchDirection = Vertical;
        Point[] positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        bool isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = Horizontal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = LeftDiagonal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        if (isSequenceValid)
        {
            return positionsOfElements;
        }

        searchDirection = RightDiagonal;
        positionsOfElements = GetPositionsOfSequence(mixingPositions, numberOfAdjacentElements, element, searchDirection);
        isSequenceValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(positionsOfElements.Length, numberOfAdjacentElements);

        return positionsOfElements;
    }

    private Point[] GetPositionsOfSequence(Point[] possiblePositions, int numberOfPositions, char character, SearchDirection searchDirection)
    {
        List<Point> elementsPositionsInBoard = null;
        Point[] positions = null;
        
        for (int i = 0; i < possiblePositions.Length; i++)
        {
            elementsPositionsInBoard = new List<Point>();
            elementsPositionsInBoard = searchDirection(possiblePositions[i].X, possiblePositions[i].Y, numberOfPositions, character);
            bool isLengthValid = ValidationOfNumbers.CompareTwoNummbersIsEqual(elementsPositionsInBoard.Count, numberOfPositions);

            if (isLengthValid)
            {
                break;
            }
        }

        positions = elementsPositionsInBoard.ToArray();
        return positions;
    }

    public Point[] MixPositions(Point[] positions)
    {
        Point[] mixedPositions = new Point[positions.Length];
        Random random = new Random();

        for (int i = 0; i < positions.Length - 1; i++)
        {
            int randomPosition = random.Next(0, positions.Length);            
            bool isPositionRepead = mixedPositions.IsContain(positions[randomPosition]);
            if (isPositionRepead)
            {
                i--;                
                continue;
            }

            mixedPositions[i] = positions[randomPosition];
        }

        return mixedPositions;
    }

    public Point[] GetAllPositionsOfElement(char[,] board, char element)
    {
        List<Point> listWithPositions = new List<Point>();

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == element)
                {
                    listWithPositions.Add(new Point(i, j));
                }
            }
        }

        Point[] allPositionsOfCurrentElement = listWithPositions.ToArray();

        return allPositionsOfCurrentElement;
    }

    public bool IsDirectionOfPositionsAreVertical(Point[] positions)
    {
        Point startPositions = positions[0];
        bool isDirectionVertical = false;
        int counter = 0;

        for (int i = 1; i < positions.Length; i++)
        {
            if ((positions[i].X == startPositions.X) &&
                (positions[i].Y == startPositions.Y + i))
            {
                counter++;
            }
        }

        if (counter == positions.Length)
        {
            isDirectionVertical = true;
        }

        return isDirectionVertical;
    }

    public bool IsDirectionOfPositionsAreHorizontal(Point[] positions)
    {
        Point startPositions = positions[0];
        bool isDirectionHorizontal = false;
        int counter = 0;

        for (int i = 1; i < positions.Length; i++)
        {
            if ((positions[i].X == startPositions.X + i) &&
                (positions[i].Y == startPositions.Y))
            {
                counter++;
            }
        }

        if (counter == positions.Length)
        {
            isDirectionHorizontal = true;
        }

        return isDirectionHorizontal;
    }

    public bool IsDirectionOfPositionsAreRightDiagonal(Point[] positions)
    {
        Point startPositions = positions[0];
        bool isDirectionRightDiagonal = false;
        int counter = 0;

        for (int i = 1; i < positions.Length; i++)
        {
            if ((positions[i].X == startPositions.X + i) &&
                (positions[i].Y == startPositions.Y + i))
            {
                counter++;
            }
        }

        if (counter == positions.Length)
        {
            isDirectionRightDiagonal = true;
        }

        return isDirectionRightDiagonal;
    }

    public bool IsDirectionOfPositionsAreLeftDiagonal(Point[] positions)
    {
        if (positions.Length == 0)
        {
            //throw new MissingPositions("");
        }

        Point startPositions = positions[0];
        bool isDirectionLeftDiagonal = false;
        int counter = 0;

        for (int i = 1; i < positions.Length; i++)
        {
            if ((positions[i].X == startPositions.X - i) &&
                (positions[i].Y == startPositions.Y - i))
            {
                counter++;
            }
        }

        if (counter == positions.Length)
        {
            isDirectionLeftDiagonal = true;
        }

        return isDirectionLeftDiagonal;
    }
}