using System;
using System.Collections.Generic;

class Painter
{
    public void DrawPlayerOnScreen(Player player)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(player.Position.X, player.Position.Y);
        Console.Write(player.Shape);
    }

    public void DrawRockOnScreen(Rock rock)
    {
        Console.ForegroundColor = rock.Color;
        Console.SetCursorPosition(rock.Position.X, rock.Position.Y);
        Console.Write(rock.Shape);
    }

    public void DrawAllRocksOnScreen(List<Rock> rocks)
    {
        foreach (Rock rock in rocks)
        {
            DrawRockOnScreen(rock);
        }
    }

    public void EraseTailOfRock(List<Rock> rocks)
    {
        foreach (Rock rock in rocks)
        {
            Console.SetCursorPosition(rock.Position.X, rock.Position.Y);
            Console.Write(' ');
        }
    }
}