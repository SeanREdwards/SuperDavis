using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using System.Collections.Generic;

namespace SuperDavis.Sprite
{
    class GenerateNotScalingSprite : ISprite
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly Texture2D texture;
        private int currentFrame;
        private readonly int totalFrames;
        private readonly List<Rectangle> spriteList;
        private double currentTime;

        private const double frameTime = 0.08d; 

        public GenerateNotScalingSprite(Texture2D texture, List<Rectangle> frameCoords)
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
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)Width,(int)Height);
            spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
