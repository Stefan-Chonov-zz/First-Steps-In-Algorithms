using System;

class StateOfBoard
{
    public delegate void MatrixEventHandler(object sender, MatrixFilledArgs args);
    public event MatrixEventHandler MatrixFilledEvent;
    
    /// <summary>
    /// Catch is board filled.
    /// </summary>
    public void NotifyIsBoardFilled(bool isBoardFilled, char[,] matrix)
    {
        if (isBoardFilled)
        {
            if (this.MatrixFilledEvent != null)
            {
                MatrixFilledArgs args = new MatrixFilledArgs(matrix);
                MatrixFilledEvent(isBoardFilled, args);
            }
        }
    }
}