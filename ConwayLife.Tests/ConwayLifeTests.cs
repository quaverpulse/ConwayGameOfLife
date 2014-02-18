using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwayLife.Tests
{
    using LifeGrid;
    using NUnit.Framework;

    [TestFixture]
    public class ConwayLifeTests
    {
        LifeGrid populatedGrid;

        LifeGrid getLGrid()
        {
            var g = new LifeGrid(2, 2);
            g.SetCell(0, 0);
            g.SetCell(0, 1);
            g.SetCell(1, 1);
            return g;
        }

        [TestFixtureSetUp]
        public void Init()
        {
            // 100 021
            // 001 352
            // 111 132
            populatedGrid = new LifeGrid(3, 3);
            populatedGrid.SetCell(0, 0);
            populatedGrid.SetCell(2, 1);
            populatedGrid.SetCell(0, 2);
            populatedGrid.SetCell(1, 2);
            populatedGrid.SetCell(2, 2);
        }

        [TestCase(false, 0, Result = false)]
        [TestCase(false, 1, Result = false)]
        [TestCase(false, 2, Result = false)]
        [TestCase(false, 3, Result = true)]
        [TestCase(false, 4, Result = false)]
        [TestCase(false, 5, Result = false)]
        [TestCase(true, 0, Result = false)]
        [TestCase(true, 1, Result = false)]
        [TestCase(true, 2, Result = true)]
        [TestCase(true, 3, Result = true)]
        [TestCase(true, 4, Result = false)]
        [TestCase(true, 5, Result = false)]
        public bool LifeCell_Lives_On_Gestation(bool startsLive, int neighbourCount)
        {
            return LifeGrid.LivesInNewGeneration(startsLive, neighbourCount);
        }

        [TestCase(0, 0, Result=0)]
        [TestCase(1, 0, Result=2)]
        [TestCase(2, 0, Result=1)]
        [TestCase(0, 1, Result=3)]
        [TestCase(1, 1, Result=5)]
        [TestCase(2, 1, Result=2)]
        [TestCase(0, 2, Result=1)]
        [TestCase(1, 2, Result=3)]
        [TestCase(2, 2, Result=2)]
        public int Grid_LifeCell_Counts_Neighbours(int x, int y)
        {
            return populatedGrid.CountNeighbours(x, y);
        }

        [Test]
        public void Grid_Gestates_Another_Grid()
        {
            LifeGrid grid = new LifeGrid(1,1).Gestate();
            Assert.IsInstanceOf<LifeGrid>(grid);
        }

        [TestCase(0, 0, Result = true)]
        [TestCase(0, 1, Result = true)]
        [TestCase(1, 0, Result = false)]
        [TestCase(1, 1, Result = true)]
        public bool Has_Set_A_Cell(int x, int y)
        {
            LifeGrid l = getLGrid();
            return l.IsLive(x, y);
        }

        [TestCase(0, 0, Result = true)]
        [TestCase(0, 1, Result = true)]
        [TestCase(1, 0, Result = true)]
        [TestCase(1, 1, Result = true)]
        public bool L_Grid_Is_Filled(int x, int y)
        {
            LifeGrid l = getLGrid().Gestate();
            return l.IsLive(x, y);
        }
    }
}
