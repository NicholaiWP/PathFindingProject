using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorigtme_projekt_mono.Component
{

   public abstract class PathFinder
    {
        private List<TileType> goals;
        protected Tile start;
        protected Tile end;
        protected TileType myGoalType = TileType.METALKEY;

        protected List<Tile> grid = new List<Tile>();

        public PathFinder(List<Tile> grid)
        {
            this.grid = grid;
            goals = new List<TileType>() { TileType.TOWERMAGIC, TileType.GOLDKEY, TileType.TOWERSHIELD, TileType.PORTAL };
            start = grid.Find(t => t.MyType == TileType.WIZARD);
            end = grid.Find(t => t.MyType == myGoalType);
        }

        protected void GridUpdater()
        {
            myGoalType = goals[0];
            goals.Remove(myGoalType);
            start = grid.Find(t => t.MyType == TileType.WIZARD);
            end = grid.Find(t => t.MyType == myGoalType);
        }

        public abstract List<Vector2> PerformAlgorithm();
    }
}
