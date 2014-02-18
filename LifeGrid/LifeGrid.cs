using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifeGrid
{
    public class LifeGrid
    {
        private int width;
        private int depth;
        private bool[,] grid;

        public LifeGrid(int w, int d)
        {
            width = w;
            depth = d;
            grid = new bool[w, d];
        }

        public LifeGrid Gestate()
        {
            var newLife = new LifeGrid(width, depth);
            for (int y = 0; y < depth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (LivesInNewGeneration(IsLive(x, y), CountNeighbours(x, y)))
                        newLife.SetCell(x, y);
                }
            }
            return newLife;
        }

        public int CountNeighbours(int x, int y)
        {
            int c = 0;
            // N
            if (y > 0 && grid[x, y - 1]) c++;
            // NW
            if (y > 0 && x > 0 && grid[x - 1, y - 1]) c++;
            // NE
            if (y > 0 && x < width - 1 && grid[x + 1, y - 1]) c++;
            // E
            if (x < width - 1 && grid[x + 1, y]) c++;
            // W
            if (x > 0 && grid[x - 1, y]) c++;
            // SW
            if (y < depth - 1 && x > 0 && grid[x - 1, y + 1]) c++;
            // SE
            if (y < depth - 1 && x < width - 1 && grid[x + 1, y + 1]) c++;
            // S
            if (y < depth - 1 && grid[x, y + 1]) c++;
            return c;
        }

        public static bool LivesInNewGeneration(bool startsLive, int neighbourCount)
        {
            return (neighbourCount==3 || (neighbourCount==2 && startsLive));
        }

        public void SetCell(int x, int y)
        {
            grid[x, y] = true;
        }

        public bool IsLive(int x, int y)
        {
            return grid[x, y];
        }
    }
}
