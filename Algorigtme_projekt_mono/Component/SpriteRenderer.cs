using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorigtme_projekt_mono
{
   public class SpriteRenderer: MyComponent
    {
        private Texture2D sprite;
        private Rectangle rectangle;
        private Vector2 drawingOrigin;
        private SpriteEffects effect;
        private Vector2 offset;
        private Color color;
        private Vector2 scale;

        public Vector2 Offset { set { offset = value; } }
        public Rectangle Rectangle { get { return rectangle; } set { rectangle = value; } }
        public Color Color { get { return color; } set { color = value; } }
        public Texture2D Sprite { get { return sprite; } }
        public Vector2 Scale { get { return scale; } }

        public SpriteRenderer(string spriteName, Color color, SpriteEffects effect = SpriteEffects.None,
        float scaleX = 1, float scaleY = 1)
        {
            sprite = GameWorld.Instance.Content.Load<Texture2D>(spriteName);
            this.effect = effect;
            this.color = color;
            scale = new Vector2(scaleX, scaleY);
            Listen<InitializeMsg>(Initialize);
            Listen<DrawMsg>(Draw);
        }

        private void Initialize(InitializeMsg message)
        {
            rectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            drawingOrigin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
        }

        private void Draw(DrawMsg message)
        {
            message.Batch.Draw(sprite,
                position: GameObject.Transform.Position + offset,
                sourceRectangle: rectangle,
                origin: drawingOrigin,
                scale: scale,
                color: color,
                effects: effect);
        }
    }
}
