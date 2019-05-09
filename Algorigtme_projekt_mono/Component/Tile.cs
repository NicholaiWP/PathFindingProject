using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorigtme_projekt_mono
{
    public enum TileType { PORTAL, TREE, DIRT, WALL, TOWERMAGIC, TOWERSHIELD, MONSTER, METALKEY, GOLDKEY, EMPTY, WIZARD };
    public class Tile: MyComponent
    {
        private TileType myType;

        public Vector2 Position { get; }

        public TileType MyType { get { return myType; } }

        public Tile(TileType myType, Vector2 position)
        {
            this.myType = myType;
            Position = position;
        }
    }
}
