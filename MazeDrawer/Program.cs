using System;
using MazeLibrary;

namespace MazeDrawer
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze(7, 16);

            var instructions = " \n";

            var key = new ConsoleKeyInfo();
            Console.WriteLine(instructions + Drawer.Create(maze));
            while (key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                    {
                        maze.TryToStep(Direction.Up);
                        break;
                    }

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                    {
                        maze.TryToStep(Direction.Left);
                        break;
                    }

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                    {
                        maze.TryToStep(Direction.Right);
                        break;
                    }

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                    {
                        maze.TryToStep(Direction.Down);
                        break;
                    }
                }

                Console.WriteLine(instructions + Drawer.Create(maze));
            }
        }
    }
}
