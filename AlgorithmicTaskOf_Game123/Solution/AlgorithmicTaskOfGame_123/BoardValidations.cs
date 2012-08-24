using System;
using System.Drawing;

class BoardValidations
{
    private const byte LIMIT_BOXES = 3;

    /// <summary>
    /// Check is 'newBoard' meet of requirments for valid board.
    /// </summary>
    /// <param name="newBoard"></param>
    /// <param name="oldBoard"></param>
    /// <param name="currentFigure"></param>
    public void BoardValidationProcess(char[,] newBoard, char[,] oldBoard, char currentFigure)
    {
        // Check is any element of 'newBoard' is stepped on element of 'oldBoard'.
        bool isOldMatrixCovered = CommonFuctionalityOfBoard.IsGivenElementOverlappedInNewBoard(oldBoard, newBoard, currentFigure);
        if (isOldMatrixCovered)
        {
            throw new InvalidBoardException(Notifications.OVERLAPPED_BOARD_MESSAGE);
        }

        CommonFuctionalityOfBoard commonFunctionalityyOfBoard = new CommonFuctionalityOfBoard();
        bool isContainInvalidFigure = commonFunctionalityyOfBoard.IsBoardContainInvalidFigure(newBoard);
        if (isContainInvalidFigure)
        {
            throw new InvalidBoardException(Notifications.INVALID_FIGURE_ON_BOARD_MESSAGE);
        }

        // Extract position of first appearance of new element in new board
        Point positionOfFirstNewElement = DifferencesBetweenTwoMatrices.GetPositionOfFirstDifferenceElement(oldBoard, newBoard);
        int row = positionOfFirstNewElement.X;
        int col = positionOfFirstNewElement.Y;

        if ((row < 0) || (col < 0))
        {
            throw new InvalidBoardException(Notifications.MISSING_NEW_ELLEMENTS_MESSAGE);
        }

        // Check number of new elements in board
        byte countNewElementsInBoard = DifferencesBetweenTwoMatrices.CountAllDifferences(newBoard, oldBoard);
        bool isCountOfNewElementsIsInTheBounds = ValidationOfNumbers.IsNumberInBounds(countNewElementsInBoard, 1, 3);
        if (!isCountOfNewElementsIsInTheBounds)
        {
            throw new InvalidBoardException(Notifications.TO_MANY_NEW_ELLEMENTS_MESSAGE);
        }

        byte greatestLengthOfAdjacentSequence = GetGreatestLengthAtGivenStartPosition(newBoard, currentFigure, row, col);
        if (greatestLengthOfAdjacentSequence < countNewElementsInBoard)
        {
            throw new InvalidBoardException(Notifications.INVALID_TURN_MESSAGE);
        }
    }
    
    /// <summary>
    /// Check in 4 directions. 
    /// Right diagonal, Left diagonal,
    /// Horizontal, Vertical.
    /// </summary>
    /// <param name="newBoard"></param>
    /// <param name="currentFigure"></param>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public virtual byte GetGreatestLengthAtGivenStartPosition(char[,] newBoard, char currentFigure, int row, int col)
    {
        AnalyzeBoard checkBoard = new AnalyzeBoard(newBoard);
        int countElementsRightDiagonal = checkBoard.RightDiagonal(row, col, LIMIT_BOXES, currentFigure).Count;
        int countElementsLeftDiagonal = checkBoard.LeftDiagonal(row, col, LIMIT_BOXES, currentFigure).Count;
        int countElementsHorizontal = checkBoard.Horizontal(row, col, LIMIT_BOXES, currentFigure).Count;
        int countVertical = checkBoard.Vertical(row, col, LIMIT_BOXES, currentFigure).Count;

        byte getMaxLenghtOfSequence = (byte)Math.Max(countElementsLeftDiagonal, countElementsRightDiagonal);
        getMaxLenghtOfSequence = (byte)Math.Max(getMaxLenghtOfSequence, countElementsHorizontal);
        getMaxLenghtOfSequence = (byte)Math.Max(getMaxLenghtOfSequence, countVertical);

        return getMaxLenghtOfSequence;
    }
}