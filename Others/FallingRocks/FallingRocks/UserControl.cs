using System;
using System.Drawing;

class UserControl
{
    public Point PlayerControlsListener(Player player)
    {
        Point newPosition = player.Position;

        if (Console.KeyAvailable)
        {
            Console.SetCursorPosition(player.Position.X, player.Position.Y);
            Console.Clear();

            ConsoleKeyInfo pressedKey = Console.ReadKey();

            if (pressedKey.Key == MOVE_LEFT)
            {
                if ((player.Position.X - 1) >= 0)
                {
                    newPosition = new Point((player.Position.X - 1), player.Position.Y);
                }
            }
            else if (pressedKey.Key == MOVE_RIGHT)
            {
                if ((player.Position.X + 1) < (Console.WindowWidth - 2))
                {
                    newPosition = new Point((player.Position.X + 1), player.Position.Y);
                }
            }
        }

        return newPosition;
    }

    private const ConsoleKey MOVE_LEFT = ConsoleKey.LeftArrow;
    private const ConsoleKey MOVE_RIGHT = ConsoleKey.RightArrow;
}
