using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LifeGrid;

namespace ConwayGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int generation = 0;
            int width = 79;
            int depth = 30;

            LifeGrid.LifeGrid grid = new LifeGrid.LifeGrid(width, depth);

            int t = DateTime.Now.Millisecond % 100;
            Console.WriteLine(t);
            Random r = new Random(t);

            for(int y=0; y<depth; y++)
            {
                for(int x=0; x<width; x++)
                {
                    if (r.Next(100) > 60)
                    {
                        grid.SetCell(x, y);
                    }
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(generation++);
                for(int y=0; y<depth; y++)
                {
                    for(int x=0; x<width; x++)
                    {
                        Console.Write(grid.IsLive(x, y) ? "*": " ");
                    }
                    Console.WriteLine();
                }
                grid = grid.Gestate();
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
