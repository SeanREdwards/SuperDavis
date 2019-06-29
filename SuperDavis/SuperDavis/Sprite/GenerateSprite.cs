using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using System.Collections.Generic;

namespace SuperDavis.Sprite
{
    class GenerateSprite : ISprite
    {
        public float Width { get; set; }
        public float Height { get; set; }
        private readonly Texture2D texture;
        private readonly Rectangle[] spriteList;
        private readonly List<Color> blinkColorList;
        private readonly float scale;
        private readonly SpriteEffects flipDirection;
        private int currentFrame;
        private readonly int totalFrames;
        private double currentTime;
        private const double frameTime = 0.08d;

        public GenerateSprite(SpriteRegistrar spriteInfo) { 
            this.texture = spriteInfo.Texture;
            spriteList = spriteInfo.SourceFrames;
            this.blinkColorList = spriteInfo.ColorList;
            this.scale = spriteInfo.Scale;
            this.flipDirection = SpriteEffects.None;
            totalFrames = spriteList.Length;
            currentFrame = 0;
            // Initialize the first frame of hitbox width and height
            Width = spriteList[currentFrame].Width * scale;
            Height = spriteList[currentFrame].Height * scale;
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
            Width = spriteList[currentFrame].Width * scale;
            Height = spriteList[currentFrame].Height * scale;
            spriteBatch.Draw(this.texture, location, sourceRectangle, blinkColorList[currentFrame % blinkColorList.Count], 0f, Vector2.Zero, scale, flipDirection, 0f);
        }

    }
}
