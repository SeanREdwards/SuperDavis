using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using System.Collections.Generic;

namespace SuperDavis.Sprite
{
    class GenerateSprite : ISprite
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private readonly Texture2D texture;
        private int currentFrame;
        private readonly int totalFrames;
        private readonly List<Rectangle> spriteList;
        private double currentTime;

        //TODO the fixed frametime should not be fixed for all frames i.e. not all are created equal.
        private const double frameTime = 0.08d; 

        public GenerateSprite(Texture2D texture, List<Rectangle> frameCoords)
        {
            this.texture = texture;
            spriteList = frameCoords;
            this.totalFrames = spriteList.Count;
            currentFrame = 0;
            Width = spriteList[currentFrame].Width;
            Height = spriteList[currentFrame].Height;
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
            Rectangle sourceRectangle = spriteList[currentFrame];
            Width = spriteList[currentFrame].Width;
            Height = spriteList[currentFrame].Height;
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, sourceRectangle.Width, sourceRectangle.Height);
            spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
