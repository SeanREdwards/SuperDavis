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
    class DavisSpriteFactory

    {

        private List<Coordinate> coordinateList;

        /*Davis sprite sheet variables.*/
        private Texture2D davisRightZero;
        private Texture2D davisRightOne;
        private Texture2D davisRightTwo;
        private Texture2D davisLeftZero;
        private Texture2D davisLeftOne;
        private Texture2D davisLeftTwo;

        /*Woody sprite sheet variables.*/
        private Texture2D woodyRightZero;
        private Texture2D woodyRightOne;
        private Texture2D woodyRightTwo;
        private Texture2D woodyLeftZero;
        private Texture2D woodyLeftOne;
        private Texture2D woodyLeftTwo;

        /*Bat sprite sheet variables.*/
        private Texture2D batRightZero;
        private Texture2D batRightOne;
        private Texture2D batLeftZero;
        private Texture2D batLeftOne;
        private Texture2D batLeftTwo;
        private Texture2D batRightTwo;

        public static DavisSpriteFactory Instance { get; } = new DavisSpriteFactory();

        private DavisSpriteFactory() { }

        public void Load(ContentManager content)
        {
            /*Davis sprite sheet assignments*/
            davisRightZero = content.Load<Texture2D>("DavisSprites/DavisRight_0");
            davisRightOne = content.Load<Texture2D>("DavisSprites/DavisRight_1");
            davisRightTwo = content.Load<Texture2D>("DavisSprites/DavisRight_2");
            davisLeftZero = content.Load<Texture2D>("DavisSprites/DavisLeft_0");
            davisLeftOne = content.Load<Texture2D>("DavisSprites/DavisLeft_1");
            davisLeftTwo = content.Load<Texture2D>("DavisSprites/DavisLeft_2");

            /*Woody sprite sheet assignements*/
            woodyRightZero = content.Load<Texture2D>("WoodySprites/WoodyRight_0");
            woodyRightOne = content.Load<Texture2D>("WoodySprites/WoodyRight_1");
            woodyRightTwo = content.Load<Texture2D>("WoodySprites/WoodyRight_2");
            woodyLeftZero = content.Load<Texture2D>("WoodySprites/WoodyLeft_0");
            woodyLeftOne = content.Load<Texture2D>("WoodySprites/WoodyLeft_1");
            woodyLeftTwo = content.Load<Texture2D>("WoodySprites/WoodyLeft_2");

            /*Bat sprite sheet assignements*/
            batRightZero = content.Load<Texture2D>("BatSprites/BatRight_0");
            batRightOne = content.Load<Texture2D>("BatSprites/BatRight_1");
            batLeftZero = content.Load<Texture2D>("BatSprites/BatLeft_0");
            batLeftOne = content.Load<Texture2D>("BatSprites/BatLeft_1");
            batRightTwo = content.Load<Texture2D>("BatSprites/BatRight_2");
            batLeftTwo = content.Load<Texture2D>("BatSprites/BatLeft_2");
        }

        public ISprite Create(Texture2D texture)
        {
            return new GenerateSprite(texture, coordinateList);
        }

        /*Basic Davis Sprites*/
        public ISprite CreateDavisStaticLeftSprite()
        {

            coordinateList = new List<Coordinate>() { new Coordinate(744, 0, 37, 80) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisStaticRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(19, 0, 37, 80) };
            return Create(davisRightZero);
        }

        public ISprite CreateDavisWalkLeftSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(504, 0, 38, 80), new Coordinate(424, 0, 38, 80),
                new Coordinate(344, 0, 35, 80), new Coordinate(264, 0, 34, 80), new Coordinate(183, 0, 35, 80) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisWalkRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(258, 0, 38, 80), new Coordinate(338, 0, 38, 80),
                new Coordinate(421, 0, 35, 80), new Coordinate(502, 0, 34, 80), new Coordinate(582, 0, 35, 80) };
            return Create(davisRightZero);
        }

        public ISprite CreateDavisCrouchLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(740, 480, 36, 80) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisCrouchRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(24, 480, 36, 80) };
            return Create(davisRightZero);
        }

        public ISprite CreateDavisJumpLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(575, 480, 45, 80) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisJumpRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(180, 480, 45, 80) };
            return Create(davisRightZero);
        }

        public ISprite CreateDavisDeathLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(401, 320, 79, 80) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisDeathRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(320, 320, 79, 80) };
            return Create(davisRightZero);
        }

        /*Advanced Davis Sprites*/
        public ISprite CreateDavisSpecialAttackOneRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(18, 0, 38, 80), new Coordinate(97, 0, 41, 80), new Coordinate(181, 0, 48, 80),
                new Coordinate(261, 0, 56, 80), new Coordinate(332, 0, 66, 80), new Coordinate(421, 0, 42, 80), new Coordinate(501, 0, 42, 80),
                new Coordinate(581, 0, 55, 80), new Coordinate(655, 0, 63, 80), new Coordinate(725, 0, 55, 80) };
            return Create(davisRightTwo);
        }

        /*Basic Woody Sprites*/
        public ISprite CreateWoodyStaticLeftSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(742, 0, 39, 80) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyStaticRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(19, 0, 39, 80) };
            return Create(woodyRightZero);
        }

        public ISprite CreateWoodyWalkLeftSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(502, 0, 39, 80), new Coordinate(422, 0, 39, 80), new Coordinate(345, 0, 34, 80), new Coordinate(267, 0, 32, 80), new Coordinate(184, 0, 35, 80) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyWalkRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(259, 0, 39, 75), new Coordinate(339, 0, 39, 80), new Coordinate(421, 0, 34, 80), new Coordinate(501, 0, 32, 80), new Coordinate(581, 0, 35, 80) };
            return Create(woodyRightZero);
        }

        public ISprite CreateWoodyCrouchLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(744, 480, 33, 80) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyCrouchRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(23, 480, 33, 80) };
            return Create(woodyRightZero);
        }

        public ISprite CreateWoodyJumpLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(578, 480, 46, 80) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyJumpRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(176, 480, 46, 80) };
            return Create(woodyRightZero);
        }

        public ISprite CreateWoodyDeathLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(401, 320, 78, 80) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyDeathRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(321, 320, 78, 80) };
            return Create(woodyRightZero);
        }

        /*Advanced Woody Sprites*/
        public ISprite CreateWoodySpecialAttackOneLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(739, 80, 52, 80), new Coordinate(662, 80, 47, 80), new Coordinate(580, 80, 53, 80),
                new Coordinate(495, 80, 58, 80), new Coordinate(414, 80, 59, 80), new Coordinate(337, 80, 49, 80), new Coordinate(257, 80, 49, 80),
                new Coordinate(177, 80, 49, 80), new Coordinate(97, 80, 49, 80)};
            return Create(woodyLeftTwo);
        }

        public ISprite CreateWoodySpecialAttackOneRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(9, 80, 52, 80), new Coordinate(91, 80, 47, 80), new Coordinate(167, 80, 53, 80),
                new Coordinate(247, 80, 58, 80), new Coordinate(327, 80, 59, 80), new Coordinate(414, 80, 49, 80), new Coordinate(494, 80, 49, 80),
                new Coordinate(574, 80, 49, 80), new Coordinate(654, 80, 49, 80)};
            return Create(woodyRightTwo);
        }

        /*Basic Bat Sprites*/
        public ISprite CreateBatStaticLeftSprite()
        {

            coordinateList = new List<Coordinate>() { new Coordinate(744, 0, 44, 80) };
            return Create(batLeftZero);
        }

        public ISprite CreateBatStaticRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(20, 0, 44, 80) };
            return Create(batRightZero);
        }

        public ISprite CreateBatWalkLeftSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(503, 0, 38, 80), new Coordinate(424, 0, 37, 80),
                new Coordinate(344, 0, 37, 80), new Coordinate(264, 0, 37, 80), new Coordinate(183, 0, 38, 80)  };
            return Create(batLeftZero);
        }

        public ISprite CreateBatWalkRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(259, 0, 38, 80), new Coordinate(339, 0, 37, 80),
                new Coordinate(419, 0, 37, 80), new Coordinate(499, 0, 37, 80) };
            return Create(batRightZero);
        }

        public ISprite CreateBatCrouchLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(736, 480, 44, 80) };
            return Create(batLeftZero);
        }

        public ISprite CreateBatCrouchRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(20, 480, 44, 80) };
            return Create(batRightZero);
        }

        public ISprite CreateBatJumpLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(581, 480, 39, 80) };
            return Create(batLeftZero);
        }

        public ISprite CreateBatJumpRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(180, 480, 39, 80) };
            return Create(batRightZero);
        }

        public ISprite CreateBatDeathLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(403, 320, 77, 80) };
            return Create(batLeftZero);
        }

        public ISprite CreateBatDeathRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(320, 320, 77, 80) };
            return Create(batRightZero);
        }

        /*Advanced Bat Sprites*/
        public ISprite CreateBatSpecialAttackOneLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(269, 2, 39, 80), new Coordinate(181, 2, 44, 80), new Coordinate(108, 2, 25, 80) };
            return Create(batLeftTwo);
        }

        public ISprite CreateBatSpecialAttackOneRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(20, 2, 39, 80), new Coordinate(103, 2, 44, 80), new Coordinate(195, 2, 25, 80) };
            return Create(batRightTwo);
        }

    }
}
