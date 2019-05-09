using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorigtme_projekt_mono
{
   public class DrawMsg: Msg
    {
        public SpriteBatch Batch { get;}

        public DrawMsg(SpriteBatch batch)
        {
            Batch = batch;
        }
    }
}
