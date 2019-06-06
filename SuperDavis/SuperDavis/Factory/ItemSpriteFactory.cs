﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System.Collections.Generic;

namespace SuperDavis.Factory
{
    class ItemSpriteFactory
    {
        private Texture2D blocksAndPipes;
        private Texture2D blocksAndPipesTwo;
        private Texture2D brickBlocks;
        private List<Rectangle> coordinateList;

        public static ItemSpriteFactory Instance { get; } = new ItemSpriteFactory();

        private ItemSpriteFactory() { }

        public void Load(ContentManager content)
        {
            blocksAndPipes = content.Load<Texture2D>("BlockSprites/Blocks&Pipes");
            blocksAndPipesTwo = content.Load<Texture2D>("BlockSprites/Blocks&Pipes2");
            brickBlocks = content.Load<Texture2D>("BlockSprites/BrickBlock");
        }

        public ISprite Create(Texture2D texture)
        {
            return new GenerateSprite(texture, coordinateList);
        }

        /*Item Sprites*/

        /*public ISprite CreateYellowCoinStatic()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 0, 16, 16) };
            return Create(blocksAndPipesTwo);
        }*/

        /*public ISprite CreateYellowCoinAnimated()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 0, 16, 16), new Rectangle(16, 0, 16, 16), new Rectangle(32, 0, 16, 16), new Rectangle(48, 0, 16, 16) };
            return Create(blocksAndPipesTwo);
        }*/

        public ISprite CreateStar()
        {
            coordinateList = new List<Rectangle>() {new Rectangle(224, 106, 15, 16)};
            return Create(blocksAndPipes);
        }

        public ISprite CreateYoshiEgg()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(286, 105, 14, 16) };
            return Create(blocksAndPipes);
        }

        /*public ISprite CreateYoshiCoinStatic()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 32, 16, 32) };
            return Create(blocksAndPipesTwo);
        }*/

        public ISprite CreateYoshiCoinAnimated()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 32, 16, 32), new Rectangle(16, 32, 16, 32),
                new Rectangle(32, 32, 16, 32), new Rectangle(48, 32, 16, 32), new Rectangle(64, 32, 16, 32),
                new Rectangle(80, 32, 16, 32)};
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateFireFlower()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(202, 107, 16, 16)};
            return Create(blocksAndPipes);
        }

        public ISprite CreateRedMushroom()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(182, 107, 16, 16) };
            return Create(blocksAndPipes);
        }

        /*Block Sprites*/
        public ISprite CreateQuestionMarkBlockAnimated()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 64, 16, 16), new Rectangle(16, 64, 16, 16), new Rectangle(32, 64, 16, 16),
                new Rectangle(48, 64, 16, 16)};
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateActivatedBlock()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(49, 107, 16, 16) };
            return Create(blocksAndPipes);
        }

        public ISprite CreateEmptyBlock()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 0, 0, 0) };
            return Create(blocksAndPipes);
        }

        public ISprite CreateBrickBlock()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(272, 112, 16, 16) };
            return Create(brickBlocks);
        }

        /*public ISprite SpinBlockStatic()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 80, 16, 16) };
            return Create(brickBlocks);
        }*/

        /*public ISprite SpinBlockAnimated()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 80, 16, 16), new Rectangle(16, 80, 16, 16), new Rectangle(32, 80, 16, 16),
                new Rectangle(48, 80, 16, 16) };
            return Create(brickBlocks);
        }*/

        /*Pipes*/

        public ISprite CreateGreenPipe()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(96, 0, 32, 32) };
            return Create(blocksAndPipesTwo);
        }

        /*public ISprite CreateYellowPipe()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(128, 0, 32, 32) };
            return Create(blocksAndPipesTwo);
        }*/

        /*public ISprite CreateBluePipe()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(160, 0, 32, 32) };
            return Create(blocksAndPipesTwo);
        }*/
    }
}
