using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Algorigtme_projekt_mono
{
    public delegate void ClickDelegate();

    public delegate void OnHoverDelegate(SpriteRenderer s);

    public class Button : MyComponent
    {
        private ClickDelegate onClick;
        private OnHoverDelegate onHover;
        private string buttonSprite;
        private Color color;
        private bool hasPlayedSound = false;
        private SpriteRenderer spriteRenderer;
        private Rectangle rectangle;
        private Vector2 scale;

        /// <summary>
        /// Use a spritesheet for making the two buttons one with no hover another with hover effect.
        /// The button component adds a spriterenderer and an animator to the gameobject.
        /// When making the ClickDelegate do () => {what is supposed to happen;}
        /// When making the OnHoverDelegate do () => {(s) => s.ChangeSprite(the name of hover sprite);
        /// maybe change cursor pic aswell;}
        /// When making the PlaySoundDelegate do () => {SoundManager.Instance.PlaySound(soundName)
        /// </summary>
        /// <param name="buttonSprite"></param>
        /// <param name="layerName"></param>
        /// <param name="color"></param>
        /// <param name="onClick"></param>
        /// <param name="animator"></param>
        /// <param name="onHover"></param>
        /// <param name="playSound"></param>
        /// <param name="drawRectangle"></param>
        public Button(string buttonSprite, Color color, ClickDelegate onClick,
         OnHoverDelegate onHover = null,
            float scaleX = 1, float scaleY = 1)
        {
            this.onClick = onClick;
            this.buttonSprite = buttonSprite;       
            this.color = color;
            this.onHover = onHover;
            scale = new Vector2(scaleX, scaleY);
            Listen<InitializeMsg>(Initialize);       
            Listen<UpdateMsg>(Update);

        }

        private void Initialize(InitializeMsg message)
        {
            spriteRenderer = GameObject.GetComponent<SpriteRenderer>();
        }

        private void Update(UpdateMsg msg)
        {

            rectangle = new Rectangle((int)(GameObject.Transform.Position.X -
                ((spriteRenderer.Rectangle.Width / 2) * scale.X)),
                (int)(GameObject.Transform.Position.Y - ((spriteRenderer.Rectangle.Height / 2) * scale.Y)),
                (int)(spriteRenderer.Rectangle.Width * scale.X), (int)(spriteRenderer.Rectangle.Height * scale.Y));
            MouseState state = Mouse.GetState();
            
            if (rectangle.Contains(state.Position))
            {
                OnHover();

                if (state.LeftButton == ButtonState.Pressed)
                {
                    OnClick();
                }
            }
        }

        /// <summary>
        /// Do this after you have updated the objects
        /// </summary>
        public void OnHover()
        {
            onHover?.Invoke(spriteRenderer);

        }

        public void OnClick()
        {
            onClick?.Invoke();
        }
      
    }
}
