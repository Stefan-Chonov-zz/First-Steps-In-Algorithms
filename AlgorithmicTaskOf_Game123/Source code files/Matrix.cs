using System;
using System.Collections;

public class Matrix : IEnumerable
{
    private char[,] matrix;

    public Matrix(int rowSize, int columnSize)
    {
        matrix = new char[rowSize, columnSize];
    }
   
    public char this[int x, int y]
    {
        get
        {
            return matrix[x, y];
        }
        set
        {
            matrix[x, y] = value;
        }
    }

    public int GetLength(byte dimension)
    {
        return matrix.GetLength(dimension);
    }

    public IEnumerator GetEnumerator()
    {
        return GetEnumerator();
    }

    public static bool operator ==(Matrix matrix, char character)
    {
        return matrix == character;
    }

    public static bool operator !=(Matrix matrix, char character)
    {
        return matrix != character;
    }
}