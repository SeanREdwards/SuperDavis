﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System.Collections.Generic;

/*
 * BackgroundSpriteFactory.cs
 * @Author Sean Edwards
 * Factory class to create background sprites.
 */
namespace SuperDavis.Factory
{
    class BackgroundSpriteFactory

    {
        private List<Rectangle> coordinateList;

        private Texture2D marioBackgroundOne;

        public static BackgroundSpriteFactory Instance { get; } = new BackgroundSpriteFactory();

        private BackgroundSpriteFactory() { }

        public void Load(ContentManager content)
        {
            //TODO Test Background sprite sheet
            marioBackgroundOne = content.Load<Texture2D>("BackgroundSprites/BackgroundsMario1");
        }

        public ISprite Create(Texture2D texture)
        {
            return new GenerateSprite(texture, coordinateList);
        }

        public ISprite MarioHillsGreen()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(1072, 0, 512, 447) };
            return new GenerateBackground(marioBackgroundOne, coordinateList);
        }

    }
}