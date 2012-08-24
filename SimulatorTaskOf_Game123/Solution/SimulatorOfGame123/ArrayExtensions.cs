using System.Linq;

public static class ArrayExtensions 
{
    /// <summary>
    /// Convert array of strings to two dimensional array of chars.
    /// </summary>
    /// <param name="strings"></param>
    /// <returns></returns>
    public static char[,] ToArrayOfChars(this string[] strings)
    {
        char[,] matrix = new char[strings.Length, strings[0].Length];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = strings[i][j];
            }
        }

        return matrix;
    }

    /// <summary>
    /// Check whether array is jagged.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="limitOfRows"></param>
    /// <param name="limitOfColumns"></param>
    /// <returns></returns>
    public static bool IsArrayJagged(this string[] array, uint limitOfRows, uint limitOfColumns)
    {
        bool isArrayJagged = false;

        int currentNumberOfValidRows = array.Count(x => x.Length == limitOfColumns);

        if (limitOfRows != currentNumberOfValidRows)
        {
            isArrayJagged = true;
        }

        return isArrayJagged;
    }

    /// <summary>
    /// Copy all elements to 'destination'.
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="newMatrix"></param>
    public static void CopyTo(this char[,] source, char[,] destination)
    {
        int numberOfRows = source.GetLength(0);
        int numberOfColumns = source.GetLength(1);

        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                destination[i, j] = source[i, j];
            }
        }
    }

    /// <summary>
    /// Check is two dimenssional array contain 'character'.
    /// </summary>
    /// <param name="board"></param>
    /// <param name="character"></param>
    /// <returns>bool</returns>
    public static bool IsContain(this char[,] array, char character)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (array[i, j] == character)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool IsContain(this string[] array, char character)
    {
        char[,] arrayOfChars = array.ToArrayOfChars();

        bool isContainCharacter = arrayOfChars.IsContain(character);

        return isContainCharacter;
    }
}