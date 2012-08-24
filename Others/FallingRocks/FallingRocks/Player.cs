using System;
using System.Drawing;

class Player : IPlayer
{

    public string Shape
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

    public System.Drawing.Point Position
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

    private string shape = null;
    private ConsoleColor color;
    private Point position;
}
