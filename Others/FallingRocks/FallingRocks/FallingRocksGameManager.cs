using System;
using System.Drawing;
using System.Collections.Generic;

class FallingRocksGameManager : Rock
{
    public List<Rock> SimulateFalling(List<Rock> rocks)
    {
        foreach (Rock rock in rocks)
        {
            rock.Position = new Point(rock.Position.X, rock.Position.Y + 1);
        }

        return rocks;
    }

    public bool IsGameOver(Player player, List<Rock> rocks)
    {
        bool isGameOver = false;

        foreach (Rock rock in rocks)
        {
            if (rock.Position.Y == (Console.WindowHeight - 1))
            {
                bool doesCollision = CheckForCollision(player, rock);

                if (doesCollision)
                {
                    isGameOver = true;
                    break;
                }
            }
        }

        return isGameOver;
    }

    public bool CheckForCollision(Player player, Rock rock)
    {
        bool isHaveCollision = false;

        if ((rock.Position.X == player.Position.X) ||
            (rock.Position.X == player.Position.X + 1) ||
            (rock.Position.X == player.Position.X + 2))
        {
            isHaveCollision = true;
        }

        return isHaveCollision;
    }
}
