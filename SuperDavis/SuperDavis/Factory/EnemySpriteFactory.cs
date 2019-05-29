/*
 * EnemySpriteFactory.cs
 * @Author Sean Edwards
 * Class to create a sprite factory allowing for the streamlining of enemy sprites.
 */
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
    class EnemySpriteFactory
    {
        private Texture2D goombaSheet;
        private List<Coordinate> coordinateList;

        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        private EnemySpriteFactory() { }

        public void Load(ContentManager content)
        {
            goombaSheet = content.Load<Texture2D>("EnemySprites/Goomba");
        }

        /*Goomba Sprite Generation.*/
        public ISprite CreateGoomba(Texture2D texture)
        {
            return new GenerateSprite(texture, coordinateList);
        }

        public ISprite CreateStaticGoomba()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(2, 0, 16, 18) };
            return CreateGoomba(goombaSheet);
        }

        public ISprite CreateGoombaMovingRight()
        {

            coordinateList = new List<Coordinate>() { new Coordinate(1, 40, 17, 20), new Coordinate(41, 40, 18, 20), new Coordinate(80, 40, 20, 20),
                new Coordinate(121, 40, 18, 20), new Coordinate(161, 40, 18, 20), new Coordinate(202, 40, 16, 20) };
            return CreateGoomba(goombaSheet);
        }

        public ISprite CreateGoombaJump()
        {
            coordinateList =  new List<Coordinate>() { new Coordinate(1, 41, 17, 20), new Coordinate(41, 41, 18, 19), new Coordinate(80, 42, 20, 18),
                new Coordinate(121, 41, 18, 19), new Coordinate(161, 41, 18, 20), new Coordinate(202, 41, 16, 19) };
            return CreateGoomba(goombaSheet);
        }

        public ISprite CreateGoombaFlateStatic()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 66, 20, 20) };
            return CreateGoomba(goombaSheet);
        }

        public ISprite CreateGoombaFlatMovingRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(38, 75, 24, 20), new Coordinate(77, 75, 25, 20), new Coordinate(118, 75, 24, 20),
                new Coordinate(157, 75, 26, 20), new Coordinate(196, 75, 28, 20) };
            return CreateGoomba(goombaSheet);
        }
    }
}
