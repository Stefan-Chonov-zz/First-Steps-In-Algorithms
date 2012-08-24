using System;
using System.Collections.Generic;
using System.Drawing;

class InitializePlayerAndRocks
{
    public Player InitializePlayer(int left, int top)
    {
        Player player = new Player();
        player.Color = ConsoleColor.White;
        player.Position = new Point(top, left);
        player.Shape = "(0)";
        return player;
    }

    public Rock InitializeRock(int left, int top)
    {
        Random random = new Random();
        byte randomColor = (byte)random.Next(0, fontColors.Count);
        byte randomShape = (byte)random.Next(0, shapes.Count);
        Rock rock = new Rock();
        rock.Shape = shapes[randomShape];
        rock.Color = fontColors[randomColor];
        rock.Position = new Point(left, top);

        return rock;
    }

    private List<ConsoleColor> fontColors = new List<ConsoleColor>
        {
            ConsoleColor.Cyan,
            ConsoleColor.Yellow,
            ConsoleColor.DarkYellow,
            ConsoleColor.Magenta,
            ConsoleColor.Green
        };

    private List<char> shapes = new List<char>
        {
            '^', '@',
            '*', '&', 
            '+', '%',
            '$', '#', 
            '!', '.', 
            ';', '-'
        };
}
