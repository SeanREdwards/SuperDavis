using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interface;
using SuperDavis.Sprite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDavis.Factory
{
    class ItemSpriteFactory
    {
        private Texture2D blocksAndPipes;
        private Texture2D blocksAndPipesTwo;
        private Texture2D brickBlocks;
        private List<Coordinate> coordinateList;

        private Texture2D coin;

        public static ItemSpriteFactory Instance { get; } = new ItemSpriteFactory();

        private ItemSpriteFactory() { }

        public void Load(ContentManager content)
        {
            coin = content.Load<Texture2D>("Item/coin");
            blocksAndPipes = content.Load<Texture2D>("BlockSprites/Blocks&Pipes");
            blocksAndPipesTwo = content.Load<Texture2D>("BlockSprites/Blocks&Pipes2");
            brickBlocks = content.Load<Texture2D>("BlockSprites/BrickBlock");
        }

        public ISprite Create(Texture2D texture)
        {
            return new GenerateSprite(texture, coordinateList);
        }

        /*  Coin Sprite */
        public ISprite CreateCoinSprite()
        {
            return new DynamicSprite(coin, 4);
        }

        /*Item Sprites*/
        public ISprite CreateYoshiCoinStatic()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 32, 16, 32) };
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateYoshiCoinAnimated()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 32, 16, 32), new Coordinate(16, 32, 16, 32),
                new Coordinate(32, 32, 16, 32), new Coordinate(48, 32, 16, 32), new Coordinate(64, 32, 16, 32),
                new Coordinate(80, 32, 16, 32)};
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateFireFlower()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(202, 107, 16, 16)};
            return Create(blocksAndPipes);
        }

        public ISprite CreateMushroom()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(182, 107, 16, 16) };
            return Create(blocksAndPipes);
        }

        /*Block Sprites*/
        public ISprite CreateQuestionMarkBlockAnimated()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 64, 16, 16), new Coordinate(16, 64, 16, 16), new Coordinate(32, 64, 16, 16),
                new Coordinate(48, 64, 16, 16), new Coordinate(0, 0, 0, 0) };
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateActivatedBlock()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(49, 107, 16, 16) };
            return Create(blocksAndPipes);
        }

        public ISprite CreateEmptyBlock()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 0, 0, 0) };
            return Create(blocksAndPipes);
        }

        public ISprite CreateBrickBlock()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(272, 112, 16, 16) };
            return Create(brickBlocks);
        }

        //TODO
        //*Pipes*/
        //List<Coordinate> greenPipe = new List<Coordinate>() { new Coordinate(96, 0, 32, 32) };
        //testSprite = new GenerateSprite(blocksAndPipesTwo, greenPipe);

        //List<Coordinate> yellowPipe = new List<Coordinate>() { new Coordinate(128, 0, 32, 32) };
        //testSprite = new GenerateSprite(blocksAndPipesTwo, yellowPipe);

        //List<Coordinate> bluePipe = new List<Coordinate>() { new Coordinate(160, 0, 32, 32) };
        //testSprite = new GenerateSprite(blocksAndPipesTwo, bluePipe);
    }
}
