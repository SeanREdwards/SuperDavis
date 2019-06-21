﻿using Microsoft.Xna.Framework;
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

        public GenerateSprite(Texture2D texture, List<Color> blinkColorList, float scale, SpriteEffects flipDirection, params Rectangle[] frameCoords)
        {
            this.texture = texture;
            spriteList = frameCoords;
            this.blinkColorList = blinkColorList;
            this.scale = scale;
            this.flipDirection = flipDirection;
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
            Width = spriteList[currentFrame].Width;
            Height = spriteList[currentFrame].Height;
            spriteBatch.Draw(this.texture, location, sourceRectangle, blinkColorList[currentFrame % blinkColorList.Count], 0f, Vector2.Zero, scale, flipDirection, 0f);
        }
    }
}
