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
    class GenerateSprite : ISprite
    {
        public int Width { get; set; }
        public int Height { get; set; }
        private readonly Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        private List<Rectangle> spriteList;

        private double currentTime;
        private const double frameTime = 0.08d;

        public GenerateSprite(Texture2D texture, List<Coordinate> frameCoords)
        {
            this.texture = texture;
            spriteList = new List<Rectangle>();
            for (int i = 0; i < frameCoords.Count; i++)
                spriteList.Add(new Rectangle(frameCoords[i].X, frameCoords[i].Y, frameCoords[i].Width, frameCoords[i].Height));
            this.totalFrames = spriteList.Count;
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
            Rectangle sourceRectangle = spriteList[currentFrame];
            Width = spriteList[currentFrame].Width;
            Height = spriteList[currentFrame].Height;
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, sourceRectangle.Width, sourceRectangle.Height);
            spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
