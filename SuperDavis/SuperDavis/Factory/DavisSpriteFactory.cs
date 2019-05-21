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
        private Texture2D davisAnimated;
        private Texture2D davisStatic;

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
            davisAnimated = content.Load<Texture2D>("davis_animated");
            davisStatic = content.Load<Texture2D>("davis_static");
        }

        public ISprite CreateDavisAnimatedSprite()
        {
            return new DynamicSprite(davisAnimated,8);
        }

        public ISprite CreateDavisStaticSprite()
        {
            return new StaticSprite(davisStatic);
        }

    }
}
