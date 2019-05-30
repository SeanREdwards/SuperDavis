using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Sprite
{
    /* Save it for the future, it's the old version of our sprite machine */
    class DynamicSprite : ISprite
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private readonly Texture2D texture;
        private int currentFrame;
        private readonly int totalFrames;
        private double currentTime;
        private const double frameTime = 0.08d;

        public DynamicSprite(Texture2D texture, int totalFrames)
        {
            this.texture = texture;
            this.totalFrames = totalFrames;
            currentFrame = 0;
            Width = texture.Width / totalFrames;
            Height = texture.Height;
        }

        public void Update(GameTime gameTime)
        {
            currentTime += gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime > frameTime)
            {
                currentFrame++;
                currentTime = 0d;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle source = new Rectangle(Width * currentFrame, 0, Width, Height);
            Rectangle destination = new Rectangle((int)location.X, (int)location.Y, Width, Height);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }
    }
}
