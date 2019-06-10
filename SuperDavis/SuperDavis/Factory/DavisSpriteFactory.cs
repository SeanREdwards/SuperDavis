using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperDavis.Interfaces;
using SuperDavis.Sprite;
using System.Collections.Generic;

/*
 * DavisSpriteFactory.cs
 * @Author Sean Edwards & Jason Xu
 * Factory class to create character sprites.
 */
namespace SuperDavis.Factory
{
    /* Character Sprites credited for http://www.lf2.net/ */
    class DavisSpriteFactory

    {
        private List<Rectangle> coordinateList;

        /*Davis sprite sheet variables.*/
        private Texture2D davisStaticRight;
        private Texture2D davisSpecialAttackOneRight;
        private Texture2D davisStaticLeft;
        private Texture2D davisSpecialAttackOneLeft;

        /*Woody sprite sheet variables.*/
        private Texture2D woodyStaticRight;
        private Texture2D woodySpecialAttackOneRight;
        private Texture2D woodyStaticLeft;
        private Texture2D woodySpecialAttackOneLeft;

        /*Bat sprite sheet variables.*/
        private Texture2D batStaticRight;
        private Texture2D batStaticLeft;
        private Texture2D batSpecialAttackOneLeft;
        private Texture2D batSpecialAttackOneRight;

        private Texture2D marioBackgroundOne;

        public static DavisSpriteFactory Instance { get; } = new DavisSpriteFactory();

        private DavisSpriteFactory() { }

        public void Load(ContentManager content)
        {
            /*Davis sprite sheet assignments*/
            davisStaticRight = content.Load<Texture2D>("DavisSprites/DavisRight_0");
            davisSpecialAttackOneRight = content.Load<Texture2D>("DavisSprites/DavisRight_2");
            davisStaticLeft = content.Load<Texture2D>("DavisSprites/DavisLeft_0");
            davisSpecialAttackOneLeft = content.Load<Texture2D>("DavisSprites/DavisLeft_2");

            /*Woody sprite sheet assignements*/
            woodyStaticRight = content.Load<Texture2D>("WoodySprites/WoodyRight_0");
            woodySpecialAttackOneRight = content.Load<Texture2D>("WoodySprites/WoodyRight_2");
            woodyStaticLeft = content.Load<Texture2D>("WoodySprites/WoodyLeft_0");
            woodySpecialAttackOneLeft = content.Load<Texture2D>("WoodySprites/WoodyLeft_2");

            /*Bat sprite sheet assignements*/
            batStaticRight = content.Load<Texture2D>("BatSprites/BatRight_0");
            batStaticLeft = content.Load<Texture2D>("BatSprites/BatLeft_0");
            batSpecialAttackOneRight = content.Load<Texture2D>("BatSprites/BatRight_2");
            batSpecialAttackOneLeft = content.Load<Texture2D>("BatSprites/BatLeft_2");

            //TODO Test Background sprite sheet
            marioBackgroundOne = content.Load<Texture2D>("BackgroundSprites/BackgroundsMario1");
        }

        public ISprite Create(Texture2D texture)
        {
            return new GenerateSprite(texture, coordinateList);
        }

        /*Basic Davis Sprites*/
        public ISprite Invincible()
        {
            //TODO - Just using batStaticRight for testing purposes
            coordinateList = new List<Rectangle>() { new Rectangle(744, 0, 37, 80) };
            return Create(batStaticRight);
        }

        public ISprite CreateDavisStaticLeftSprite()
        {

            coordinateList = new List<Rectangle>() { new Rectangle(744, 0, 37, 80) };
            return Create(davisStaticLeft);
        }

