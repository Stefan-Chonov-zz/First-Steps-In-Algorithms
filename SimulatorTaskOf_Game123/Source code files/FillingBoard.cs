using System.Windows;

class FillingBoard
{
    /// <summary>
    /// Fill all elements in given matrix with 'character'.
    /// </summary>
    /// <param name="board"></param>
    /// <param name="character"></param>
    public static void FillingAllElementsWith(char[,] board, char character)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = character;
            }
        }
    }

    /// <summary>
    /// Multiple filling of elements at given positions.
    /// </summary>
    /// <param name="board"></param>
    /// <param name="listOfPositions"></param>
    /// <param name="character"></param>
    public static void MultipleFillingOfElements(char[,] board, Point[] listOfPositions, char symbol)
    {
        for (int i = 0; i < listOfPositions.Length; i++)
        {
            board[(int)listOfPositions[i].X, (int)listOfPositions[i].Y] = symbol;
        }
    }

    /// <summary>
    /// Single filling of element at given position
    /// </summary>
    /// <param name="board"></param>
    /// <param name="position"></param>
    /// <param name="symbol"></param>
    public static void SingleFillingOfElement(char[,] board, Point position, char symbol)
    {
        board[(int)position.X, (int)position.Y] = symbol;
    }
}