using System;

class MatrixFilledArgs : EventArgs
{
    private readonly object matrix = null;

    public MatrixFilledArgs(object matrix)
    {
        this.matrix = matrix;
    }
        
    public object Matrix
    {
        get
        {
            return this.matrix;
        }
    }
}