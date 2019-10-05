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
                    Cells.Add(new Ground(x, y));
                }
            }
        }

        public List<BaseCell> Cells { get; } = new List<BaseCell>();


        public void TryToStep(Direction direction)
        {
            BaseCell cellToMove = null;

            var hero = Player.GetPlayer;

            switch (direction)
            {
                case Direction.Up:
                    cellToMove = this[hero.Coordinates.X, hero.Coordinates.Y - 1];
                    break;
                case Direction.Right:
                    cellToMove = this[hero.Coordinates.X + 1, hero.Coordinates.Y ];
                    break;
                case Direction.Down:
                    cellToMove = this[hero.Coordinates.X, hero.Coordinates.Y + 1];
                    break;
                case Direction.Left:
                    cellToMove = this[hero.Coordinates.X - 1, hero.Coordinates.Y];
                    break;
            }

            if (cellToMove?.TryToStep() ?? false)
            {
                hero.Coordinates = cellToMove.Coordinates;
            }
        }

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
