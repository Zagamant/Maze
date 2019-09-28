using System;
using System.Collections.Generic;
using System.Linq;
using MazeLibrary.Cells;

namespace MazeLibrary
{
    public class Maze
    {
        public int Height { get; }
        public int Width { get; }

        public Maze(int height, int width)
        {
            this.Height = height;
            this.Width = width;

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Cells.Add(new Wall(x, y));
                }
            }
        }

        public List<BaseCell> Cells { get; } = new List<BaseCell>();

        public BaseCell this[int x, int y]
        {

            //var cell = Maze[1,2];
            get
            {
                return Cells.SingleOrDefault(cell => cell.Coordinates.X == x && cell.Coordinates.Y == y);
            }

            //Maze[1,2] = new Wall(1,2);
            set
            {
                var oldCell = this[value.Coordinates.X, value.Coordinates.Y];
                if (oldCell != null)
                {
                    Cells.Remove(oldCell);
                }
                Cells.Add(value);
            }
        }
    }
}
