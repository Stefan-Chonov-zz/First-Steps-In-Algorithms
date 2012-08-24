using System.Drawing;
using System.Collections.Generic;

class DifferencesBetweenTwoMatrices
{
    /// <summary>
    /// Count new elements in matrix.
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="matrix2"></param>
    /// <returns>byte</returns>
    public static byte CountAllDifferences(char[,] firstMatrix, char[,] secondMatrix)
    {
        byte counter = 0;

        for (int i = 0; i < firstMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.GetLength(1); j++)
            {
                if (firstMatrix[i, j] != secondMatrix[i, j])
                {
                    counter++;
                }
            }
        }

        return counter;
    }

    /// <summary>
    /// Extract a row and column from the array when new element is found.
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="matrix2"></param>
    /// <returns>Point</returns>
    public static Point GetPositionOfFirstDifferenceElement(char[,] firstMatrix, char[,] secondMatrix)
    {
        Point position = new Point();

        for (int i = 0; i < firstMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < secondMatrix.GetLength(1); j++)
            {
                if (firstMatrix[i, j] != secondMatrix[i, j])
                {
                    position.X = i;
                    position.Y = j;
                    return position;
                }
            }
        }

        return position;
    }

    public static Point[] GetPositionsOfAllDifferences(char[,] firstMatrix, char[,] secondMatrix)
    {
        List<Point> listWithPositions = new List<Point>();
        Point position;

        for (int i = 0; i < firstMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < firstMatrix.GetLength(1); j++)
            {
                if (firstMatrix[i, j] != secondMatrix[i, j])
                {
                    position = new Point(i, j);
                    listWithPositions.Add(position);
                }
            }
        }

        Point[] allPositions = listWithPositions.ToArray();

        return allPositions;
    }
}