using System;

class CommonFuctionalityOfBoard
{
    public const char FIGURE_A = 'A';
    public const char FIGURE_B = 'B';
    public const char EMPTY_BOX = '-';

    public bool IsBoardContainInvalidFigure(char[,] newBoard)
    {
        bool isContainInvalidFigure = false;

        for (int i = 0; i < newBoard.GetLength(0); i++)
        {
            for (int j = 0; j < newBoard.GetLength(1); j++)
            {
                if ((newBoard[i, j] != FIGURE_A) &&
                    (newBoard[i, j] != FIGURE_B) &&
                    (newBoard[i, j] != EMPTY_BOX))
                {
                    isContainInvalidFigure = true;

                    return isContainInvalidFigure;
                }
            }
        }

        return isContainInvalidFigure;
    }

    /// <summary>
    /// Check is any element of 'newBoard' is stepped on element of 'oldBoard'.
    /// </summary>
    /// <param name="oldBoard"></param>
    /// <param name="newBoard"></param>
    /// <param name="figure"></param>
    /// <returns>bool</returns>
    public static bool IsGivenElementOverlappedInNewBoard(char[,] oldBoard, char[,] newBoard, char element)
    {
        int lengthOfRows = oldBoard.GetLength(0);
        int lengthOfColumns = oldBoard.GetLength(1);

        for (int i = 0; i < lengthOfRows; i++)
        {
            for (int j = 0; j < lengthOfColumns; j++)
            {
                if (oldBoard[i, j] == element)
                {
                    if (newBoard[i, j] != element)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
    
    /// <summary>
    /// Count how many times element is appear in board.
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="figure"></param>
    /// <returns>int</returns>
    public static int CountAppearancesOfElementInArray(char[,] board, char element)
    {
        int countAppearance = 0;

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == element)
                {
                    countAppearance++;
                }
            }
        }

        return countAppearance;
    }
    
    /// <summary>
    /// Print board on Console screen.
    /// </summary>
    /// <param name="board"></param>
    public static void PrintBoardOnScreen(char[,] board)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0}", board[i,j]);
            }

            Console.WriteLine();
        }
    }
}