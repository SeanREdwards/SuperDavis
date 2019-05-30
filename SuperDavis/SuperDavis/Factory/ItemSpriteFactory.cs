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

        public ISprite CreateYellowCoinStatic()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 0, 16, 16) };
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateYellowCoinAnimated()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 0, 16, 16), new Coordinate(16, 0, 16, 16), new Coordinate(32, 0, 16, 16), new Coordinate(48, 0, 16, 16) };
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateStar()
        {
            coordinateList = new List<Coordinate>() {new Coordinate(224, 106, 15, 16)};
            return Create(blocksAndPipes);
        }

        public ISprite CreateYoshiEgg()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(286, 105, 14, 16) };
            return Create(blocksAndPipes);
        }

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

        public ISprite CreateRedMushroom()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(182, 107, 16, 16) };
            return Create(blocksAndPipes);
        }

        public ISprite CreateGreenMushroom()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(182, 107, 16, 16) };
            return Create(blocksAndPipes);
        }

        /*Block Sprites*/
        public ISprite CreateQuestionMarkBlockAnimated()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 64, 16, 16), new Coordinate(16, 64, 16, 16), new Coordinate(32, 64, 16, 16),
                new Coordinate(48, 64, 16, 16)};
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

        public ISprite SpinBlockStatic()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 80, 16, 16) };
            return Create(brickBlocks);
        }

        public ISprite SpinBlockAnimated()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 80, 16, 16), new Coordinate(16, 80, 16, 16), new Coordinate(32, 80, 16, 16),
                new Coordinate(48, 80, 16, 16) };
            return Create(brickBlocks);
        }

        //*Pipes*/

        public ISprite CreateGreenPipe()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(96, 0, 32, 32) };
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateYellowPipe()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(128, 0, 32, 32) };
            return Create(blocksAndPipesTwo);
        }

        public ISprite CreateBluePipe()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(160, 0, 32, 32) };
            return Create(blocksAndPipesTwo);
        }
    }
}
