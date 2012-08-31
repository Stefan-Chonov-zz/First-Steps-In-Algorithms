using System;
using System.Collections.Generic;
using System.Threading;

namespace FallingRocks
{
    partial class FallingRocks : FallingRocksGameManager
    {
        private const int SPEED = 100;

        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Random randomColumn = new Random();
            int rowInConsole = 0;
            int columnInConsole = 0;

            // Initialize Player            
            InitializePlayerAndRocks initializePlayerAndRocks = new InitializePlayerAndRocks();
            Player player = initializePlayerAndRocks.InitializePlayer((Console.WindowHeight - 1), (Console.WindowWidth / 2));

            FallingRocksGameManager fallingRockManager = new FallingRocksGameManager();
            Painter drawPlayerAndRocks = new Painter();
            UserControl userControl = new UserControl();
            Rock rock = new Rock();
            List<Rock> rocks = new List<Rock>();

            while (true)
            {
                player.Position = userControl.PlayerControlsListener(player);
                drawPlayerAndRocks.DrawPlayerOnScreen(player);

                // Create rock and give it random position on screen
                columnInConsole = randomColumn.Next(0, Console.WindowWidth);
                rock = initializePlayerAndRocks.InitializeRock(columnInConsole, rowInConsole);
                rocks.Add(rock);

                bool isGameOver = fallingRockManager.IsGameOver(player, rocks);
                if (isGameOver)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Game over!");
                    break;
                }

                // If the rock reach to the lowest part of the screen it remove!
                for (int i = 0; i < rocks.Count; i++)
                {
                    if (rocks[i].Position.Y == (Console.WindowHeight - 1))
                    {
                        Console.SetCursorPosition(rocks[i].Position.X, rocks[i].Position.Y);
                        Console.Clear();

                        //redraw player
                        drawPlayerAndRocks.DrawPlayerOnScreen(player);

                        rocks.RemoveAt(i);
                    }
                }

                drawPlayerAndRocks.EraseTailOfRock(rocks);
                fallingRockManager.SimulateFalling(rocks);

                drawPlayerAndRocks.DrawAllRocksOnScreen(rocks);

                Thread.Sleep(SPEED);
            }
        }
    }
}
