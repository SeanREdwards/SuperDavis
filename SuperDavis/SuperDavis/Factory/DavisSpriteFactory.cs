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

        private Texture2D batRightZero;
        private Texture2D batRightOne;
        private Texture2D batLeftZero;
        private Texture2D batLeftOne;

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
        }

        public ISprite Create(Texture2D texture)
        {
            return new GenerateSprite(texture, coordinateList);
        }

        /*Basic Davis Sprites*/
        public ISprite CreateDavisStaticLeftSprite()
        {

            coordinateList = new List<Coordinate>() { new Coordinate(744, 7, 37, 72) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisStaticRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(19, 7, 37, 72) };
            return Create(davisRightZero);
        }

        public ISprite CreateDavisWalkLeftSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(504, 6, 38, 73), new Coordinate(424, 6, 38, 73),
                new Coordinate(344, 6, 38, 73), new Coordinate(264, 6, 38, 73), new Coordinate(184, 6, 38, 73) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisWalkRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(258, 6, 38, 73), new Coordinate(338, 6, 38, 73),
                new Coordinate(418, 6, 38, 73), new Coordinate(498, 6, 38, 73), new Coordinate(578, 6, 38, 73) };
            return Create(davisRightZero);
        }

        public ISprite CreateDavisCrouchLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(740, 509, 36, 50) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisCrouchRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(24, 509, 36, 50) };
            return Create(davisRightZero);
        }

        public ISprite CreateDavisDeathLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(401, 366, 79, 32) };
            return Create(davisLeftZero);
        }

        public ISprite CreateDavisDeathRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(320, 366, 79, 32) };
            return Create(davisRightZero);
        }

        /*Advanced Davis Sprites*/
        public ISprite CreateDavisSpecialAttackOneRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(18, 7, 38, 72), new Coordinate(97, 8, 41, 71), new Coordinate(181, 9, 48, 70),
                new Coordinate(261, 8, 56, 71), new Coordinate(332, 9, 66, 70), new Coordinate(421, 8, 42, 71), new Coordinate(501, 8, 42, 71),
                new Coordinate(581, 10, 55, 69), new Coordinate(655, 9, 63, 70), new Coordinate(725, 10, 55, 69) };
            return Create(davisRightTwo);
        }

        /*Basic Woody Sprites*/
        public ISprite CreateWoodyStaticLeftSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(742, 5, 39, 74) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyStaticRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(19, 5, 39, 74) };
            return Create(woodyRightZero);
        }

        public ISprite CreateWoodyWalkLeftSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(502, 4, 39, 75), new Coordinate(422, 4, 39, 75), new Coordinate(342, 4, 39, 75), new Coordinate(262, 4, 39, 75), new Coordinate(182, 4, 39, 75) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyWalkRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(259, 4, 39, 75), new Coordinate(339, 4, 39, 75), new Coordinate(419, 4, 39, 75), new Coordinate(499, 4, 39, 75), new Coordinate(579, 4, 39, 75) };
            return Create(woodyRightZero);
        }

        public ISprite CreateWoodyCrouchLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(744, 505, 33, 54) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyCrouchRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(23, 505, 33, 54) };
            return Create(woodyRightZero);
        }

        public ISprite CreateWoodyDeathLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(401, 363, 78, 34) };
            return Create(woodyLeftZero);
        }

        public ISprite CreateWoodyDeathRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(321, 363, 78, 34) };
            return Create(woodyRightZero);
        }

        /*Advanced Woody Sprites*/
        public ISprite CreateWoodySpecialAttackOneLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(739, 89, 52, 70), new Coordinate(662, 88, 47, 71), new Coordinate(580, 100, 53, 59),
                new Coordinate(495, 103, 58, 56), new Coordinate(414, 104, 59, 55), new Coordinate(337, 81, 49, 68), new Coordinate(257, 81, 49, 68),
                new Coordinate(177, 81, 49, 68), new Coordinate(97, 81, 49, 68)};
            return Create(woodyLeftTwo);
        }

        public ISprite CreateWoodySpecialAttackOneRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(9, 89, 52, 70), new Coordinate(91, 88, 47, 71), new Coordinate(167, 100, 53, 59),
                new Coordinate(247, 103, 58, 56), new Coordinate(327, 104, 59, 55), new Coordinate(414, 81, 49, 68), new Coordinate(494, 81, 49, 68),
                new Coordinate(574, 81, 49, 68), new Coordinate(654, 81, 49, 68)};
            return Create(woodyLeftTwo);
        }

        /*Basic Bat Sprites*/
        public ISprite CreateBatStaticLeftSprite()
        {

            coordinateList = new List<Coordinate>() { new Coordinate(736, 498, 44, 61) };
            return Create(batLeftZero);
        }

        public ISprite CreateBatStaticRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(20, 498, 44, 61) };
            return Create(batRightZero);
        }

        public ISprite CreateBatWalkLeftSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(503, 6, 38, 73), new Coordinate(424, 6, 37, 73),
                new Coordinate(344, 6, 37, 73), new Coordinate(264, 6, 37, 73), new Coordinate(183, 6, 38, 73)  };
            return Create(batLeftZero);
        }

        public ISprite CreateBatWalkRightSprite()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(259, 6, 38, 73), new Coordinate(339, 6, 37, 73),
                new Coordinate(419, 6, 37, 73), new Coordinate(499, 6, 37, 73) };
            return Create(batRightZero);
        }

        public ISprite CreateBatCrouchLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(736, 498, 44, 61) };
            return Create(batLeftZero);
        }

        public ISprite CreateBatCrouchRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(20, 498, 44, 61) };
            return Create(batRightZero);
        }

        public ISprite CreateBatDeathLeft()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(403, 366, 77, 31) };
            return Create(batLeftZero);
        }

        public ISprite CreateBatDeathRight()
        {
            coordinateList = new List<Coordinate>() { new Coordinate(320, 366, 77, 31) };
            return Create(batRightZero);
        }

        /*Advanced Bat Sprites*/
            //TODO Need other sprint sheet from Jason

    }
}
