using System;
using System.Drawing;

class Rock : IRock
{
    public char Shape
    {
        get
        {
            return this.shape;
        }
        set
        {
            this.shape = value;
        }
    }

    public ConsoleColor Color
    {
        get
        {
            return this.color;
        }
        set
        {
            this.color = value;
        }
    }

    public Point Position
    {
        get
        {
            return this.position;
        }
        set
        {
            this.position = value;
        }
    }

    private char shape;
    private ConsoleColor color;
    private Point position;
}
