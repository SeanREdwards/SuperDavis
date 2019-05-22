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
        
        private Texture2D davisStaticLeft;
        private Texture2D davisStaticRight;
        private Texture2D davisWalkLeft;
        private Texture2D davisWalkRight;

        private Texture2D woodyStaticLeft;
        private Texture2D woodyStaticRight;
        private Texture2D woodyWalkLeft;
        private Texture2D woodyWalkRight;

        private Texture2D batStaticLeft;
        private Texture2D batStaticRight;
        private Texture2D batWalkLeft;
        private Texture2D batWalkRight;

        private static DavisSpriteFactory instance = new DavisSpriteFactory();
        public static DavisSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private DavisSpriteFactory() { }

        public void Load(ContentManager content)
        {
            davisStaticLeft = content.Load<Texture2D>("Davis/DavisStaticLeft");
            davisStaticRight = content.Load<Texture2D>("Davis/DavisStaticRight");
            davisWalkLeft = content.Load<Texture2D>("Davis/DavisWalkLeft");
            davisWalkRight = content.Load<Texture2D>("Davis/DavisWalkRight");
            woodyStaticLeft = content.Load<Texture2D>("Davis/WoodyStaticLeft");
            woodyStaticRight = content.Load<Texture2D>("Davis/WoodyStaticRight");
            woodyWalkLeft = content.Load<Texture2D>("Davis/WoodyWalkLeft");
            woodyWalkRight = content.Load<Texture2D>("Davis/WoodyWalkRight");
            batStaticLeft = content.Load<Texture2D>("Davis/BatStaticLeft");
            batStaticRight = content.Load<Texture2D>("Davis/BatStaticRight");
            batWalkLeft = content.Load<Texture2D>("Davis/BatWalkLeft");
            batWalkRight = content.Load<Texture2D>("Davis/BatWalkRight");
        }

        /*  Davis Sprite */
        public ISprite CreateDavisStaticLeftSprite()
        {
            return new StaticSprite(davisStaticLeft);
        }

        public ISprite CreateDavisStaticRightSprite()
        {
            return new StaticSprite(davisStaticRight);
        }

        public ISprite CreateDavisWalkLeftSprite()
        {
            return new DynamicSprite(davisWalkLeft, 4);
        }

        public ISprite CreateDavisWalkRightSprite()
        {
            return new DynamicSprite(davisWalkRight, 4);
        }

        /*  Woody Sprite */
        public ISprite CreateWoodyStaticLeftSprite()
        {
            return new StaticSprite(woodyStaticLeft);
        }

        public ISprite CreateWoodyStaticRightSprite()
        {
            return new StaticSprite(woodyStaticRight);
        }

        public ISprite CreateWoodyWalkLeftSprite()
        {
            return new DynamicSprite(woodyWalkLeft, 4);
        }

        public ISprite CreateWoodyWalkRightSprite()
        {
            return new DynamicSprite(woodyWalkRight, 4);
        }

        /*  Bat Sprite */
        public ISprite CreateBatStaticLeftSprite()
        {
            return new StaticSprite(batStaticLeft);
        }

        public ISprite CreateBatStaticRightSprite()
        {
            return new StaticSprite(batStaticRight);
        }

        public ISprite CreateBatWalkLeftSprite()
        {
            return new DynamicSprite(batWalkLeft, 4);
        }

        public ISprite CreateBatWalkRightSprite()
        {
            return new DynamicSprite(batWalkRight, 4);
        }

    }
}
