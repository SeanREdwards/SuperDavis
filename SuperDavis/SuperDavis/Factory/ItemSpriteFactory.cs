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
        
        private Texture2D coin;

        public static ItemSpriteFactory Instance { get; } = new ItemSpriteFactory();

        private ItemSpriteFactory() { }

        public void Load(ContentManager content)
        {
            coin = content.Load<Texture2D>("Item/coin");
        }

        /*  Coin Sprite */
        public ISprite CreateCoinSprite()
        {
            return new DynamicSprite(coin, 4);
        }

    }
}