        public ISprite CreateDavisStaticRightSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(19, 0, 37, 80) };
            return Create(davisStaticRight);
        }

        public ISprite CreateDavisWalkLeftSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(504, 0, 38, 80), new Rectangle(424, 0, 38, 80),
                new Rectangle(344, 0, 35, 80), new Rectangle(264, 0, 34, 80), new Rectangle(183, 0, 35, 80) };
            return Create(davisStaticLeft);
        }

        public ISprite CreateDavisWalkRightSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(258, 0, 38, 80), new Rectangle(338, 0, 38, 80),
                new Rectangle(421, 0, 35, 80), new Rectangle(502, 0, 34, 80), new Rectangle(582, 0, 35, 80) };
            return Create(davisStaticRight);
        }

        public ISprite CreateDavisCrouchLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(740, 480, 36, 80) };
            return Create(davisStaticLeft);
        }

        public ISprite CreateDavisCrouchRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(24, 480, 36, 80) };
            return Create(davisStaticRight);
        }

        public ISprite CreateDavisJumpLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(575, 480, 45, 80) };
            return Create(davisStaticLeft);
        }

        public ISprite CreateDavisJumpRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(180, 480, 45, 80) };
            return Create(davisStaticRight);
        }

        public ISprite CreateDavisDeathLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(401, 320, 79, 80) };
            return Create(davisStaticLeft);
        }

        public ISprite CreateDavisDeathRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(320, 320, 79, 80) };
            return Create(davisStaticRight);
        }

        /*Advanced Davis Sprites*/
        public ISprite CreateDavisSpecialAttackOneLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(720, 0, 80, 80), new Rectangle(640, 0, 80, 80), new Rectangle(560, 0, 80, 80),
                new Rectangle(480, 0, 80, 80), new Rectangle(400, 0, 80, 80), new Rectangle(320, 0, 80, 80), new Rectangle(240, 0, 80, 80),
                new Rectangle(160, 0, 80, 80), new Rectangle(80, 0, 80, 80), new Rectangle(0, 0, 80, 80) };
            return Create(davisSpecialAttackOneLeft);
        }

        public ISprite CreateDavisSpecialAttackOneRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(18, 0, 38, 80), new Rectangle(97, 0, 41, 80), new Rectangle(181, 0, 48, 80),
                new Rectangle(261, 0, 56, 80), new Rectangle(332, 0, 66, 80), new Rectangle(421, 0, 42, 80), new Rectangle(501, 0, 42, 80),
                new Rectangle(581, 0, 55, 80), new Rectangle(655, 0, 63, 80), new Rectangle(725, 0, 55, 80) };
            return Create(davisSpecialAttackOneRight);
        }


        /*Basic Woody Sprites*/
        public ISprite CreateWoodyStaticLeftSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(742, 0, 39, 80) };
            return Create(woodyStaticLeft);
        }

        public ISprite CreateWoodyStaticRightSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(19, 0, 39, 80) };
            return Create(woodyStaticRight);
        }

        public ISprite CreateWoodyWalkLeftSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(502, 0, 39, 80), new Rectangle(422, 0, 39, 80), new Rectangle(345, 0, 34, 80), new Rectangle(267, 0, 32, 80), new Rectangle(184, 0, 35, 80) };
            return Create(woodyStaticLeft);
        }

        public ISprite CreateWoodyWalkRightSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(259, 0, 39, 75), new Rectangle(339, 0, 39, 80), new Rectangle(421, 0, 34, 80), new Rectangle(501, 0, 32, 80), new Rectangle(581, 0, 35, 80) };
            return Create(woodyStaticRight);
        }

        public ISprite CreateWoodyCrouchLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(744, 480, 33, 80) };
            return Create(woodyStaticLeft);
        }

        public ISprite CreateWoodyCrouchRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(23, 480, 33, 80) };
            return Create(woodyStaticRight);
        }

        public ISprite CreateWoodyJumpLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(578, 480, 46, 80) };
            return Create(woodyStaticLeft);
        }

        public ISprite CreateWoodyJumpRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(176, 480, 46, 80) };
            return Create(woodyStaticRight);
        }

        public ISprite CreateWoodyDeathLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(401, 320, 78, 80) };
            return Create(woodyStaticLeft);
        }

        public ISprite CreateWoodyDeathRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(321, 320, 78, 80) };
            return Create(woodyStaticRight);
        }

        /*Advanced Woody Sprites*/
        public ISprite CreateWoodySpecialAttackOneLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(739, 80, 52, 80), new Rectangle(662, 80, 47, 80), new Rectangle(580, 80, 53, 80),
                new Rectangle(495, 80, 58, 80), new Rectangle(414, 80, 59, 80), new Rectangle(337, 80, 49, 80), new Rectangle(257, 80, 49, 80),
                new Rectangle(177, 80, 49, 80), new Rectangle(97, 80, 49, 80)};
            return Create(woodySpecialAttackOneLeft);
        }

        public ISprite CreateWoodySpecialAttackOneRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(9, 80, 52, 80), new Rectangle(91, 80, 47, 80), new Rectangle(167, 80, 53, 80),
                new Rectangle(247, 80, 58, 80), new Rectangle(327, 80, 59, 80), new Rectangle(414, 80, 49, 80), new Rectangle(494, 80, 49, 80),
                new Rectangle(574, 80, 49, 80), new Rectangle(654, 80, 49, 80)};
            return Create(woodySpecialAttackOneRight);
        }

        /*Basic Bat Sprites*/
        public ISprite CreateBatStaticLeftSprite()
        {

            coordinateList = new List<Rectangle>() { new Rectangle(744, 0, 44, 80) };
            return Create(batStaticLeft);
        }

        public ISprite CreateBatStaticRightSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(20, 0, 44, 80) };
            return Create(batStaticRight);
        }

        public ISprite CreateBatWalkLeftSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(503, 0, 38, 80), new Rectangle(424, 0, 37, 80),
                new Rectangle(344, 0, 37, 80), new Rectangle(264, 0, 37, 80), new Rectangle(183, 0, 35, 80)  };
            return Create(batStaticLeft);
        }

        public ISprite CreateBatWalkRightSprite()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(259, 0, 38, 80), new Rectangle(339, 0, 37, 80),
                new Rectangle(419, 0, 37, 80), new Rectangle(499, 0, 37, 80) };
            return Create(batStaticRight);
        }

        public ISprite CreateBatCrouchLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(736, 480, 44, 80) };
            return Create(batStaticLeft);
        }

        public ISprite CreateBatCrouchRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(20, 480, 44, 80) };
            return Create(batStaticRight);
        }

        public ISprite CreateBatJumpLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(581, 480, 39, 80) };
            return Create(batStaticLeft);
        }

        public ISprite CreateBatJumpRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(180, 480, 39, 80) };
            return Create(batStaticRight);
        }

        public ISprite CreateBatDeathLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(403, 320, 77, 80) };
            return Create(batStaticLeft);
        }

        public ISprite CreateBatDeathRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(320, 320, 77, 80) };
            return Create(batStaticRight);
        }

        /*Advanced Bat Sprites*/
        public ISprite CreateBatSpecialAttackOneLeft()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(269, 2, 39, 80), new Rectangle(181, 2, 44, 80), new Rectangle(108, 2, 25, 80) };
            return Create(batSpecialAttackOneLeft);
        }

        public ISprite CreateBatSpecialAttackOneRight()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(20, 2, 39, 80), new Rectangle(103, 2, 44, 80), new Rectangle(195, 2, 25, 80) };
            return Create(batSpecialAttackOneRight);
        }

        /*Background sprite generation as the BackgroundSpriteFactory was giving a weird null error.*/
        public ISprite MarioHillsGreen()
        {
            coordinateList = new List<Rectangle>() { new Rectangle(1072, 0, 512, 447) };
            return new GenerateBackground(marioBackgroundOne, coordinateList);
        }

    }
}
