using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System.Collections.Generic;

/*
 * EnemySpriteFactory.cs
 * @Author Sean Edwards
 * Class to create a sprite factory allowing for the streamlining of enemy sprites.
 */
namespace SuperDavis.Factory
{
    class EnemySpriteFactory
    {
        private Texture2D goombaSheet;
        private Texture2D koopaGreenSheet;
        private List<Rectangle> coordinateList;

        public static EnemySpriteFactory Instance { get; } = new EnemySpriteFactory();

        private EnemySpriteFactory() { }

        public void Load(ContentManager content)
        {
            goombaSheet = content.Load<Texture2D>("EnemySprites/Goomba");
            koopaGreenSheet = content.Load<Texture2D>("EnemySprites/KoopaTroopaGreen");
        }

        /*Goomba Sprite Generation.*/
        public ISprite Create(Texture2D texture)
        {
            return new GenerateSprite(texture, coordinateList);
        }

        /*public ISprite CreateStaticGoomba()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(2, 0, 16, 18) };
            return Create(goombaSheet);
        }*/

        public ISprite CreateGoombaMovingRight()
        {

            coordinateList = new List<Rectangle>() { new Rectangle(1, 40, 17, 20), new Rectangle(41, 40, 18, 20), new Rectangle(80, 40, 20, 20),
                new Rectangle(121, 40, 18, 20), new Rectangle(161, 40, 18, 20), new Rectangle(202, 40, 16, 20) };
            return Create(goombaSheet);
        }

        /*public ISprite CreateGoombaJump()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(1, 41, 17, 20), new Rectangle(41, 41, 18, 19), new Rectangle(80, 42, 20, 18),
                new Rectangle(121, 41, 18, 19), new Rectangle(161, 41, 18, 20), new Rectangle(202, 41, 16, 19) };
            return Create(goombaSheet);
        }*/

        public ISprite CreateGoombaFlateStatic()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(0, 66, 20, 20) };
            return Create(goombaSheet);
        }

        /*public ISprite CreateGoombaFlatMovingRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(38, 75, 24, 20), new Rectangle(77, 75, 25, 20), new Rectangle(118, 75, 24, 20),
                new Rectangle(157, 75, 26, 20), new Rectangle(196, 75, 28, 20) };
            return Create(goombaSheet);
        }*/

        public ISprite CreateKoopaGreenStaticLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(167, 0, 22, 30) };
            return Create(koopaGreenSheet);
        }

        public ISprite CreateKoopaGreenShellAnimatedLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(10, 37, 16, 15), new Rectangle(10, 67, 16, 15), new Rectangle(10, 97, 16, 15), new Rectangle(10, 127, 16, 15) };
            return Create(koopaGreenSheet);
        }

    }
}
