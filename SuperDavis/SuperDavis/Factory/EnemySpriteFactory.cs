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
        public ISprite CreateGoomba()
        {
            return new GenerateSprite(goombaSheet, coordinateList);
        }

        public ISprite CreateStaticGoomba()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(2, 2, 16, 18) };
            return CreateGoomba();
        }

        public ISprite CreateGoombaMovingRight()
        {

            coordinateList = new List<Coordinate>() { new Coordinate(1, 41, 17, 20), new Coordinate(41, 41, 18, 19), new Coordinate(80, 42, 20, 18),
                new Coordinate(121, 41, 18, 19), new Coordinate(161, 41, 18, 20), new Coordinate(202, 41, 16, 19) };
            return CreateGoomba();
        }

        public ISprite CreateGoombaJump()
        {
            coordinateList =  new List<Coordinate>() { new Coordinate(1, 41, 17, 20), new Coordinate(41, 41, 18, 19), new Coordinate(80, 42, 20, 18),
                new Coordinate(121, 41, 18, 19), new Coordinate(161, 41, 18, 20), new Coordinate(202, 41, 16, 19) };
            return CreateGoomba();
        }

        public ISprite CreateGoombaFlateStatic()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(0, 91, 20, 9) };
            return CreateGoomba();
        }

        public ISprite CreateGoombaFlatMovingRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(38, 86, 24, 9), new Coordinate(77, 86, 25, 9), new Coordinate(118, 86, 24, 9), new Coordinate(157, 87, 26, 8), new Coordinate(196, 87, 28, 7) };
            return CreateGoomba();
        }
    }
}
